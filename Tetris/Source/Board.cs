using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Board
    {
        readonly int rows;
        readonly int columns;
        MovableGrid[,] blocks;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            blocks = new MovableGrid[columns, rows];
            for (int col = 0; col < columns; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    blocks[col, row] = null;
                }
            }
        }

        public override String ToString()
        {
            String s = "";
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (blocks[col, row] != null)
                    {
                        s += blocks[col, row].Representation.CellAt(0,0);
                    }
                    else
                    {
                        s += ".";
                    }
                }
                s += "\n";
            }
            return s;
        }

        public bool IsFallingBlock()
        {
            for (int col = 0; col < columns; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    if (blocks[col, row] != null && (blocks[col, row]).Falling)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Drop(Grid shape)
        {
            MovableGrid block = new MovableGrid(shape);
            if (IsFallingBlock())
            {
                throw new ArgumentException("A block is already falling.");
            }
            if (blocks[columns / 2, 0] == null)
            {
                blocks[columns / 2, 0] = block;
            }
        }

        public void Tick()
        {
            for (int col = 0; col < columns; col++)
            {
                for (int row = rows - 1; row > 0; row--)
                {
                    if (blocks[col, row] == null)
                    {
                        blocks[col, row] = blocks[col, row - 1];
                        blocks[col, row - 1] = null;
                    }
                    else
                    {
                        blocks[col, row].Falling = false;
                    }
                }
            }
        }
    }
}
