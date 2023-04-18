using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{

    class MemoryCard : Label
    {
        public Image Tyl;
        public Image Obrazek;
        public Guid ID;
        public MemoryCard(Guid id, string tylKarty, string PrzodKarty)
        {
            ID = id;
            Tyl = Image.FromFile(tylKarty);
            Obrazek = Image.FromFile(PrzodKarty);
            BackgroundImageLayout = ImageLayout.Stretch;

        }
        public void Zakryj()
        {
            BackgroundImage = Tyl;
            Enabled = true;
        }
        public void Odkryj()
        {
            BackgroundImage = Obrazek;
            Enabled = true;
        }
    }
}
