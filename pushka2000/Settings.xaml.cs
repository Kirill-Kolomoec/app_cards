using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace pushka2000
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }


        private void button_Add_Card_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter file = new StreamWriter("cards.txt", true))
            {

                file.WriteLine($"{Box_Rus.Text} {Box_Eng.Text}");

            }
            CardArray.cards.Add(new Card(Box_Rus.Text, Box_Eng.Text));
            Box_Eng.Visibility = Visibility.Hidden;
            Box_Rus.Visibility = Visibility.Hidden;
            button_Add_Card.Visibility = Visibility.Hidden;
            label_Eng.Visibility = Visibility.Hidden;
            label_Rus.Visibility =Visibility.Hidden;
            MessageBox.Show("Card was added");
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            Box_Eng.Visibility = Visibility.Visible;
            Box_Rus.Visibility = Visibility.Visible;
            button_Add_Card.Visibility = Visibility.Visible;
            label_Eng.Visibility = Visibility.Visible;
            label_Rus.Visibility = Visibility.Visible;
        }

        private void button_Edit_Click(object sender, RoutedEventArgs e)
        {
            find_box.Visibility = Visibility.Visible;
            button_find.Visibility = Visibility.Visible;
            label_find.Visibility = Visibility.Visible;
        }

        private void button_find_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader("cards.txt"))
            {
                string subString = find_box.Text;

                if (CardArray.FindRus(subString).resalt == false)
                {
                    MessageBox.Show("There is no such word, enter another one.");
                }
                else
                {
                    new_word_Box.Visibility = System.Windows.Visibility.Visible;
                    new_word_label.Visibility = System.Windows.Visibility.Visible;
                    button_edit_card.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }

        private void button_edit_card_Click(object sender, RoutedEventArgs e)
        {
            string tmp;

            using (StreamReader sr = new StreamReader(@"cards.txt"))
            {
                tmp = sr.ReadToEnd();
                tmp=tmp.Replace(CardArray.cards[CardArray.FindRus(find_box.Text).index].Eng, new_word_Box.Text);   
            }

            using (StreamWriter file = new StreamWriter(@"cards.txt"))
            {
                file.Write(tmp);
            }

            CardArray.cards[CardArray.FindRus(find_box.Text).index].Eng = new_word_Box.Text;

            new_word_Box.Visibility = System.Windows.Visibility.Hidden;
            new_word_label.Visibility = System.Windows.Visibility.Hidden;
            button_edit_card.Visibility = System.Windows.Visibility.Hidden;
            find_box.Visibility = System.Windows.Visibility.Hidden;
            button_find.Visibility = System.Windows.Visibility.Hidden;
            label_find.Visibility = System.Windows.Visibility.Hidden;
        }

        private void button_Delete_Click(object sender, RoutedEventArgs e)
        {
            find_box.Visibility = System.Windows.Visibility.Visible;
            button_delete_card.Visibility = System.Windows.Visibility.Visible;
            label_find.Visibility = System.Windows.Visibility.Visible;
        }

        private void button_delete_card_Click(object sender, RoutedEventArgs e)
        {

            if (CardArray.FindRus(find_box.Text).resalt == false)
            {
                MessageBox.Show("There is no such word, enter another one.");
            }
            else
            {
                CardArray.cards.RemoveAt(CardArray.FindRus(find_box.Text).index);

                using (StreamWriter file = new StreamWriter(@"cards.txt"))
                {
                    foreach (var item in CardArray.cards)
                    {
                        file.WriteLine($"{item.Rus} {item.Eng}");
                    }
                }
                MessageBox.Show("Card has been deleted successfully");

                find_box.Visibility = System.Windows.Visibility.Hidden;
                button_delete_card.Visibility = System.Windows.Visibility.Hidden;
                label_find.Visibility = System.Windows.Visibility.Hidden;
            }
            

           
        }
    }
}
