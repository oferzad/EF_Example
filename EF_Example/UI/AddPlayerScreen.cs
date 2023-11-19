using EF_Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Example.UI
{
    internal class AddPlayerScreen:Screen
    {
        public AddPlayerScreen() : base("Add Player")
        {
            
        }

        private void ShowError(string message)
        {
            Console.WriteLine("Fail Adding player to DB! ");
            Console.WriteLine("Error Message:" + message);
            Console.WriteLine("Press any key to go back....");
            Console.ReadKey();
        }
        public override void Show()
        {
            base.Show();
            try
            {
                //Get data from user
                Console.WriteLine("Please type player name:");
                string name = Console.ReadLine();
                Console.WriteLine("Please type player birth year: ");
                int birthYear = int.Parse(Console.ReadLine());

                //Create Player object and write to DB
                HighScoresDbContext db = new HighScoresDbContext();
                Player p = new Player()
                {
                    Name = name,
                    BirthYear = birthYear
                };
                db.AddPlayer(p);

                Console.WriteLine($"Player was successfuly added with ID {p.PlayerId}");
                Console.WriteLine("Press any key to go back....");
                Console.ReadKey();

            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }



        }
    }
}
