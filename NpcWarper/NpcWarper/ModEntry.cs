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
using StardewValley.Locations;




namespace NpcWarper
{
    public class ModEntry : Mod
    {
        private AlexWarper alexWarper;
        private SamWarper samWarper;

        public override void Entry(IModHelper helper)
        {
            alexWarper = new AlexWarper(helper, Monitor);
            samWarper = new SamWarper(helper, Monitor);
            helper.Events.GameLoop.TimeChanged += OnTimeChanged;
            helper.Events.GameLoop.UpdateTicked += OnUpdateTicked;
        }



        private void OnTimeChanged(object sender, EventArgs e)
        {
            Random random = new Random();
            int numeroAleatorio = random.Next(1, 4); // Genera un número aleatorio entre 1 y 3


            string dayOfWeek = Game1.shortDayNameFromDayOfSeason(Game1.dayOfMonth);

            Monitor.Log($"La hora ha cambiado y hoy es {dayOfWeek}");

            if (Game1.timeOfDay == 2200 && dayOfWeek != "Mon")
            {
                alexWarper.warpToFarm();
            }

            if(Game1.timeOfDay == 2100)
            {
                Monitor.Log($"Son las 9 de la noche... ahora debería moverse Sam");
                samWarper.warpToFarm();
            }


        }
        /**Este método buscará a cada iteración para ejecutar lo que hay dentro 
         El timeOfDay es un requisito para asegurar de que se llama solo dentro de la partida*/
        public void OnUpdateTicked(object sender, EventArgs e)
        {
            if (Game1.timeOfDay > 1500)
            {
                alexWarper.pauseNpc();
                samWarper.pauseNpc();
            }
               
        }

    }
}
