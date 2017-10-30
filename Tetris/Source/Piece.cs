using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Piece : Grid
    {
        public int rows, columns;
        public char[,] blocks { get; set; }

        public Piece(String grid)
        {
            string[] tmp = grid.Split('\n');
            rows = tmp.Length - 1;
            columns = tmp[0].Length;
            blocks = new char[rows, columns];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    blocks[i, j] = tmp[i][j];
        }

        public override String ToString()
        {
            string grid = "";
            for (int i = 0; i < Rows(); i++)
            {
                for (int j = 0; j < Columns(); j++)
                {
                    grid += blocks[i, j];
                }
                grid += '\n';
            }
            return grid;
        }

        public char CellAt(int row, int col)
        {
            return blocks[row, col];
        }

        public int Columns()
        {
            return blocks.GetLength(1);
        }

        public int Rows()
        {
            return blocks.GetLength(0);
        }
    }
}
