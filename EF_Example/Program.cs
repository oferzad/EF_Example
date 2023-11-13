using EF_Example.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EF_Example
{
    internal class Program
    {
        //SHow change tracker for debugging and learning purpuses
        static void ShowChangeTrackerObjects(HighScoresDbContext db)
        {
            db.ChangeTracker.DetectChanges();
            Console.WriteLine(db.ChangeTracker.DebugView.LongView);
        }

        //Deleting objects in database
        static void DeleteObjectsUsingChangeTracker()
        {
            HighScoresDbContext db = new HighScoresDbContext();

            Player p = new Player
            {
                Name = "Tobe Deleted",
                BirthYear = 2000,
            };

            db.Entry(p).State = EntityState.Added;
            db.SaveChanges();

            //Now delete the object
            db.Entry(p).State = EntityState.Deleted;
            db.SaveChanges();


        }

        //Updating existing objects in database
        static void UpdateObjectsUsingChangeTracker()
        {
            HighScoresDbContext db = new HighScoresDbContext();

            Player? p = db.Players.Where(pp => pp.Name == "Marom").FirstOrDefault();
            
            if (p != null)
            {
                p.Name = "Hadas";
                //The belolw state is done automatically as p is already tracked!
                //db.Entry(p).State = EntityState.Modified;
                ShowChangeTrackerObjects(db);
                db.SaveChanges();
            }
                
        }

        //Adding new nested objects to database
        static void AddNestedObjectsUsingAddOperation()
        {
            HighScoresDbContext db = new HighScoresDbContext();

            Player p = new Player
            {
                Name = "Nested PLayer Object",
                BirthYear = 200,
            };
            p.HighScores.Add(new HighScore()
            {
                GameId = 1,
                Score = 1000,
            });

            db.Players.Add(p);
            ShowChangeTrackerObjects(db);
            db.SaveChanges();
            Console.WriteLine(p.PlayerId);
        }

        static void AddNestedObjectsUsingChangeTracker()
        {
            HighScoresDbContext db = new HighScoresDbContext();

            Player p = new Player
            {
                Name = "Nested PLayer Object",
                BirthYear = 200,
            };
            p.HighScores.Add(new HighScore()
            {
                GameId = 1,
                Score = 1000,
            });

            //First add the player object and get player id from database
            db.Entry(p).State = EntityState.Added;
            db.SaveChanges();
            //now update all high score objects connected to the player with the generated player id
            foreach(HighScore h in  p.HighScores)
            {
                h.PlayerId = p.PlayerId;
                db.Entry(h).State = EntityState.Added;
            }
            //save changes again!
            db.SaveChanges();

        }


        //Adding new objects to database
        static void AddObjectsUsingChangeTracker()
        {
            HighScoresDbContext db = new HighScoresDbContext();

            Player p = new Player
            {
                Name = "Marom",
                BirthYear = 200,
            };

            db.Entry(p).State = EntityState.Added;
            ShowChangeTrackerObjects(db);
            db.SaveChanges();
            Console.WriteLine(p.PlayerId);
        }

        static void AddObjectsUsingAddOperation()
        {
            HighScoresDbContext db = new HighScoresDbContext();

            Player p = new Player
            {
                Name = "Marom",
                BirthYear = 200,
            };

            db.Players.Add(p);
            ShowChangeTrackerObjects(db);
            db.SaveChanges();
            Console.WriteLine(p.PlayerId);
        }


        //Show how to extrapulate navigation with eager loading
        static void ReadWithEagerLoading()
        {
            HighScoresDbContext db = new HighScoresDbContext();

            List<Player> players = db.Players.
                                      Include(p => p.HighScores).
                                      ThenInclude(h => h.Game).ToList();

            foreach (Player p in players)
            {
                Console.WriteLine(p.Name);
                Console.WriteLine(p.BirthYear);
                Console.WriteLine($"This PLayer has {p.HighScores.Count} High Scores:");
                foreach (HighScore highScore in p.HighScores)
                {
                    Console.WriteLine($"In Game: {highScore.Game.Name} High Score: {highScore.Score}");
                }
            }
        }

        //Show how to extrapulate navigation properties on demand
        static void ReadWithoutEagerLoading()
        {
            HighScoresDbContext db = new HighScoresDbContext();

            List<Player> players = db.Players.ToList();

            foreach (Player p in players)
            {
                Console.WriteLine(p.Name);
                Console.WriteLine(p.BirthYear);
                List<HighScore> highScores = db.HighScores.Where(h => h.PlayerId == p.PlayerId).ToList();
                Console.WriteLine($"This PLayer has {highScores.Count} High Scores:");
                foreach (HighScore highScore in highScores)
                {
                    Game? g = db.Games.Where(gg => gg.GameId == highScore.GameId).FirstOrDefault();
                    Console.WriteLine($"In Game: {g.Name} High Score: {highScore.Score}");
                }
            }
        }

        static void Main(string[] args)
        {

            //scaffold-DbContext "Server = (localdb)\MSSQLLocalDB; Database=GameHighScores; Trusted_Connection=True; TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models -Context HighScoresDbContext -DataAnnotations -force
            AddObjectsUsingAddOperation();
        }
    }
}