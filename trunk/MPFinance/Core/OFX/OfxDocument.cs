using System;
using System.IO;
using System.Text.RegularExpressions;
using MPersist.Core;
using MPFinance.Resources.Enums;
using MPFinance.Core.Data.Stored;

namespace MPFinance.Core.OFX
{
    public class OfxDocument
    {
        private static Logger Log = Logger.GetInstance(typeof(OfxDocument));

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

        public Transactions Transactions { get; set; }
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
                bool inHeader = true;
                while (!reader.EndOfStream)
                {
                    string temp = reader.ReadLine();
                    if (inHeader)
                    {
                        if (temp.ToLower().Contains("<ofx>"))
                        {
                            inHeader = false;
                        }
                        #region Read Header
                        else
                        {
                            string[] tempSplit = temp.Split(":".ToCharArray());
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
                        string restOfFile = temp + reader.ReadToEnd();
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
            AccountType = AccountType.GetElement(Regex.Match(text, @"(?<=accttype>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value);
            StartDate = DateTime.ParseExact(Regex.Match(text, @"(?<=dtstart>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value.Substring(0,8),"yyyyMMdd", null);
            EndDate = DateTime.ParseExact(Regex.Match(text, @"(?<=dtend>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value.Substring(0, 8), "yyyyMMdd", null);
        }

        private void FillTransactions(String banktranlist)
        {
            Transactions = new Core.Data.Stored.Transactions();
            MatchCollection m = Regex.Matches(banktranlist, @"<stmttrn>.+?<\/stmttrn>", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            foreach (Match match in m)
            {
                foreach (Capture capture in match.Captures)
                {
                    Transaction trans = new Transaction();
                    if (Regex.Match(capture.Value, @"(?<=<trntype>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value.ToLower().Equals("credit"))
                        trans.Type = TransactionType.Credit;
                    if (Regex.Match(capture.Value, @"(?<=<trntype>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value.ToLower().Equals("debit"))
                        trans.Type = TransactionType.Debit;
                    if (Regex.Match(capture.Value, @"(?<=<trntype>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value.ToLower().Equals("srvchg"))
                        trans.Type = TransactionType.Debit;

                    trans.CheckNum = Regex.Match(capture.Value, @"(?<=<checknum>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value;
                    String dt = Regex.Match(capture.Value, @"(?<=<dtposted>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value;
                    String amt = Regex.Match(capture.Value, @"(?<=<trnamt>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value;
                    trans.DatePosted = DateTime.ParseExact(dt.Substring(0, 8), "yyyyMMdd", null);
                    trans.Amount = new Money(Math.Abs(Decimal.Parse(amt)));
                    trans.FITID = Regex.Match(capture.Value, @"(?<=<fitid>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value;
                    trans.Name = Regex.Match(capture.Value, @"(?<=<name>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value;
                    trans.Memo = Regex.Match(capture.Value, @"(?<=<memo>).+?(?=<)", RegexOptions.Multiline | RegexOptions.IgnoreCase).Value;
                    Transactions.Add(trans);
                }
            }
        }

        #endregion

        #region Public Methods



        #endregion
    }
}
