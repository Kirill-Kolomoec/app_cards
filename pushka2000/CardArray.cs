using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace pushka2000
{
    class CardArray
    {
        public static List<Card> cards = new List<Card>();

        public static void FillArray()
        {
            cards.Clear();
            string path = @"cards.txt";
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                try
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        cards.Add(new Card(words[0].ToLower(), words[1].ToLower()));
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    sr.Close();
                }

            }

        }

        public static (bool resalt, int index) FindRus(string Rus)
        {
            int index = 0;
            foreach (var item in cards)
            {
                if (item.Rus.ToLower() == Rus.ToLower())
                {
                    return (true, index);
                }
                index++;
            }

            return (false, -1);

        }
    }
}
