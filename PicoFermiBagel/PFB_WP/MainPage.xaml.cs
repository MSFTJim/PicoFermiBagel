using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PicoFermiBagel.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Windows.Phone.Devices.Notification;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using PFBRoot;
using Microsoft.Phone.Tasks;


namespace PicoFermiBagel
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor

        public int GuessNumber;
        public bool SwipeUp;
        public bool GameOver;
        public string PriorGuessAny;
        public Boolean BadGuess;
        public int CurrentGuess1;
        public int CurrentGuess2;
        public int CurrentGuess3;
        public int Answer1;
        public int Answer2;
        public int Answer3;     
        public string CurrentGuessImage1;
        public string CurrentGuessImage2;
        public string CurrentGuessImage3;
        public System.Windows.Point StartingPoint, EndingPoint;
        Random rnd = new Random();
        bool CheckBox0Checked = false;
        bool CheckBox1Checked = false;
        bool CheckBox2Checked = false;
        bool CheckBox3Checked = false;
        bool CheckBox4Checked = false;
        bool CheckBox5Checked = false;
        bool CheckBox6Checked = false;
        bool CheckBox7Checked = false;
        bool CheckBox8Checked = false;
        bool CheckBox9Checked = false;
        SoundEffect SwipeUpSoundEffect;
        SoundEffect SwipeDownSoundEffect;
        Stream SwipeUpStream;
        Stream SwipeDownStream;
        
        
            

            
        public MainPage()
        {
            InitializeComponent();


            // Add handler for the Manipulation Started & Completed event           
            SpinningWheelGuess1.ManipulationStarted +=
                new EventHandler<ManipulationStartedEventArgs>(SpinningWheel1_ManipulationStarted);            
            SpinningWheelGuess1.ManipulationCompleted +=
                new EventHandler<ManipulationCompletedEventArgs>(SpinningWheel1_ManipulationCompleted);

            SpinningWheelGuess2.ManipulationStarted +=
                new EventHandler<ManipulationStartedEventArgs>(SpinningWheel2_ManipulationStarted);
            SpinningWheelGuess2.ManipulationCompleted +=
                new EventHandler<ManipulationCompletedEventArgs>(SpinningWheel2_ManipulationCompleted);

            SpinningWheelGuess3.ManipulationStarted +=
                           new EventHandler<ManipulationStartedEventArgs>(SpinningWheel3_ManipulationStarted);
            SpinningWheelGuess3.ManipulationCompleted +=
                            new EventHandler<ManipulationCompletedEventArgs>(SpinningWheel3_ManipulationCompleted);

         

            SwipeUpStream = TitleContainer.OpenStream("Assets/Woosh.wav");
            SwipeUpSoundEffect = SoundEffect.FromStream(SwipeUpStream);
            SwipeDownStream = TitleContainer.OpenStream("Assets/RVBCLICK.wav");
            SwipeDownSoundEffect = SoundEffect.FromStream(SwipeDownStream);
            FrameworkDispatcher.Update();

            StartGame();       
            
        }

        

        #region CheckBox DoubleTap      
        
        private void CheckBox0_DoubleTap(object sender, GestureEventArgs e)
        {
            if (CheckBox0Checked)
            { CheckBox0.Source = new BitmapImage(new Uri("Assets/UnChecked0.png", UriKind.Relative)); CheckBox0Checked = false; }
            else
            { CheckBox0.Source = new BitmapImage(new Uri("Assets/Checked0.png", UriKind.Relative)); CheckBox0Checked = true; }
         }
        private void CheckBox1_DoubleTap(object sender, GestureEventArgs e)
        {
            if (CheckBox1Checked)
            { CheckBox1.Source = new BitmapImage(new Uri("Assets/UnChecked1.png", UriKind.Relative)); CheckBox1Checked = false; }
            else
            { CheckBox1.Source = new BitmapImage(new Uri("Assets/Checked1.png", UriKind.Relative)); CheckBox1Checked = true; }
        }
        private void CheckBox2_DoubleTap(object sender, GestureEventArgs e)
        {
            if (CheckBox2Checked)
            { CheckBox2.Source = new BitmapImage(new Uri("Assets/UnChecked2.png", UriKind.Relative)); CheckBox2Checked = false; }
            else
            { CheckBox2.Source = new BitmapImage(new Uri("Assets/Checked2.png", UriKind.Relative)); CheckBox2Checked = true; }
        }
        private void CheckBox3_DoubleTap(object sender, GestureEventArgs e)
        {
            if (CheckBox3Checked)
            { CheckBox3.Source = new BitmapImage(new Uri("Assets/UnChecked3.png", UriKind.Relative)); CheckBox3Checked = false; }
            else
            { CheckBox3.Source = new BitmapImage(new Uri("Assets/Checked3.png", UriKind.Relative)); CheckBox3Checked = true; }
        }
        private void CheckBox4_DoubleTap(object sender, GestureEventArgs e)
        {
            if (CheckBox4Checked)
            { CheckBox4.Source = new BitmapImage(new Uri("Assets/UnChecked4.png", UriKind.Relative)); CheckBox4Checked = false; }
            else
            { CheckBox4.Source = new BitmapImage(new Uri("Assets/Checked4.png", UriKind.Relative)); CheckBox4Checked = true; }
        }
        private void CheckBox5_DoubleTap(object sender, GestureEventArgs e)
        {
            if (CheckBox5Checked)
            { CheckBox5.Source = new BitmapImage(new Uri("Assets/UnChecked5.png", UriKind.Relative)); CheckBox5Checked = false; }
            else
            { CheckBox5.Source = new BitmapImage(new Uri("Assets/Checked5.png", UriKind.Relative)); CheckBox5Checked = true; }
        }
        private void CheckBox6_DoubleTap(object sender, GestureEventArgs e)
        {
            if (CheckBox6Checked)
            { CheckBox6.Source = new BitmapImage(new Uri("Assets/UnChecked6.png", UriKind.Relative)); CheckBox6Checked = false; }
            else
            { CheckBox6.Source = new BitmapImage(new Uri("Assets/Checked6.png", UriKind.Relative)); CheckBox6Checked = true; }
        }
        private void CheckBox7_DoubleTap(object sender, GestureEventArgs e)
        {
            if (CheckBox7Checked)
            { CheckBox7.Source = new BitmapImage(new Uri("Assets/UnChecked7.png", UriKind.Relative)); CheckBox7Checked = false; }
            else
            { CheckBox7.Source = new BitmapImage(new Uri("Assets/Checked7.png", UriKind.Relative)); CheckBox7Checked = true; }
        }
        private void CheckBox8_DoubleTap(object sender, GestureEventArgs e)
        {
            if (CheckBox8Checked)
            { CheckBox8.Source = new BitmapImage(new Uri("Assets/UnChecked8.png", UriKind.Relative)); CheckBox8Checked = false; }
            else
            { CheckBox8.Source = new BitmapImage(new Uri("Assets/Checked8.png", UriKind.Relative)); CheckBox8Checked = true; }
        }
        private void CheckBox9_DoubleTap(object sender, GestureEventArgs e)
        {
            if (CheckBox9Checked)
            { CheckBox9.Source = new BitmapImage(new Uri("Assets/UnChecked9.png", UriKind.Relative)); CheckBox9Checked = false; }
            else
            { CheckBox9.Source = new BitmapImage(new Uri("Assets/Checked9.png", UriKind.Relative)); CheckBox9Checked = true; }
        }
        #endregion  // checkbox doubletap

        void StartGame()
        {   
            //Image.Visibility = Visibility.Hidden;
            LayoutYouLost.Visibility = Visibility.Collapsed;
            LayoutYouWon.Visibility = Visibility.Collapsed;
            
            Explode.Stop();
            Winner.Stop();
           
            Answer1 = GetRandomInt(0, 9);
            Answer2 = GetRandomInt(0, 9);
            Answer3 = GetRandomInt(0, 9);
            //Answer1 = 3;
            //Answer2 = 1;
            //Answer3 = 3;

            CheckBox0Checked = false;
            CheckBox0.Source = new BitmapImage(new Uri("Assets/UnChecked0.png", UriKind.Relative));
            CheckBox1Checked = false;
            CheckBox1.Source = new BitmapImage(new Uri("Assets/UnChecked1.png", UriKind.Relative)); 
            CheckBox2Checked = false;
            CheckBox2.Source = new BitmapImage(new Uri("Assets/UnChecked2.png", UriKind.Relative)); 
            CheckBox3Checked = false;
            CheckBox3.Source = new BitmapImage(new Uri("Assets/UnChecked3.png", UriKind.Relative)); 
            CheckBox4Checked = false;
            CheckBox4.Source = new BitmapImage(new Uri("Assets/UnChecked4.png", UriKind.Relative)); 
            CheckBox5Checked = false;
            CheckBox5.Source = new BitmapImage(new Uri("Assets/UnChecked5.png", UriKind.Relative)); 
            CheckBox6Checked = false;
            CheckBox6.Source = new BitmapImage(new Uri("Assets/UnChecked6.png", UriKind.Relative)); 
            CheckBox7Checked = false;
            CheckBox7.Source = new BitmapImage(new Uri("Assets/UnChecked7.png", UriKind.Relative)); 
            CheckBox8Checked = false;
            CheckBox8.Source = new BitmapImage(new Uri("Assets/UnChecked8.png", UriKind.Relative)); 
            CheckBox9Checked = false;
            CheckBox9.Source = new BitmapImage(new Uri("Assets/UnChecked9.png", UriKind.Relative)); 
            GuessNumber = 1;
            SwipeUp = false;
            GameOver = false;
            PriorGuessAny = "?";
            BadGuess = false;

            CurrentGuess1 = GetRandomInt(0, 9);
            //CurrentGuess1 = 3;
            CurrentGuessImage1 = "/Assets/Swipe" + CurrentGuess1 + ".png";
            SpinningWheelGuess1.Source = new BitmapImage(new Uri(CurrentGuessImage1, UriKind.Relative));

            CurrentGuess2 = GetRandomInt(0, 9);
            //CurrentGuess2 = 3;
            CurrentGuessImage2 = "/Assets/Swipe" + CurrentGuess2 + ".png";
            SpinningWheelGuess2.Source = new BitmapImage(new Uri(CurrentGuessImage2, UriKind.Relative));

            CurrentGuess3 = GetRandomInt(0, 9);
            //CurrentGuess3 = 3;
            CurrentGuessImage3 = "/Assets/Swipe" + CurrentGuess3 + ".png";
            SpinningWheelGuess3.Source = new BitmapImage(new Uri(CurrentGuessImage3, UriKind.Relative));

            MakeGuess.IsEnabled = true;
            Guess1_1.Text = "?";
            Guess1_2.Text = "?";
            Guess1_3.Text = "?";
            Guess1Grade.Text = "???";
            Guess2_1.Text = "?";
            Guess2_2.Text = "?";
            Guess2_3.Text = "?";
            Guess2Grade.Text = "???";
            Guess3_1.Text = "?";
            Guess3_2.Text = "?";
            Guess3_3.Text = "?";
            Guess3Grade.Text = "???";
            Guess4_1.Text = "?";
            Guess4_2.Text = "?";
            Guess4_3.Text = "?";
            Guess4Grade.Text = "???";
            Guess5_1.Text = "?";
            Guess5_2.Text = "?";
            Guess5_3.Text = "?";
            Guess5Grade.Text = "???";
            Guess6_1.Text = "?";
            Guess6_2.Text = "?";
            Guess6_3.Text = "?";
            Guess6Grade.Text = "???";
            Guess7_1.Text = "?";
            Guess7_2.Text = "?";
            Guess7_3.Text = "?";
            Guess7Grade.Text = "???";
            Guess8_1.Text = "?";
            Guess8_2.Text = "?";
            Guess8_3.Text = "?";
            Guess8Grade.Text = "???";
            Guess9_1.Text = "?";
            Guess9_2.Text = "?";
            Guess9_3.Text = "?";
            Guess9Grade.Text = "???";
            Guess10_1.Text = "?";
            Guess10_2.Text = "?";
            Guess10_3.Text = "?";
            Guess10Grade.Text = "???";

            //Guess10_1.Text = Answer1.ToString();
            //Guess10_2.Text = Answer2.ToString();
            //Guess10_3.Text = Answer3.ToString();            
        
        }

        void SpinningWheel1_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            // Starting Position 
            StartingPoint = e.ManipulationOrigin;            
        }
        void SpinningWheel2_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            // Starting Position 
            StartingPoint = e.ManipulationOrigin;
        }
        void SpinningWheel3_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            // Starting Position 
            StartingPoint = e.ManipulationOrigin;
        }

        void SpinningWheel1_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {   // Ending Position  
            EndingPoint = e.ManipulationOrigin;
            SwipeDirection(ref CurrentGuess1, ref CurrentGuessImage1, ref SpinningWheelGuess1);            
        }
        void SpinningWheel2_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {   // Ending Position  
            EndingPoint = e.ManipulationOrigin;
            SwipeDirection(ref CurrentGuess2, ref CurrentGuessImage2, ref SpinningWheelGuess2);
        }
        void SpinningWheel3_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {   // Ending Position  
            EndingPoint = e.ManipulationOrigin;
            SwipeDirection(ref CurrentGuess3, ref CurrentGuessImage3, ref SpinningWheelGuess3);
        }

        private void SwipeDirection(ref int CurrentGuessX, ref string CurrentGuessImageX, ref Image SpinningWheelGuessX)
        {    
            if (EndingPoint.Y < StartingPoint.Y)  // Swipe up
            {
                if (CurrentGuessX == 9)
                    CurrentGuessX = 0;
                else
                    CurrentGuessX++;
                SwipeUp = true;
            }
            else
            {
                if (CurrentGuessX == 0)
                    CurrentGuessX = 9;
                else
                    CurrentGuessX--;
                SwipeUp = false;
            }

            CurrentGuessImageX = "/Assets/Swipe" + CurrentGuessX + ".png";
            SpinningWheelGuessX.Source = new BitmapImage(new Uri(CurrentGuessImageX, UriKind.Relative));            

            if (SwipeUp)
            {                             
                if (App.pubGameSoundEffects)
                    SwipeUpSoundEffect.Play();
            }
            else
            {
                if (App.pubGameSoundEffects)                       
                    SwipeDownSoundEffect.Play();
            }            
        }

        string GradeGuess()
        { // first grading logic
            string GradetoReturn = "???";
            
            // Default everyone to Bagel.
            int Grade = 0;
            Boolean OKtoGrade1 = true;
            Boolean OKtoGrade2 = true;
            Boolean OKtoGrade3 = true;
            Boolean A1OKtoUse = true;
            Boolean A2OKtoUse = true;
            Boolean A3OKtoUse = true; 

            // Check for Fermi's to start.  They get precedence
            if (Answer1 == CurrentGuess1)
            { Grade += 4; OKtoGrade1 = false; A1OKtoUse = false; };            
            if (Answer2 == CurrentGuess2)
            { Grade += 4; OKtoGrade2 = false; A2OKtoUse = false; };
            if (Answer3 == CurrentGuess3)
            { Grade += 4; OKtoGrade3 = false; A3OKtoUse = false; };

            if (Grade < 8) // if Grade is 8 or greater, there can be no Pico's
            {
                // Check for Pico's next.
                if (A1OKtoUse)
                    if (Answer1 == CurrentGuess2 & OKtoGrade2)
                        { Grade++; OKtoGrade2 = false; A1OKtoUse = false; }
                    else
                        if (Answer1 == CurrentGuess3 & OKtoGrade3)
                        { Grade++; OKtoGrade3 = false; A1OKtoUse = false; }

                if (A2OKtoUse)
                    if (Answer2 == CurrentGuess1 & OKtoGrade1)
                        { Grade++; OKtoGrade1 = false; A2OKtoUse = false; }
                    else
                        if (Answer2 == CurrentGuess3 & OKtoGrade3)
                        { Grade++; OKtoGrade3 = false; A2OKtoUse = false; }

                if (A3OKtoUse)
                    if (Answer3 == CurrentGuess2 & OKtoGrade2)
                        Grade++;
                    else
                        if (Answer3 == CurrentGuess1 & OKtoGrade1)
                            Grade++;
            } // end if less than 8

            switch (Grade)
            {
                case 0:  // ALL WRONG
                    GradetoReturn = "BBB";
                    break;
                case 1: // ONE RIGHT NUMBER, WRONG SPOT
                    GradetoReturn = "PBB";
                    break;
                case 2: // TWO RIGHT NUMBERS, BOTH WRONG SPOTS
                    GradetoReturn = "PPB";
                    break;
                case 3: // ALL RIGHT NUMBERS, ALL WRONG SPOTS
                    GradetoReturn = "PPP";
                    break;
                case 4: // ONE RIGHT NUMBER IN RIGHT SPOT
                    GradetoReturn = "FBB";
                    break;
                case 5: // ONE RIGHT NUMBER IN RIGHT SPOT, A 2ND RIGHT NUMBER BUT IN WRONG SPOT
                    GradetoReturn = "FPB";
                    break;
                case 6: // ALL RIGHT NUMBERS, ONE IN RIGHT SPOT
                    GradetoReturn = "FPP";
                    break;
                case 8: // TWO RIGHT NUMBERS, BOTH IN WRONG SPOTS
                    GradetoReturn = "FFB";
                    break;
                case 12: // ALL NUMBERS CORRECT
                    GradetoReturn = "FFF";
                    break;
                default:
                    GradetoReturn = "XXX";
                    break;

            }

            return GradetoReturn;

        }

        private void RecordGuess(string TheAnswer)
        {
            switch (GuessNumber)
            {
                case 1:
                    Guess1_1.Text = CurrentGuess1.ToString();
                    Guess1_2.Text = CurrentGuess2.ToString();
                    Guess1_3.Text = CurrentGuess3.ToString();
                    Guess1Grade.Text = TheAnswer;
                    break;
                case 2:
                    Guess2_1.Text = CurrentGuess1.ToString();
                    Guess2_2.Text = CurrentGuess2.ToString();
                    Guess2_3.Text = CurrentGuess3.ToString();
                    Guess2Grade.Text = TheAnswer;
                    break;
                case 3:
                    Guess3_1.Text = CurrentGuess1.ToString();
                    Guess3_2.Text = CurrentGuess2.ToString();
                    Guess3_3.Text = CurrentGuess3.ToString();
                    Guess3Grade.Text = TheAnswer;
                    break;
                case 4:
                    Guess4_1.Text = CurrentGuess1.ToString();
                    Guess4_2.Text = CurrentGuess2.ToString();
                    Guess4_3.Text = CurrentGuess3.ToString();
                    Guess4Grade.Text = TheAnswer;
                    break;
                case 5:
                    Guess5_1.Text = CurrentGuess1.ToString();
                    Guess5_2.Text = CurrentGuess2.ToString();
                    Guess5_3.Text = CurrentGuess3.ToString();
                    Guess5Grade.Text = TheAnswer;
                    break;
                case 6:
                    Guess6_1.Text = CurrentGuess1.ToString();
                    Guess6_2.Text = CurrentGuess2.ToString();
                    Guess6_3.Text = CurrentGuess3.ToString();
                    Guess6Grade.Text = TheAnswer;
                    break;
                case 7:
                    Guess7_1.Text = CurrentGuess1.ToString();
                    Guess7_2.Text = CurrentGuess2.ToString();
                    Guess7_3.Text = CurrentGuess3.ToString();
                    Guess7Grade.Text = TheAnswer;
                    break;
                case 8:
                    Guess8_1.Text = CurrentGuess1.ToString();
                    Guess8_2.Text = CurrentGuess2.ToString();
                    Guess8_3.Text = CurrentGuess3.ToString();
                    Guess8Grade.Text = TheAnswer;
                    break;
                case 9:
                    Guess9_1.Text = CurrentGuess1.ToString();
                    Guess9_2.Text = CurrentGuess2.ToString();
                    Guess9_3.Text = CurrentGuess3.ToString();
                    Guess9Grade.Text = TheAnswer;
                    break;
                case 10:                    
                    Guess10_1.Text = CurrentGuess1.ToString();
                    Guess10_2.Text = CurrentGuess2.ToString();
                    Guess10_3.Text = CurrentGuess3.ToString();
                    Guess10Grade.Text = TheAnswer;
                    break;
                case 11:
                    MessageBox.Show("Game Over!  Please Try a new game or exit.  Thank you!!");
                    break;
                case 12:
                    MessageBox.Show("Opps!  You pressed the Make guess button but the game is over!!");
                    break;
                case 13:
                    MessageBox.Show("You can keep pressing but it won't help!!");
                    GameOver = true;
                    MakeGuess.IsEnabled = false;
                    break;
                default:
                    MessageBox.Show("Boo in Case!!");
                    break;
            }
        }
        private void MakeGuess_Click(object sender, RoutedEventArgs e)
        {
            string CurrentAnswer;

            if (App.pubPFBLicenseType == App.PFBLicenseModes.TrialExpiredMissingRevoked)
              {                
                MessageBoxResult result;
                result = MessageBox.Show("Thank you for playing but your free trial has ended.  Please press OK to visit the Store and purchase the full version.", "Trial Has Ended", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {   MarketplaceDetailTask marketplaceDetailTask = new MarketplaceDetailTask();
                    marketplaceDetailTask.ContentType = MarketplaceContentType.Applications;
                    marketplaceDetailTask.Show();                    
                }

            }
            else
            {
                CurrentAnswer = GradeGuess();

                RecordGuess(CurrentAnswer);

                if (GuessNumber == 10 || CurrentAnswer == "FFF")
                {
                    CurrentGuess1 = Answer1;
                    CurrentGuessImage1 = "/Assets/Swipe" + CurrentGuess1 + ".png";
                    SpinningWheelGuess1.Source = new BitmapImage(new Uri(CurrentGuessImage1, UriKind.Relative));

                    CurrentGuess2 = Answer2;
                    CurrentGuessImage2 = "/Assets/Swipe" + CurrentGuess2 + ".png";
                    SpinningWheelGuess2.Source = new BitmapImage(new Uri(CurrentGuessImage2, UriKind.Relative));

                    CurrentGuess3 = Answer3;
                    CurrentGuessImage3 = "/Assets/Swipe" + CurrentGuess3 + ".png";
                    SpinningWheelGuess3.Source = new BitmapImage(new Uri(CurrentGuessImage3, UriKind.Relative));

                    if (CurrentAnswer == "FFF")
                    {
                        //MessageBox.Show("Congratulations!!.  You guessed the right numbers within 10 tries!!"); 
                        LayoutYouWon.Visibility = Visibility.Visible;
                        Winner.Begin();
                        GuessNumber = 10;

                    }
                    else
                    {
                        LayoutYouLost.Visibility = Visibility.Visible;
                        Explode.Begin();
                        VibrationDevice pfbVibrationonLoss = VibrationDevice.GetDefault();
                        pfbVibrationonLoss.Vibrate(TimeSpan.FromSeconds(1));
                        GuessNumber = 10;
                    }

                    GameOver = true;
                    MakeGuess.IsEnabled = false;
                }


                GuessNumber++;
            } // end if/then/else of license check

        }

        protected int GetRandomInt(int min, int max)
        {
            return rnd.Next(min, max);
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

       

        private void HowToPlay_Click(object sender, EventArgs e)
        {            
            NavigationService.Navigate(new Uri("/HowtoPlay.xaml", UriKind.Relative));
        }

        private void GameSettings_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/GameSettings.xaml", UriKind.Relative));
        }

        private void PFBAbout_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void PFBLicense_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/LicenseInfo.xaml", UriKind.Relative));
                  

        }
        
        private void LayoutYouLost_DoubleTap(object sender, GestureEventArgs e)
        {
            Explode.Stop();
            LayoutYouLost.Visibility = Visibility.Collapsed;
        }

        private void LayoutYouWon_DoubleTap(object sender, GestureEventArgs e)
        {
            Winner.Stop();
            LayoutYouWon.Visibility = Visibility.Collapsed;
        }

        
    }
}