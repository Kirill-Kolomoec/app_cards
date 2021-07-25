using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pushka2000
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int index = 0;
        private static int Score = 0;

        public MainWindow()
        {
            InitializeComponent();
            CardArray.FillArray();
            ScoreArray.FillArray();
            FillScore();
        }

        private void FillScore()
        {
            ScoreBlock.Text = ScoreArray.PrintArray();
        }
                
       

        private void button_Start_Click(object sender, RoutedEventArgs e)
        {
            index = 0;
            CardArray.FillArray();
            main_block.Text = CardArray.cards[index].Eng;
            
                try 
                {
                    if (CardArray.cards.Count >= Convert.ToInt32(Num_Cards_Box.Text) && Convert.ToInt32(Num_Cards_Box.Text) >= 1)
                    {
                        button_next.Visibility = System.Windows.Visibility.Visible;
                        main_block.Visibility = System.Windows.Visibility.Visible;
                        Cheсk_button.Visibility = System.Windows.Visibility.Visible;
                        Cheсk_Box.Visibility = System.Windows.Visibility.Visible;
                        Start.Visibility = System.Windows.Visibility.Hidden;
                        Num_Cards_Box.Visibility = System.Windows.Visibility.Hidden;
                        label.Visibility = System.Windows.Visibility.Hidden;
                        button_Start.Visibility = System.Windows.Visibility.Hidden;
                        Settings.Visibility = Visibility.Hidden;
                        ScoreBlock.Visibility = Visibility.Hidden;
                        Score_Label.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        MessageBox.Show($"Enter numbers in range from 1 to {CardArray.cards.Count}");  
                    }
                }
                catch (FormatException)
                {
                   MessageBox.Show($"Enter numbers in range from 1 to {CardArray.cards.Count}");
                }

            

        }

        private void Cheсk_button_Click(object sender, RoutedEventArgs e)
        {  
            if (CardArray.cards[index].Rus.ToLower() == Cheсk_Box.Text.ToLower())
            {
                Back.Background = Brushes.Green;
                Score++;
            }
            else
            {
                Back.Background = Brushes.Red;
            }
            Cheсk_button.IsEnabled = false;
            button_next.IsEnabled = true;
            
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if ( button_next.Content.Equals("Finish")  )
            {
                using (StreamWriter file = new StreamWriter("scores.txt", true))
                {
                    file.WriteLine($"{Score} {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
                }
                MessageBox.Show($"Your score is {Score}");

                MainWindow a = new MainWindow();
                this.Close();
                a.Show();             
            }
            else
            {
                if ((index + 2) == Convert.ToInt32(Num_Cards_Box.Text))
                {
                    button_next.Content = "Finish";
                }
                index++;
                Cheсk_button.IsEnabled = true;
                button_next.IsEnabled = false;
                Cheсk_Box.Clear();
                main_block.Text = CardArray.cards[index].Eng;
                Back.Background = Brushes.Gray;
            }        
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Settings a = new Settings();
            a.Show();
        }
    }


    

   
}
