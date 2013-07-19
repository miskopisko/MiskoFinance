using System;
using System.Collections.Generic;
using System.IO;
using MPersist.Core.Tools;

namespace MPersist.Core.SVN
{
    public class Subversion
	{
        private static readonly Logger Log = Logger.GetInstance(typeof(Subversion));

        // Get the currently installed version of SVN
		public static String InstalledVersion()
		{
            return CommandLineProcess.Execute("svn", "--non-interactive --version --quiet").StandardOutput;
		}
				
		// Call SVN cat command to get a file into a stream reader
        public static CommandLineProcess Cat(String file)
		{
            return CommandLineProcess.Execute("svn", "--non-interactive cat \"" + file + "\"");
		}
		
		// Call SVN command line to export a file to a specific location
        public static CommandLineProcess Export(SvnTarget target, String location)
		{
            return CommandLineProcess.Execute("svn", "--non-interactive export --force --quiet --revision \"" + target.Entry.Revision + "\" \"" + target.Entry.URL + "\" \"" + location + "\"");
		}
		
		// Call SVN add command to add a file to the repo
        public static CommandLineProcess Add(String filename)
		{
            CommandLineProcess result = CommandLineProcess.Execute("svn", "--non-interactive add -q --parents \"" + filename + "\"");

            // Catch SVN error E200009; Item is already added 
            if (result.ReturnCode.Equals(1) && result.StandardError.Contains("E200009"))
            {
                result.StandardError = null;
                result.ReturnCode = 0;
            }

            return result;
		}
		
		// Call SVN revert command to revert a file to the latest version
        public static CommandLineProcess Revert(String file)
		{
            return CommandLineProcess.Execute("svn", "--non-interactive revert -q -R \"" + file + "\"");
		}
				
		// Call SVN delete command to delete a file from the repo
        public static CommandLineProcess Delete(String filename)
		{
            return CommandLineProcess.Execute("svn", "--non-interactive delete -q \"" + filename + "\"");
		}

        // Call SVN cleanup command to delete a file from the repo
        public static CommandLineProcess Cleanup(String wc)
        {
            return CommandLineProcess.Execute("svn", "--non-interactive cleanup \"" + wc + "\"");
        }
		
		// Call SVN commit to commit the changelist
        public static CommandLineProcess Commit(List<FileInfo> files, String message, String username, String password)
		{			
			String fileList = "";
			foreach (FileInfo file in files)
			{
				fileList += "\"" + file.FullName + "\" ";
			}
			
			// Generate a new temp file to store the message
			String messageFile = Environment.GetEnvironmentVariable("TEMP") + Path.DirectorySeparatorChar + Guid.NewGuid() + ".txt";
			File.WriteAllText(messageFile, message);

            // Execute the commiy
            CommandLineProcess result = CommandLineProcess.Execute("svn", "--non-interactive commit --file \"" + messageFile + "\" --username \"" + username + "\" --password \"" + password + "\" " + fileList.Trim());

            // Pull the revision number from the StdOut
            if(result.Success)
            {
                String[] lines = result.StandardOutput.Split(Environment.NewLine.ToCharArray());
                foreach (String line in lines)
                {
                    if (line.StartsWith("Committed revision "))
                    {
                        result.ReturnedObject = Convert.ToInt32(line.Replace("Committed revision ", "").Replace(".", ""));
                    }
                }
            }

            return result;
		}
	}
}
