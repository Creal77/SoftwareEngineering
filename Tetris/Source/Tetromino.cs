using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Tetromino
    {
        List<String> positions;
        public String Position { get; set; }
        int index;

        public Tetromino(String args1, String args2, String args3, String args4)
        {
            index = 0;
            positions = new List<String>();
            positions.Add(args1);
            positions.Add(args2);
            positions.Add(args3);
            positions.Add(args4);
            Position = positions[index];
        }

        public void RotateRight()
        {
            index++;
            if (index == positions.Count)
            {
                index = 0;
            }
            Position = positions[index];
        }

        public void RotateLeft()
        {
            index--;
            if (index == -1)
            {
                index = positions.Count - 1;
            }
            Position = positions[index];
        }
    }
}
