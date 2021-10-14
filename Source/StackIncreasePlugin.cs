using StudioForge.TotalMiner.API;
using StudioForge.TotalMiner;
using StudioForge.Engine.Core;
using System.IO;

namespace DaveTheMonitor.StackIncrease
{
    public class StackIncreasePlugin : ITMPlugin
    {
        StackIncreaseXML stackSizes;
        void ITMPlugin.PlayerJoined(ITMPlayer player) { }
        void ITMPlugin.PlayerLeft(ITMPlayer player) { }
        void ITMPlugin.WorldSaved(int version) { }
        void ITMPlugin.Initialize(ITMPluginManager mgr, string path) =>
            stackSizes = FileSystem.Deserialize<StackIncreaseXML>(Path.Combine(path, "Config.xml"));
        void ITMPlugin.InitializeGame(ITMGame game)
        {
            int stackSize = stackSizes.StackSize;
            int gpStackSize = stackSizes.GPStackSize;
            bool only100Stacks = stackSizes.Only100Stacks;
            foreach (ItemDataXML item in Globals1.ItemData)
            {
                if (item.ItemID == Item.GoldPieces) item.StackSize = gpStackSize;
                else if (only100Stacks && item.StackSize >= 100) item.StackSize = stackSize;
                else if (!only100Stacks && item.Durability == 0) item.StackSize = stackSize;
            }
        }
        void ITMPlugin.UnloadMod() { }
        bool ITMPlugin.HandleInput(ITMPlayer player) => false;
        void ITMPlugin.Draw(ITMPlayer player, ITMPlayer virtualPlayer) { }
        void ITMPlugin.Update() { }
        void ITMPlugin.Update(ITMPlayer player) { }
    }
}