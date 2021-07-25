using System;
using System.Collections.Generic;
using System.Text;

namespace pushka2000
{
    class Card
    {
        private string rus;
        private string eng;

        public string Rus
        {
            get => rus;
            set { rus = value; }

        }
        public string Eng
        {
            get => eng;
            set { eng = value; }

        }
        public Card()
        {
            rus = null;
            eng = null;
        }
        public Card(string Rus, string Eng)
        {
            this.eng = Eng;
            this.rus = Rus;
        }

    }
}
