using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Tetromino : Grid
    {

        public static Tetromino T_SHAPE
        {
            get
            {
                return new Tetromino(new string[] {
                  "....\n" +
                  "TTT.\n" +
                  ".T..\n"
              ,
                  ".T..\n" +
                  "TT..\n" +
                  ".T..\n"
              ,
                  "....\n" +
                  ".T..\n" +
                  "TTT.\n"
              ,
                  ".T..\n" +
                  ".TT.\n" +
                  ".T..\n"
              });
            }
        }

        public static Tetromino I_SHAPE
        {
            get
            {
                return new Tetromino(new string[] {
                "....\n" +
                "IIII\n" +
                "....\n" +
                "....\n"
            ,
                "..I.\n" +
                "..I.\n" +
                "..I.\n" +
                "..I.\n"
                });
            }
        }

        public static Tetromino L_SHAPE
        {
            get
            {
                return new Tetromino(new string[] {
                "....\n" +
                "LLL.\n" +
                "L...\n"
            ,
                "LL..\n" +
                ".L..\n" +
                ".L..\n"
            ,
                "....\n" +
                "..L.\n" +
                "LLL.\n"
            ,
                ".L..\n" +
                ".L..\n" +
                ".LL.\n"
                });
            }
        }

        public static Tetromino J_SHAPE
        {
            get
            {
                return new Tetromino(new string[] {
                "....\n" +
                "JJJ.\n" +
                "..J.\n"
            ,
                ".J..\n" +
                ".J..\n" +
                "JJ..\n"
            ,
                "....\n" +
                "J...\n" +
                "JJJ.\n"
            ,
                ".JJ.\n" +
                ".J..\n" +
                ".J..\n"
                });
            }
        }

        public static Tetromino S_SHAPE
        {
            get
            {
                return new Tetromino(new string[] {
                "....\n" +
                ".SS.\n" +
                "SS..\n"
            ,
                "S...\n" +
                "SS..\n" +
                ".S..\n"
                });
            }
        }

        public static Tetromino Z_SHAPE
        {
            get
            {
                return new Tetromino(new string[] {
                "....\n" +
                "ZZ..\n" +
                ".ZZ.\n"
            ,
                "..Z.\n" +
                ".ZZ.\n" +
                ".Z..\n"
                });
            }
        }

        public static Tetromino O_SHAPE
        {
            get
            {
                return new Tetromino(new string[] {
                ".OO.\n" +
                ".OO.\n"
                });
            }
        }

        Piece[] positions;
        Piece position;
        int actualPos;
        public int X { get; set; }
        public int Y { get; set; }

        public Tetromino(string[] shapes)
        {
            positions = new Piece[shapes.Length];
            for (int i = 0; i < shapes.Length; i++)
            {
                positions[i] = new Piece(shapes[i]);
            }
            actualPos = 0;
            position = positions[actualPos];
            X = 0;
            Y = 0;
        }

        public Tetromino(string s) : this(new string[] { s })
        {
        }

        private Tetromino(Piece[] positionsT, int selected)
        {
            positions = positionsT;
            actualPos = selected;
            position = positions[actualPos];
        }

        public override String ToString()
        {
            return position.ToString();
        }

        public Tetromino RotateRight()
        {
            return new Tetromino(positions, (actualPos + 1) % positions.Length);
        }

        public Tetromino RotateLeft()
        {
            int selected = actualPos - 1;
            if (selected < 0)
                selected = positions.Length - 1;
            return new Tetromino(positions, selected % positions.Length);
        }

        public int Rows()
        {
            return position.Rows();
        }

        public int Columns()
        {
            return position.Columns();
        }

        public char CellAt(int row, int col)
        {
            return position.CellAt(row, col);
        }
    }
}
