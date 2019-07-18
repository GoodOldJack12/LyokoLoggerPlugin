using System.Collections.Generic;
using LyokoAPI.API;
using LyokoAPI.Plugin;

namespace LoggerPlugin
{
    public class LoggerPlugin : LyokoAPIPlugin
    {
        public override string Name { get; } = "LoggerPlugin";
        public override string Author { get; } = "GoodOldJack12";
        public override LVersion Version { get; } = "1.1.0";
        public override List<LVersion> CompatibleLAPIVersions { get; } = new List<LVersion>() {"2.0.0"};

        protected override bool OnEnable()
        {
            Logger.StartLogging();
            ConfigManager.GetMainConfig().Values.Add("MySpecialValue","HELLO THERE");
            return true;
        }

        protected override bool OnDisable()
        {
            ConfigManager.SaveAllConfigs();
            Logger.StopLogging();
            return true;
        }

        public override void OnGameStart(bool storyMode)
        {
        }

        public override void OnGameEnd(bool failed)
        {
        }

        
    }
}