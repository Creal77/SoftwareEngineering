using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class MovableGrid : Grid
    {
        public Board actualBoard;
        public Tetromino Representation { get; set; }
        public bool Falling { get; set; }

        public MovableGrid(Tetromino tetromino, Board board)
        {
            Representation = tetromino;
            Falling = true;
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

        public void MoveLeft()
        {

        }

        public void MoveRight()
        {

        }

        public void MoveDown()
        {

        }

        public bool Collision()
        {

            return true;
        }
    }
}
