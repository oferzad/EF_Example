using EF_Example.Models;
using EF_Example.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EF_Example
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //Change number 1
            //scaffold-DbContext "Server = (localdb)\MSSQLLocalDB; Database=GameHighScores; Trusted_Connection=True; TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models -Context HighScoresDbContext -DataAnnotations -force
            UIMain ui = new UIMain(new MainMenu());
            ui.ApplicationStart();
        }
    }
}