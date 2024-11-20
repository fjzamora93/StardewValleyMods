using StardewModdingAPI;
using StardewValley;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SamBeachSprite
{
    public abstract class CharacterSpriteChanger
    {
        protected readonly string npcName;
        protected readonly string currentSeason;
        public readonly List<string> possibleLocations;
        protected readonly IModHelper Helper;
        protected readonly IMonitor Monitor;
        

        protected CharacterSpriteChanger(string npcName, List<string> possibleLocations, IModHelper helper, IMonitor monitor)
        {
            this.npcName = npcName;
            this.possibleLocations = possibleLocations;
            this.Helper = helper;
            this.Monitor = monitor;
            this.currentSeason = Game1.currentSeason;
        }

        public void ChangeSprite(string locationName)
        {
            var npcSelected = Game1.getCharacterFromName(npcName);
            if (npcSelected != null)
            {
                // Cargar el nuevo sprite de NPC desde el mod
                string assetPath = GetSpritePath(locationName);
                string portraitPath = GetSpritePathPortrait(locationName);
                npcSelected.Sprite.spriteTexture = Helper.ModContent.Load<Texture2D>(assetPath);
                npcSelected.Portrait = Helper.ModContent.Load<Texture2D>(portraitPath); 
                Monitor.Log($"Sprite de {npcName} cambiado a la versión de {locationName}.", LogLevel.Info);
            }
            else
            {
                Monitor.Log($"No se encontró a {npcName}.", LogLevel.Warn);
            }
        }

        public void ResetNpcSprite()
        {
            var npcSelected = Game1.getCharacterFromName(npcName);
            if (npcSelected != null)
            {
                // Restablecer el sprite a su versión original
                string assetPath = GetOriginalSpritePath();
                npcSelected.Sprite.spriteTexture = Helper.ModContent.Load<Texture2D>(assetPath);
                Monitor.Log($"Sprite de {npcName} restablecido a la versión original.", LogLevel.Info);
            }
        }

        protected abstract string GetSpritePath(string locationName);
        protected abstract string GetSpritePathPortrait(string locationName);
        protected abstract string GetOriginalSpritePath();
        protected abstract string GetOriginalPortrait();
    }
}