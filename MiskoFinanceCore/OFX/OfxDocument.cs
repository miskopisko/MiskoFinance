using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using log4net;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Enums;
using MiskoPersist.Enums;
using MiskoPersist.MoneyType;

namespace MiskoFinanceCore.OFX
{
	public class OfxDocument
	{
		private static ILog Log = LogManager.GetLogger(typeof(OfxDocument));

		#region Variable Declarations

		private String OfxHeader;
		private String Data;
		private String Version;
		private String Security;
		private String Encoding;
		private String Charset;
		private String Compression;
		private String OldFileUID;
		private String NewFileUID;

		#endregion

		#region Properties

		public VwTxns Transactions { get; set; }
		public AccountType AccountType { get; set; }
		public String AccountID { get; set; }
		public String BankID { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

		#endregion

		#region Constructors

		public OfxDocument(Stream stream)
		{
			using (StreamReader reader = new StreamReader(stream))
			{
				Boolean inHeader = true;
				while (!reader.EndOfStream)
				{
					String temp = reader.ReadLine();
					if(inHeader)
					{
						if(temp.ToLower().Contains("<ofx>"))
						{
							inHeader = false;
						}
						#region Read Header
						else
						{
							String[] tempSplit = temp.Split(":".ToCharArray());
							switch (tempSplit[0].ToLower())
							{
								case "ofxheader":
									OfxHeader = tempSplit[1];
									break;
								case "data":
									Data = tempSplit[1];
									break;
								case "version":
									Version = tempSplit[1];
									break;
								case "security":
									Security = tempSplit[1];
									break;
								case "encoding":
									Encoding = tempSplit[1];
									break;
								case "charset":
									Charset = tempSplit[1];
									break;
								case "compression":
									Compression = tempSplit[1];
									break;
								case "oldfileuid":
									OldFileUID = tempSplit[1];
									break;
								case "newfileuid":
									NewFileUID = tempSplit[1];
									break;
							}
						}
						#endregion
					}
					if (!inHeader) // have to make different if statement so it rolls over correctly
					{
						String restOfFile = temp + reader.ReadToEnd();
						restOfFile = Regex.Replace(restOfFile, Environment.NewLine, "");
						restOfFile = Regex.Replace(restOfFile, "\n", "");
						restOfFile = Regex.Replace(restOfFile, "\t", "");

						FillAccountInfo(restOfFile);
						FillTransactions(Regex.Match(restOfFile, @"(?<=<banktranlist>).+(?=<\/banktranlist>)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value);
					}
				}
			}
		}

		#endregion

		#region Private Methods

		private void FillAccountInfo(String text)
		{
			BankID = Regex.Match(text, @"(?<=bankid>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value;
			AccountID = Regex.Match(text, @"(?<=acctid>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value;
			AccountType = MiskoEnum.Parse<AccountType>(Regex.Match(text, @"(?<=accttype>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value);
			StartDate = DateTime.ParseExact(Regex.Match(text, @"(?<=dtstart>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value.Substring(0,8),"yyyyMMdd", null);
			EndDate = DateTime.ParseExact(Regex.Match(text, @"(?<=dtend>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value.Substring(0, 8), "yyyyMMdd", null);
		}

		private void FillTransactions(String banktranlist)
		{
			Transactions = new VwTxns();
			MatchCollection m = Regex.Matches(banktranlist, @"<stmttrn>.+?<\/stmttrn>", RegexOptions.Multiline | RegexOptions.IgnoreCase);
			foreach (Match match in m)
			{
				foreach (Capture capture in match.Captures)
				{
					VwTxn txn = new VwTxn();                   

					String dt = Regex.Match(capture.Value, @"(?<=<dtposted>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value;
					String amt = Regex.Match(capture.Value, @"(?<=<trnamt>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value;                    
					String name = Regex.Match(capture.Value, @"(?<=<name>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value;
					String memo = Regex.Match(capture.Value, @"(?<=<memo>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value;

					name = HttpUtility.HtmlDecode(name);
					memo = HttpUtility.HtmlDecode(memo);

					txn.Amount = new Money(Math.Abs(Decimal.Parse(amt)));
					txn.Description = (name + " " + memo).Trim();
					txn.DatePosted = DateTime.ParseExact(dt.Substring(0, 8), "yyyyMMdd", null);
					txn.HashCode = AccountID + "-" + Regex.Match(capture.Value, @"(?<=<fitid>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value;

					if(Regex.Match(capture.Value, @"(?<=<trntype>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value.ToLower().Equals("credit"))
					{
						txn.DrCr = DrCr.Credit;
					}
					if(Regex.Match(capture.Value, @"(?<=<trntype>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value.ToLower().Equals("debit"))
					{
						txn.DrCr = DrCr.Debit;
					}
					if(Regex.Match(capture.Value, @"(?<=<trntype>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value.ToLower().Equals("srvchg"))
					{
						txn.DrCr = DrCr.Debit;
					}
					if(Regex.Match(capture.Value, @"(?<=<trntype>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value.ToLower().Equals("check"))
					{
						txn.DrCr = DrCr.Debit;
					}

					Transactions.Add(txn);
				}
			}
		}

		#endregion

		#region Public Methods



		#endregion
	}
}
