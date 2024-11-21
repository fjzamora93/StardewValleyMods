using StardewModdingAPI.Events;
using StardewModdingAPI;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SamBeachSprite
{
    public class ModEntry : Mod
    {
        private SamSpriteChanger samSpriteChanger;
        private AlexSpriteChanger alexSpriteChanger;

        private List<CharacterSpriteChanger> npcList;
        public override void Entry(IModHelper helper)
        {
            samSpriteChanger = new SamSpriteChanger(helper, Monitor);
            alexSpriteChanger = new AlexSpriteChanger(helper, Monitor);
            npcList = new List<CharacterSpriteChanger> { 
                samSpriteChanger, 
                alexSpriteChanger 
            };

            helper.Events.Player.Warped += OnPlayerWarped;
            //helper.Events.GameLoop.TimeChanged += OnTimeChanged;
        }

        private void OnPlayerWarped(object sender, WarpedEventArgs e)
        {
            npcList.ForEach(npc =>
            {
                Monitor.Log(Game1.currentLocation.Name);
                if (npc.possibleLocations.Contains(Game1.currentLocation.Name))
                {
                    npc.ChangeSprite(Game1.currentLocation.Name);
                    Monitor.Log($"Sprite de {Game1.currentSeason} dentro de {Game1.currentLocation.Name}.", LogLevel.Info);

                }
                else
                {
                    npc.ResetNpcSprite();
                }
            });
       
        }

        //private void OnTimeChanged(object sender, EventArgs e)
        //{
        //    Monitor.Log($"La hora ha cambiado");
        //    if (Game1.timeOfDay == 2200)
        //    {
        //        Monitor.Log($"Son las 8 de la mañana... ahora debería moverse Alex");
        //        MoveAlexToNewMap();
        //    }
        //}

        //private void MoveAlexToNewMap()
        //{
         
        //    NPC alex = Game1.getCharacterFromName("Alex");
        //    Monitor.Log($"Desplazando a Alex a las coordenadas 35,10");
        //    if (alex != null)
        //    {
        //        //Game1.warpFarmer("FarmHouse", 34, 28, 0); // Mueve al jugador a las vías del tren (aquí tienes que colocar las coordenadas y nombre correctos del mapa)

        //        alex.xVelocity = 0;
        //        alex.yVelocity = 0;
        //        alex.movementPause = 5000;

             

        //        // Ahora movemos a Alex al nuevo mapa (las coordenadas pueden ser ajustadas)
        //        Game1.warpCharacter(alex, "FarmHouse", new Point(30, 25)); // Aquí indicamos las coordenadas para Alex en el nuevo mapa
                
        //    }
        //}
    }
}
