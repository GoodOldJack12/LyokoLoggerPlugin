using System;

namespace LoggerPlugin
{
    public class Logger
    {

        
        public static void StartLogging()
        {
            LyokoAPI.Events.Logger.Subscribe(Log);
        }

        public static void StopLogging()
        {
            LyokoAPI.Events.Logger.Unsubscribe(Log);
        }

        private static void Log(string message)
        {
            Console.WriteLine(message);
        }
        
    }
}