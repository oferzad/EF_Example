using System;
using System.Collections.Generic;
using System.Text;
using EF_Example.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EF_Example.UI
{
    class MainMenu:Menu
    {
        public MainMenu() : base($"Main Menu")
        {
            //Build items in main menu!
            AddItem("Show Players", new PlayersListScreen());
            AddItem("Add Player", new AddPlayerScreen());
        }

        
    }
}
