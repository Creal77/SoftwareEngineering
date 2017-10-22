using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Piece : Grid
    {
        public int x, y;
        public char[,] blocks { get; set; }

        public Piece(String grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                if (grid[i] != '\n' && y == 0)
                {
                    x++;
                }
                if (grid[i] == '\n')
                {
                    y++;
                }
            }
            blocks = new char[x, y];
            for (int col = 0; col < x; col++)
            {
                for (int row = 0; row < y; row++)
                {
                    blocks[col, row] = '.';
                }
            }
        }

        public override String ToString()
        {
            String grid = "";
            for (int col = 0; col < x; col++)
            {
                for (int row = 0; row < y; row++)
                {
                    grid += '.';
                }
                grid += "\n";
            }
            return grid;
        }

        public char CellAt(int row, int col)
        {
            return blocks[col, row];
        }

        public int Columns()
        {
            return x;
        }

        public int Rows()
        {
            return y;
        }
    }
}
