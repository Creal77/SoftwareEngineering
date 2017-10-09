using System;
using System.Collections.Generic;
using System.Text;
using IHM;
using Demineur.Jeu;

namespace Jeu
{
    public class Partie : IActions
    {
        Plateau p;
        bool gagnee;
        public IReactions vue
        {
            get; set;
        }

        public void CommencerPartie(int largeur, int hauteur, int mines)
        {
            p = new Plateau(this, largeur, hauteur, mines);
        }

        public void DecouvrirCase(int x, int y)
        {
            Case c = p.Trouver(x, y);
            if (c.Decouvrir())
            {
                vue.PartiePerdue();
                TerminerPartie();
            }
            else
            {
                bool gagnee = p.TesterSiGagne();
                if (gagnee)
                {
                    vue.PartieGagnee();
                    TerminerPartie();
                }
            }
        }

        public void MarquerCase(int x, int y)
        {
            Case c = p.Trouver(x, y);
            c.Marquer();
        }

        public void TerminerPartie()
        {
            foreach (Case cases in p.cases)
            {
                cases.Decouvrir();
            }
        }
    }
}
