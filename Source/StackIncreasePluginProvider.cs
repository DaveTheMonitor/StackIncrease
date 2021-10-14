using StudioForge.TotalMiner.API;

namespace DaveTheMonitor.StackIncrease
{
    public class StackIncreasePluginProvider : ITMPluginProvider
    {
        public ITMPlugin GetPlugin() => new StackIncreasePlugin();
        public ITMPluginArcade GetPluginArcade() => null;
        public ITMPluginBlocks GetPluginBlocks() => null;
        public ITMPluginGUI GetPluginGUI() => null;
        public ITMPluginNet GetPluginNet() => null;
    }
}
