using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Tetromino : Grid
    {
     
        public static Tetromino T_SHAPE = new Tetromino(
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
            );

        public static Tetromino I_SHAPE = new Tetromino(
                "....\n" +
                "IIII\n" +
                "....\n" +
                "....\n"
            ,
                "..I.\n" +
                "..I.\n" +
                "..I.\n" +
                "..I.\n"
            );

        public static Tetromino L_SHAPE = new Tetromino(
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
            );

        public static Tetromino J_SHAPE = new Tetromino(
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
            );

        public static Tetromino S_SHAPE = new Tetromino(
                "....\n" +
                ".SS.\n" +
                "SS..\n"
            ,
                "S...\n" +
                "SS..\n" +
                ".S..\n"
            );

        public static Tetromino Z_SHAPE = new Tetromino(
                "....\n" +
                "ZZ..\n" +
                ".ZZ.\n"
            ,
                "..Z.\n" +
                ".ZZ.\n" +
                ".Z..\n"
            );

        public static Tetromino O_SHAPE = new Tetromino(
                ".OO.\n" +
                ".OO.\n"
            );

        Piece[] positions;
        Piece position;

        public Tetromino(params string[] shapes)
        {
            positions = new Piece[shapes.Length];
            for (int i = 0; i < shapes.Length; i++)
            {
                positions[i] = new Piece(shapes[i]);
            }
            position = positions[0];
        }

        public override String ToString()
        {
            return position.ToString();
        }

        public Tetromino RotateRight()
        {
            int numberOfPostions = positions.Length;
            if (numberOfPostions == 1)
            {
                return new Tetromino(positions[0].ToString());
            }
            String[] tmp = new String[numberOfPostions];
            tmp[numberOfPostions - 1] = positions[0].ToString();
            for (int i = 1; i < numberOfPostions; i++)
            {
                tmp[i - 1] = positions[i].ToString();
            }
            return new Tetromino(tmp);
        }

        public Tetromino RotateLeft()
        {
            int numberOfPostions = positions.Length;
            if (numberOfPostions == 1)
            {
                return new Tetromino(positions[0].ToString());
            }
            String[] tmp = new String[numberOfPostions];
            tmp[0] = positions[numberOfPostions - 1].ToString();
            for (int i = 1; i < numberOfPostions; i++)
            {
                tmp[i] = positions[i - 1].ToString();
            }
            return new Tetromino(tmp);
        }

        public int Rows()
        {
            return position.y;
        }

        public int Columns()
        {
            return position.x;
        }

        public char CellAt(int row, int col)
        {
            return position.CellAt(row,col);
        }
    }
}
