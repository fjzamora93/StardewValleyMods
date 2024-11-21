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


/**
 UBICACIONES CLAVE:
-Frontdoor: 27,30
-Frontdoor-turnRight: 27,28
-DestinationPointRoom: 43,28
-Kitchen: 20,28
-Front table: 27,26
-Front sofa: 30, 25
 
 
 */


/*DIRECCIONES:
 0 - Abajo    1 - Derecha    2 - Arriba     3 - Izquierda*/


namespace NpcWarper
{
    public class ModEntry : Mod
    {

        private List<CharacterSpriteChanger> npcList;
        public override void Entry(IModHelper helper)
        {

            helper.Events.GameLoop.TimeChanged += OnTimeChanged;
        }



        private void OnTimeChanged(object sender, EventArgs e)
        {
            Monitor.Log($"La hora ha cambiado");
            if (Game1.timeOfDay == 2200)
            {
                Monitor.Log($"Son las 10 de la noche... ahora debería moverse Alex");
                MoveAlexToNewMap();
            }
            else if(Game1.timeOfDay == 2100)
            {
                Monitor.Log($"Son las 10 de la noche... ahora debería moverse Sam");
                MoveSamToNewMap();
            }




        }

        private void MoveAlexToNewMap()
        {

            NPC alex = Game1.getCharacterFromName("Alex");
            if (alex != null)
            {
                //Game1.warpFarmer("FarmHouse", 34, 28, 0); // Mueve al jugador a las vías del tren (aquí tienes que colocar las coordenadas y nombre correctos del mapa)

                // 27,30: partimos de la entrada
                int coord_x = 43;
                int coord_y = 28;
                Monitor.Log($"Desplazando a Alex a las coordenadas {coord_x}, {coord_y}");
                alex.Halt();
                alex.moveTowardPlayer(5);
                // Ahora movemos a Alex al nuevo mapa (las coordenadas pueden ser ajustadas)
                Game1.warpCharacter(alex, "FarmHouse", new Point(coord_x, coord_y));

                alex.Halt();
                alex.movementPause = 450000;
                alex.faceDirection(1); // Mirar hacia arriba (2)
         
                Monitor.Log("Comienza el desplazamiento", LogLevel.Info);

                alex.Sprite.setCurrentAnimation(new List<FarmerSprite.AnimationFrame>
                    {
                        new FarmerSprite.AnimationFrame(0, 1000), // Frame 1
                        new FarmerSprite.AnimationFrame(3, 3000), // 51 = Frame tumbado
                        new FarmerSprite.AnimationFrame(0, 1000),
                        new FarmerSprite.AnimationFrame(3, 1000, false, false)
                    });


                Game1.delayedActions.Add(new DelayedAction(15000, () =>
                    alex.Sprite.setCurrentAnimation(new List<FarmerSprite.AnimationFrame>
                        {
                            new FarmerSprite.AnimationFrame(49, 3000), // Frame 1
                            new FarmerSprite.AnimationFrame(50, 3000), // 51 = Frame tumbado
                            new FarmerSprite.AnimationFrame(51, 3000),
                            new FarmerSprite.AnimationFrame(51, 3000, false, false)
                        })
                    ));

            }
        }



        private void MoveSamToNewMap()
        {
            NPC sam = Game1.getCharacterFromName("Sam");
            int coord_x = 43;
            int coord_y = 28;
            sam.Halt();


            Monitor.Log($"Desplazando a Sam a las coordenadas {coord_x}, {coord_y}");
            if (sam != null)
            {
      
                sam.movementPause = 10000;
                Game1.warpCharacter(sam, "FarmHouse", new Point(coord_x, coord_y)); 

            }
        }
    }
}
