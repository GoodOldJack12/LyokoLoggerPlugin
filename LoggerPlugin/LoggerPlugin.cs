using LyokoAPI.Plugin;

namespace LoggerPlugin
{
    public class LoggerPlugin : LyokoAPIPlugin
    {
        public override string Name { get; } = "LoggerPlugin";
        public override string Author { get; } = "GoodOldJack12";
        protected override bool OnEnable()
        {
            Logger.StartLogging();
            return true;
        }

        protected override bool OnDisable()
        {
            Logger.StopLogging();
            return false;
        }

        public override void OnGameStart(bool storyMode)
        {
        }

        public override void OnGameEnd(bool failed)
        {
        }

        
    }
}