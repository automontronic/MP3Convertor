using System;
using System.Diagnostics;

namespace MP3Convertor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the source file:");
            string source = Console.ReadLine();
            Console.WriteLine("Enter the destination file:");
            string destination = Console.ReadLine();
            Execute(Environment.CurrentDirectory + "\\ffmpeg.exe", string.Format("-i \"{0}\" -hide_banner -ac 1 \"{1}\"",source, destination));
        }

        private static string Execute(string exePath, string parameters)
        {
            string result = String.Empty;
            using (Process p = new Process())
            {
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = exePath;
                p.StartInfo.Arguments = parameters;
                p.Start();
                p.WaitForExit();

                result = p.StandardOutput.ReadToEnd();
            }
            return result;
        }
    }
}
