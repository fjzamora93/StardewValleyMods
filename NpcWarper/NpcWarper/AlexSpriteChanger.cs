using System;
using StardewModdingAPI;
using StardewValley;
using StardewModdingAPI.Events;
using Microsoft.Xna.Framework.Graphics;
using StardewValley.Objects;
using xTile;
using System.Collections.Generic;

namespace NpcWarper
{
   

    public class AlexSpriteChanger : CharacterSpriteChanger
    {
        public AlexSpriteChanger(IModHelper helper, IMonitor monitor)
            : base("Alex", new List<string> { "Beach", "JoshHouse" }, helper, monitor) { }

        protected override string GetSpritePath(string locationName)
        {
            return $"assets/{npcName}/{npcName}_{locationName}.png";
        }

        protected override string GetOriginalSpritePath()
        {
            return $"assets/{npcName}/{npcName}_Summer.png";
        }

        protected override string GetSpritePathPortrait(string locationName)
        {
            return $"assets/{npcName}/portrait/{npcName}_{locationName}.png";
        }

        protected override string GetOriginalPortrait()
        {
            return $"assets/{npcName}/portrait/{npcName}_{currentSeason}.png";
        }
    }
}