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
using System.Reflection;

namespace PicoFermiBagel
{
    public partial class LicenseInfo : PhoneApplicationPage
    {
        public LicenseInfo()
        {
            InitializeComponent();
            //App.PFB
            tbLicenseInfo.Text = "License Type: Unknown";
            tbTrialStart.Text = "";
            tbTrialEnd.Text = "";
            
            Version PFBversion = Assembly.GetExecutingAssembly().GetName().Version;
            tbPFBVersion.Text = "Game Version: " + PFBversion.ToString();


            if (App.pubPFBLicenseType == App.PFBLicenseModes.TrialExpiredMissingRevoked)
                tbLicenseInfo.Text = "License Type: Trial Expired";
            else
                if (App.pubPFBLicenseType == App.PFBLicenseModes.Trial)
                {                    
                    tbLicenseInfo.Text = "License Type: Trial, with " + App.pubTrialDaysLeft.ToString("0") + " days remaining";
                    tbTrialStart.Text = "Trial Start: " + App.pubTrialStart;
                    tbTrialEnd.Text = "Trial End: " + App.pubTrialEnd;                    
                }

                else
                    if (App.pubPFBLicenseType == App.PFBLicenseModes.Full)
                        tbLicenseInfo.Text = "License Type: Full";


        }
    }
}