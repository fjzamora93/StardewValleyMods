using System;
using StardewModdingAPI;
using StardewValley;
using StardewModdingAPI.Events;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using StardewValley.Objects;
using xTile;
using System.Collections.Generic;

namespace NpcWarper
{
    

    public class SamSpriteChanger : CharacterSpriteChanger
    {
        public SamSpriteChanger(IModHelper helper, IMonitor monitor)
            : base("Sam", new List<string> { "Beach", "SamHouse" }, helper, monitor) { }

        protected override string GetSpritePath(string locationName)
        {
            return $"assets/{npcName}/{npcName}_{locationName}.png";
        }

        protected override string GetOriginalSpritePath()
        {
            return $"assets/{npcName}/{npcName}_{currentSeason}.png";
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