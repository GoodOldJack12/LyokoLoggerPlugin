using System;

namespace LoggerPlugin
{
    public static class Logger
    {

        
        public static void StartLogging()
        {
            LyokoAPI.Events.LyokoLogger.Subscribe(Log);
        }

        public static void StopLogging()
        {
            LyokoAPI.Events.LyokoLogger.Unsubscribe(Log);
        }

        private static void Log(string message)
        {
            Console.WriteLine(message);
        }
        
    }
}