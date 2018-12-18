using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace LoggerPlugin
{
    public static class Logger
    {
        private static bool initialized;
        private static StreamWriter output;
        private static Process consoleProcess;
        private static ProcessStartInfo startInfo = new ProcessStartInfo();
        private static string logPath = Path.GetTempPath() + "LyokoLogger.log";
        public static void StartLogging()
        {
            EnsureInitialized();
            LyokoAPI.Events.LyokoLogger.Subscribe(Log);
            
            //Log($"found {findXtermPath()}");
        }

        public static void StopLogging()
        {
            LyokoAPI.Events.LyokoLogger.Unsubscribe(Log);
            EnsureStopped();
        }

        private static void Log(string message)
        {
            if (initialized)
            {
                using (output = new StreamWriter(logPath,true))
                {
                    output.WriteLine(message);
                } 
            }
            

            
        }

        private static bool IsLinux()
        {
            return Environment.OSVersion.Platform == PlatformID.Unix;
        }


        private static void EnsureInitialized()
        {
           
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Unix:
                {
                    startInfo.FileName = "/usr/bin/xterm";
                    startInfo.Arguments = $"-T \"Logging {logPath}\" -e tail -f /tmp/LyokoLogger.log ";
                } break;
                case PlatformID.Win32Windows:
                {
                    startInfo.FileName = "powershell.exe";
                    startInfo.Arguments = $"-noexit -Command \"$Host.UI.RawUI.WindowTitle = \'Logging {logPath}\';Get-Content \'{logPath}\' -wait\"";
                } break;
                case PlatformID.MacOSX:
                {
                    startInfo.FileName = "/Applications/Utilities/Terminal.app/Contents/MacOS/Terminal";
                    startInfo.Arguments = $"echo -n -e \"\\033]0;Logging {logPath}\\007\" && \"tail -f /tmp/LyokoLogger.log\" ";
                } break;
                 
            }
            
            
            startInfo.UseShellExecute = !IsLinux();
            File.Delete(logPath);            
            
            consoleProcess = new Process {StartInfo = startInfo};
            consoleProcess.Start();
           
            initialized = true;
        }

        private static void EnsureStopped()
        {
            if (!initialized) return;
            consoleProcess.Close();
            consoleProcess.Kill();
            initialized = false;
        }
        //TODO this does not work for some reason.
        private static string findXtermPath()
        {
            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.FileName = "/bin/bash";
            process.StartInfo.Arguments = "-c \"which xterm\"";
            process.Start();
            process.WaitForExit();
            string output = "";

            return output;
        }
        
    }
}