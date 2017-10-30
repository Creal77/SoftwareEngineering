using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class MovableGrid : Grid
    {
        public Tetromino Representation { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public MovableGrid(Tetromino tetromino)
        {
            Representation = tetromino;
        }

        public MovableGrid(Tetromino tetromino, int x, int y)
        {
            Representation = tetromino;
            X = x;
            Y = y;
        }

        public int Rows()
        {
            return Representation.Rows();
        }

        public int Columns()
        {
            return Representation.Columns();
        }

        public char CellAt(int row, int col)
        {
            return Representation.CellAt(row, col);
        }

        public MovableGrid MoveTo(int x, int y)
        {
            return new MovableGrid(Representation, x, y);
        }

        public MovableGrid MoveDown()
        {
            return new MovableGrid(Representation, X, Y + 1);
        }

        public MovableGrid MoveLeft()
        {
            return new MovableGrid(Representation, X - 1, Y);
        }

        public MovableGrid MoveRight()
        {
            return new MovableGrid(Representation, X + 1, Y);
        }

        public MovableGrid RotateRight()
        {
            return new MovableGrid(Representation.RotateRight(), X, Y);
        }

        public MovableGrid RotateLeft()
        {
            return new MovableGrid(Representation.RotateLeft(), X, Y);
        }

        public bool Collision(char[,] matrix)
        {
            for (int i = 0; i < Rows(); i++)
            {
                for (int j = 0; j < Columns(); j++)
                {
                    if (X + j < 0 && CellAt(i, j) != '.')
                        return false;
                    else if (Y + i < 0 && CellAt(i, j) != '.')
                        return false;
                    else if (X + j > matrix.GetLength(1) - 1 && CellAt(i, j) != '.')
                        return false;
                    else if (Y + i > matrix.GetLength(0) - 1 && CellAt(i, j) != '.')
                        return false;
                    else if (Y + i <= matrix.GetLength(0) - 1 && X + j <= matrix.GetLength(1) - 1 && X + j >= 0 && Y + i >= 0 && CellAt(i, j) != '.' && matrix[Y + i, X + j] != '.')
                        return false;
                }
            }
            return true;
        }
    }
}
