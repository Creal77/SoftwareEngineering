using Jeu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demineur.Jeu
{
    class Plateau
    {
        public Partie partie;
        public int largeur;
        public int hauteur;
        Case[,] cases;
        int mines, decouvertes, restantes;

        public Plateau(Partie partie, int largeur, int longueur, int mines)
        {

        }

        public Case Trouver(int x, int y)
        {
            return cases[x, y];
        }
        public void IncrementerDecouvertes()
        {
            decouvertes++;
        }
        public void ModifierMarquees(bool marquee)
        {
            if (marquee) restantes--; else restantes++;
            partie.vue.ActualiserComptage(restantes);
        }
        public bool TesterSiGagne()
        {
            return decouvertes + mines == largeur * hauteur;
        }
    }
}
