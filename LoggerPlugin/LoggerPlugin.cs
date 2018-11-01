using LyokoAPI.Plugin;

namespace LoggerPlugin
{
    public class LoggerPlugin : LyokoAPIPlugin
    {
        public string Name { get; } = "LoggerPlugin";
        public string Author { get; } = "GoodOldJack12";
        public bool Enabled { get; private set; }
        
        public bool OnEnable()
        {
            Enabled = true;
            Logger.StartLogging();
            return true;
        }

        public bool OnDisable()
        {
            Enabled = false;
            Logger.StopLogging();
            return false;
        }

        public void OnGameStart(bool storyMode)
        {
        }

        public void OnGameEnd(bool failed)
        {
        }

        
    }
}