using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Form1 : Form
    {
        private GameSettings _settings;
        private MemoryCard pierwsza = null;
        private MemoryCard druga = null;
        private MemoryCard _pierwsza = null;
        private MemoryCard _druga = null;
        public Form1()
        {
            InitializeComponent();
            _settings = new GameSettings();
            UstawKontrolki();
            GenerujKarty();
            timerCzasPodgladu.Start();
        }
        private void UstawKontrolki ()
        {
            panelKart.Width = _settings.Bok * _settings.Kolumny;
            panelKart.Height = _settings.Bok * _settings.Wiersze;
            Width = panelKart.Width + 40;
            Height = panelKart.Height + 100;
            lblStartInfo.Text = $"Początek gry za {_settings.CzasPodgladu}.";
            lblPunktyWartosc.Text = _settings.AktualnePunkty.ToString();
            lblCzasWartosc.Text = _settings.CzasGry.ToString();

        }
        private void GenerujKarty()
        {
            string[] memories = Directory.GetFiles(_settings.FolderoObrazki);
            _settings.MaxPunkty = memories.Length;
            List<MemoryCard> buttons = new List<MemoryCard>();
            foreach (string img in memories)
            {
                Guid id = Guid.NewGuid();
                MemoryCard b1 = new MemoryCard(id, _settings.PlikLogo, img);
                buttons.Add(b1);
                MemoryCard b2 = new MemoryCard(id, _settings.PlikLogo, img);
                buttons.Add(b2);
            }
            Random random = new Random();
            panelKart.Controls.Clear();
            for (int x = 0; x < _settings.Kolumny; x++)
            {
                for (int y = 0; y < _settings.Wiersze; y++) {
                    int index = random.Next(0, buttons.Count);
                    MemoryCard b = buttons[index];
                    b.Location = new Point(x * _settings.Bok + 1, y * _settings.Bok + 1);
                    b.Width = _settings.Bok;
                    b.Height = _settings.Bok;
                    b.Odkryj();
                    b.Click += BtnClicked;
                    panelKart.Controls.Add(b);
                    buttons.Remove(b);
                }
            }
        }
        private void timerCzasPodgladu_Tick(object sender, EventArgs e)
        {
            _settings.CzasPodgladu--;
            lblStartInfo.Text = $"Początek gry za {_settings.CzasPodgladu}";
           
            if (_settings.CzasPodgladu <0)
            {
                timerCzasPodgladu.Stop();
                lblStartInfo.Visible = false;
                foreach(Control kontrolka in panelKart.Controls)
                {
                    MemoryCard card = (MemoryCard)kontrolka;
                    card.Zakryj();
                }
            }
            timerCzasGry.Start();
        }

        private void BtnClicked(object sender, EventArgs e)
        {
            MemoryCard btn = (MemoryCard)sender;
            if (_pierwsza == null)
            {
                _pierwsza = btn;
                _pierwsza.Odkryj();
            }
            else
            {
                _druga = btn;
                _druga.Odkryj();
                if (_pierwsza.ID == _druga.ID)
                {
                    _settings.AktualnePunkty++;
                    lblPunktyWartosc.Text = _settings.AktualnePunkty.ToString();
                    _pierwsza = null;
                    _druga = null;
                    panelKart.Enabled = true;
                } else
                {
                    timerZakrywacz.Start();
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TimerCzasPodgladu_Tick_1(object sender, EventArgs e)
        {

        }
    }
}
