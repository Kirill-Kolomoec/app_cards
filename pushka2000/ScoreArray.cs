using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Diagnostics.CodeAnalysis;


namespace pushka2000
{
    class ScoreArray
    {
        public static List<Score> scores = new List<Score>();

        public static void FillArray()
        {
            scores.Clear();
            string path = @"scores.txt";
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                try
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        scores.Add(new Score(Int32.Parse(words[0]), words[2], words[1], words[3]));
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    sr.Close();
                }

            }

            NameComparer nc = new NameComparer();

            scores.Sort(nc);

        }
        public static string PrintArray()
        {
            string rezalt="";
            foreach (var item in scores)
            {
                rezalt += $"{item.Scor} {item.Date} {item.Time}\n";
            }

            return rezalt;
        }
    }


    class NameComparer : IComparer<Score>
    {  
        public int Compare([AllowNull] Score x, [AllowNull] Score y)
        {
            if (x.Scor > y.Scor)
            {
                return -1;
            }
            else if (x.Scor < y.Scor)
            {
                return 1;
            }

            return 0;
        }
    }
}





 