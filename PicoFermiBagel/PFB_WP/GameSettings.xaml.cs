using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PFBRoot;

namespace PicoFermiBagel
{
    public partial class GameSettings : PhoneApplicationPage
    {
        public GameSettings()
        {
            InitializeComponent();

            if (App.pubGameSoundEffects)
                cbGameSoundEffects.IsChecked = true;
            else
                cbGameSoundEffects.IsChecked = false;

        }

        private void cbGameSoundEffects_Checked(object sender, RoutedEventArgs e)
        {            
            App.pubGameSoundEffects = true;
        }        

        private void cbGameSoundEffects_Unchecked(object sender, RoutedEventArgs e)
        {
            App.pubGameSoundEffects = false;
        }
    }
}