using System;
using System.Collections.Generic;
using System.Text;
using EF_Example.Models;

namespace EF_Example.UI
{
    class UIMain
    {
        //UI Main object is perfect for storing all UI state as it is initialized first and detroyed last.
        
        private Screen initialScreen;
        public UIMain(Screen initial)
        {
            this.initialScreen = initial;
        }
        public void ApplicationStart()
        {
            //Show Screen and start app!
            initialScreen.Show();
        }
    }
}
