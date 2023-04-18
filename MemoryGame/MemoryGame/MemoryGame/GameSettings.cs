using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    public class GameSettings
    {
        public int CzasGry;
        public int CzasPodgladu;
        public int MaxPunkty;
        public int Wiersze;
        public int Kolumny;
        public int Bok;
        public int AktualnePunkty;
        public string PlikLogo = $@"{AppDomain.CurrentDomain.BaseDirectory}\img\logo.jpg";
        public string FolderoObrazki = $@"{AppDomain.CurrentDomain.BaseDirectory}\img\memory";
        public GameSettings ()
        {
            UstawStartowe();
        }
        public void UstawStartowe()
        {
            CzasGry = 60;
            CzasPodgladu = 5;
            MaxPunkty = 0;
            AktualnePunkty = 0;
            Wiersze = 4;
            Kolumny = 6;
            Bok = 150;
        }
    }
}
