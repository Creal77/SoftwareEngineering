using Jeu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demineur.Jeu
{
    class Case
    {
        bool decouverte, drapeau;
        List<Case> voisines = new List<Case>();
        Plateau plateau;
        int x, y;
        public bool minee { get; set; }

        public Case(Plateau plateau, int x, int y)
        {
            this.plateau = plateau;
            decouverte = false;
            drapeau = false;
            minee = false;
            this.x = x;
            this.y = y;
        }

        public void Connecter(Case c)
        {
            voisines.Add(c);
        }

        public bool Decouvrir()
        {
            if (!decouverte)
            {
                if(drapeau)
                {
                    drapeau = false;
                    plateau.ModifierMarquees(drapeau);
                    plateau.partie.vue.MarquerCase(x, y, drapeau);
                }
                decouverte = true;
            }
            else
            {
                return false;
            }
            plateau.IncrementerDecouvertes();
            if (minee)
            {
                plateau.partie.vue.AfficherCaseMinee(x, y, minee);
                return true;
            }
            else
            {
                int num = 0;
                plateau.partie.vue.AfficherCaseNumerotee(x, y, num);
                foreach (Case cases in voisines)
                {
                    if (cases.minee)
                    {
                        num++;
                    }
                }
                foreach (Case cases in voisines)
                {
                    if (num == 0)
                    {
                        cases.Decouvrir();
                    }
                }
                plateau.partie.vue.AfficherCaseNumerotee(x, y, num);
                return false;
            }
        }

        public void Afficher()
        {
            decouverte = true;
        }

        public void Marquer()
        {
            if (!decouverte)
            {
                drapeau = drapeau ? false : true;
                plateau.ModifierMarquees(drapeau);
                plateau.partie.vue.MarquerCase(x, y, drapeau);
            }
        }
    }
}
