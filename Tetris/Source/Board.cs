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
        char[,] blocks;
        bool fallingBlock;
        MovableGrid movingGrid;
        List<MovableGrid> gridList;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            blocks = new char[rows, columns];
            fallingBlock = false;
            gridList = new List<MovableGrid>();
            for (int row = 0; row < rows; row++)
                for (int col = 0; col < columns; col++)
                    blocks[row, col] = '.';
        }

        public override String ToString()
        {
            String s = "";
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                    s += blocks[row, col];
                s += "\n";
            }
            return s;
        }

        public bool IsFallingBlock()
        {
            return fallingBlock;
        }

        public void refreshTab(MovableGrid oldPiece, MovableGrid newPiece)
        {
            if (oldPiece != null)
            {
                for (int i = 0; i < oldPiece.Rows(); i++)
                {
                    for (int j = 0; j < oldPiece.Columns(); j++)
                    {
                        if (oldPiece.Y + i >= 0 && oldPiece.CellAt(i, j) != '.')
                            blocks[oldPiece.Y + i, oldPiece.X + j] = '.';
                    }
                }
            }
            if (newPiece != null)
            {
                for (int i = 0; i < newPiece.Rows(); i++)
                {
                    for (int j = 0; j < newPiece.Columns(); j++)
                    {
                        if (newPiece.Y + i >= 0 && newPiece.CellAt(i, j) != '.')
                            blocks[newPiece.Y + i, newPiece.X + j] = newPiece.CellAt(i, j);
                    }
                }
            }
        }

        public void Drop(Grid shape)
        {
            CheckIfFalling();
            movingGrid = new MovableGrid((Tetromino)shape);
            movingGrid = movingGrid.MoveTo((columns / 2 - shape.Columns() / 2), StartingRowOffset(shape));
            fallingBlock = true;
            refreshTab(null, movingGrid);
        }

        public void MoveDown()
        {
            MovableGrid test = movingGrid.MoveDown();
            refreshTab(movingGrid, null);
            if (ConflictsWithBoard(test) == false)
            {
                refreshTab(null, test);
                movingGrid = test;
            }
            else
            {
                refreshTab(null, movingGrid);
            }
        }

        public void MoveLeft()
        {
            MovableGrid test = movingGrid.MoveLeft();
            refreshTab(movingGrid, null);
            if (ConflictsWithBoard(test) == false)
            {
                refreshTab(null, test);
                movingGrid = test;
            }
            else
            {
                refreshTab(null, movingGrid);
            }
        }

        public void MoveRight()
        {
            MovableGrid test = movingGrid.MoveRight();
            refreshTab(movingGrid, null);
            if (ConflictsWithBoard(test) == false)
            {
                refreshTab(null, test);
                movingGrid = test;
            }
            else
            {
                refreshTab(null, movingGrid);
            }
        }

        public void RotateRight()
        {
            MovableGrid test = movingGrid.RotateRight();
            TryRotate(test);
        }

        public void RotateLeft()
        {
            MovableGrid test = movingGrid.RotateLeft();
            TryRotate(test);
        }

        public void Tick()
        {
            if (!fallingBlock)
                return;
            MovableGrid test = movingGrid.MoveDown();
            refreshTab(movingGrid, null);
            if (ConflictsWithBoard(test))
            {
                StopFallingBlock();
                refreshTab(null, movingGrid);
            }
            else
            {
                refreshTab(null, test);
                movingGrid = test;
            }
        }

        public void FromString(string v)
        {
            blocks = new Piece(v).blocks;
        }

        private void StopFallingBlock()
        {
            fallingBlock = false;
            gridList.Add(movingGrid);
        }

        private void CheckIfFalling()
        {
            if (fallingBlock)
                throw new ArgumentException("A block is already falling.");
        }

        private bool ConflictsWithBoard(Grid shape)
        {
            MovableGrid test = (MovableGrid)shape;
            return !test.Collision(blocks);
        }

        private static int StartingRowOffset(Grid shape)
        {
            for (int r = 0; r < shape.Rows(); r++)
            {
                for (int c = 0; c < shape.Columns(); c++)
                {
                    if (shape.CellAt(r, c) != '.')
                        return -r;
                }
            }
            return 0;
        }

        private void TryRotate(MovableGrid rotated)
        {
            MovableGrid[] moves = {
                rotated ,
                rotated . MoveLeft () , // wallkick moves
                rotated . MoveRight () ,
                rotated . MoveLeft () . MoveLeft () ,
                rotated . MoveRight () . MoveRight () ,
                };
            refreshTab(movingGrid, null);
            foreach (MovableGrid test in moves)
            {
                if (!ConflictsWithBoard(test))
                {
                    refreshTab(null, test);
                    movingGrid = test;
                    return;
                }
            }
            refreshTab(null, movingGrid);
        }
    }
}
