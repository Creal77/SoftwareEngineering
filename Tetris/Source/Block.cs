using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Block
    {
        public char Representation { get; set; }
        public bool Falling { get; set; }

        public Block(char representation)
        {
            Representation = representation;
            Falling = true;
        }
    }
}
