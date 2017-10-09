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
        List<Case> voisines = new List<Case>();
        public void Connecter(Case c)
        {
            voisines.Add(c);
        }
    }
}
}
