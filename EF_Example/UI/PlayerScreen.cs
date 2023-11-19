using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EF_Example.Models;
namespace EF_Example.UI
{
    class PlayerScreen:Screen
    {
        private int playerID;
        public PlayerScreen(int playerID):base("Show Player")
        {
            this.playerID = playerID;
        }

        private void ShowError(string message)
        {
            Console.WriteLine("Fail reading player data from DB! ");
            Console.WriteLine("Error Message:" + message);
            Console.WriteLine("Press any key to go back....");
            Console.ReadKey();
        }
        public override void Show()
        {
            base.Show();
            try
            {
                //Read Player from DB
                HighScoresDbContext db = new HighScoresDbContext();
                Player? p = db.GetFullPlayerData(playerID);
                if (p != null ) 
                {
                    ObjectView showPlayer = new ObjectView("", p);
                    showPlayer.Show();
                    Console.WriteLine("Press H to see Player High Scores or other key to go back!");
                    char c = Console.ReadKey().KeyChar;
                    if (c == 'h' || c == 'H')
                    {
                        Console.WriteLine();
                        //Create list to be displayed on screen
                        //Format the desired fields to be shown! (screen is not wide enough to show all)
                        List<Object> highScores = (from highScoreList in p.HighScores
                                                select new
                                                {
                                                    Game = highScoreList.Game.Name,
                                                    Score = highScoreList.Score}).ToList<Object>();
                        ObjectsList list = new ObjectsList("HighScores", highScores);
                        list.Show();
                        Console.WriteLine();
                        Console.ReadKey();
                    }
                    
                }
                else
                {
                    ShowError($"Player id {playerID} NOT FOUND!");
                }

            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            
            
            
        }
    }
}
