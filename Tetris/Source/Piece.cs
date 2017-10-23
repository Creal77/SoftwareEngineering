using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Piece : Grid
    {
        public int x = 0, y = 0;
        public char[,] blocks { get; set; }

        public Piece(String grid)
        {
            String[] subGrid = grid.Split('\n');
            x = subGrid[0].Length;
            y = subGrid.Length - 1;
            blocks = new char[x, y];
            for (int row = 0; row < y; row++)
            {
                for (int col = 0; col < x; col++)
                {
                    blocks[col, row] = subGrid[row][col];
                }
            }
        }

        public override String ToString()
        {
            String grid = "";
            for (int row = 0; row < y; row++)
            {
                for (int col = 0; col < x; col++)
                {
                    grid += blocks[col, row];
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
