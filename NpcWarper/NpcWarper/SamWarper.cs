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
    

    public class SamWarper : NpcWarper
    {
        public SamWarper(IModHelper helper, IMonitor monitor)
            : base("Sam",  helper, monitor) { }

   
    }
}