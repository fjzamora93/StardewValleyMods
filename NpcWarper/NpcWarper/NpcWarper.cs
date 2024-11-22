using StardewModdingAPI;
using StardewValley;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using StardewModdingAPI.Events;

using System;
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
-Front sofa: 30, 25 */


/*DIRECCIONES:
 0 - Abajo    1 - Derecha    2 - Arriba     3 - Izquierda*/

namespace NpcWarper
{
    public abstract class NpcWarper
    {
        protected readonly string npcName;
        protected readonly NPC npcSelected;
        protected readonly IModHelper Helper;
        protected readonly IMonitor Monitor;

        protected NpcWarper(string npcName,  IModHelper helper, IMonitor monitor)
        {
            this.npcName = npcName;
            this.Helper = helper;
            this.Monitor = monitor;
        }


        public void  warpToFarm()
        {
            NPC npcSelected = Game1.getCharacterFromName(npcName);
            if (npcSelected != null && !npcSelected.isMarried())
            {
            
            

            int coord_x = 43;
            int coord_y = 28;
            Monitor.Log($"Desplazando a {npcName} a las coordenadas {coord_x}, {coord_y}");
            Game1.warpCharacter(npcSelected, "FarmHouse", new Point(coord_x, coord_y));

            npcSelected.Halt();
            npcSelected.movementPause = 450000;
            npcSelected.faceDirection(1);

            setAnimation(npcSelected);
            }

        }

        public void  setAnimation(NPC npcSelected)
        {
            npcSelected.Sprite.setCurrentAnimation(new List<FarmerSprite.AnimationFrame>
                    {
                        new FarmerSprite.AnimationFrame(35, 3000), // Frame 1
                        new FarmerSprite.AnimationFrame(36, 3000), // 51 = Frame tumbado
                        new FarmerSprite.AnimationFrame(37, 3000),
                        new FarmerSprite.AnimationFrame(38, 3000, false, false)
                    });


            Game1.delayedActions.Add(new DelayedAction(15000, () =>
                    npcSelected.Sprite.setCurrentAnimation(new List<FarmerSprite.AnimationFrame>
                    {
                            new FarmerSprite.AnimationFrame(0, 3000), 
                            new FarmerSprite.AnimationFrame(1, 3000), 
                            new FarmerSprite.AnimationFrame(2, 3000),
                            new FarmerSprite.AnimationFrame(3, 3000, false, false)
                    })
                ));
        }

        public void pauseNpc()
        {
           

            // Comprobación de la ubicación de Alex y pausa si está en la FarmHouse
            NPC npcSelected = Game1.getCharacterFromName(this.npcName);
            if (!npcSelected.isMarried() && npcSelected != null)
            {
                // Verifica si Alex está en la "FarmHouse"
                if (npcSelected.currentLocation.Name == "FarmHouse")
                {
                    npcSelected.movementPause = 500000;  // Detener el movimiento de Alex
                }
            }
        }


    }
}