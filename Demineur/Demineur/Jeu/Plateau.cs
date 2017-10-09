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
        public Case[,] cases;
        int mines, decouvertes, restantes;

        public Plateau(Partie partie, int largeur, int hauteur, int mines)
        {
            Random rnd = new Random();
            this.partie = partie;
            this.largeur = largeur;
            this.hauteur = hauteur;
            this.mines = mines;
            restantes = mines;
            cases = new Case[largeur, hauteur];
            for (int x = 0; x < largeur; x++)
            {
                for (int y = 0; y < hauteur; y++)
                {
                    cases[x, y] = new Case(this, x, y);
                    int N = hauteur - 1;
                    if (x > 0 && y > 0) Connecter(cases[x, y], cases[x - 1, y - 1]);
                    if (x > 0) Connecter(cases[x, y], cases[x - 1, y]);
                    if (y > 0) Connecter(cases[x, y], cases[x, y - 1]);
                    if (x > 0 && y < N) Connecter(cases[x, y], cases[x - 1, y + 1]);
                }
            }
            for (int i = 0; i < mines; i++)
            {
                cases[rnd.Next(0, largeur), rnd.Next(0, hauteur)].minee = true;
            }
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
        void Connecter(Case a, Case b)
        {
            a.Connecter(b);
            b.Connecter(a);
        }
    }
}
