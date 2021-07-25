using System;
using System.Collections.Generic;
using System.Text;

namespace pushka2000
{
    class Score
    {
        private int score;
        private string day;
        private string date;
        private string time;
        public Score(int score, string date, string day, string time)
        {
            this.score = score;
            this.day = day;
            this.date = date;
            this.time = time;

        }
        public int Scor
        {
            get => score;
            set { score = value; }

        }
        public string Date
        {
            get => date;
            set { date = value; }

        }
        public string Day
        {
            get => day;
            set { day = value; }

        }
        public string Time
        {
            get => time;
            set { time = value; }

        }
    }
}
