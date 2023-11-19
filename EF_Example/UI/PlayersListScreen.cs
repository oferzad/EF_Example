using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Example.Models;

namespace EF_Example.UI
{
    class PlayersListScreen:Screen
    {
        public PlayersListScreen(): base("Players List")
        {

        }
        private void ShowError(string message)
        {
            Console.WriteLine("Fail reading players data from DB! ");
            Console.WriteLine("Error Message:" + message);
            Console.WriteLine("Press any key to go back....");
            Console.ReadKey();
        }
        public override void Show()
        {
            base.Show();
            try
            {
                //Read Players from DB
                HighScoresDbContext db = new HighScoresDbContext();
                List<Object> players = db.GetPlayers().ToList<Object>();
                ObjectsList showPlayers = new ObjectsList("All Players", players.ToList<Object>());
                showPlayers.Show();
                Console.Write("Type PlayerID to View or Enter to go back:");
                string str = Console.ReadLine();
                int playerID=-1;
                if (int.TryParse(str, out playerID))
                {
                    PlayerScreen screen = new PlayerScreen(playerID);
                    screen.Show();
                }
                    
                

            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }



        }
    }
}
