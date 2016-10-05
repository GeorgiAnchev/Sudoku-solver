using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuSolver
{
    public class BruteForceSolver
    {
        private UsedDigits[] usedRows;
        private UsedDigits[] usedCols;
        private UsedDigits[] usedGroups;

        private Stack<Point> missingNumbers;

        private short?[,] matrix = new short?[9, 9];

        public short?[,] Solve (short?[] input)
        {
            Initialize(input);

            bool solved = Next();


            if (solved)
            {
                return matrix;
            }
            else
            {
                return null;
            }
            
        }

        private void Initialize(short?[] input)
        {
            this.missingNumbers = new Stack<Point>();
            usedRows = new UsedDigits[9] { new UsedDigits(), new UsedDigits(), new UsedDigits(), new UsedDigits(), new UsedDigits(), new UsedDigits(), new UsedDigits(), new UsedDigits(), new UsedDigits() };
            usedCols = new UsedDigits[9] { new UsedDigits(), new UsedDigits(), new UsedDigits(), new UsedDigits(), new UsedDigits(), new UsedDigits(), new UsedDigits(), new UsedDigits(), new UsedDigits() };
            usedGroups = new UsedDigits[9] { new UsedDigits(), new UsedDigits(), new UsedDigits(), new UsedDigits(), new UsedDigits(), new UsedDigits(), new UsedDigits(), new UsedDigits(), new UsedDigits() };

            for (int i = 0; i < input.Length; ++i)
            {

                int row = i / 9;
                int col = i % 9;
                short? value = input[i];

                this.matrix[row, col] = value;

                if (value == null)
                {
                    this.missingNumbers.Push(new Point(row, col));
                }
                else
                {
                    int group = (row / 3) * 3 + col / 3;

                    usedGroups[group][ (int)value] = true;
                    usedRows[row][ (int)value ] = true;
                    usedCols[col][ (int)value ] = true;
                }
            }
        }

        private bool Next()
        {
            if (missingNumbers.Count == 0) return true; // Solution Found!

            bool solutionFound = false;

            Point emptyBox = missingNumbers.Pop();

            for (int value = 1; value <= 9; value++)
            {
                if (AddToMatrix(emptyBox, value))
                {
                    solutionFound = Next();
                    if (solutionFound == true) break;

                    RemoveFromMatrix(emptyBox, value);
                }
            }

            missingNumbers.Push(emptyBox);

            return solutionFound;
        }

        private void RemoveFromMatrix(Point emptyBox, int value)
        {
            int row = emptyBox.X;
            int col = emptyBox.Y;

            matrix[row, col] = null;
            int group = (row / 3) * 3 + col / 3;

            usedGroups[group][(int)value] = false;
            usedRows[row][(int)value] = false;
            usedCols[col][(int)value] = false;

        }

        private bool AddToMatrix(Point emptyBox, int value)
        {
            int row = emptyBox.X;
            int col = emptyBox.Y;
            
            int group = (row / 3) * 3 + col / 3;

            if(usedGroups[group][value] == true || usedRows[row][value] == true || usedCols[col][value] == true)
            {
                return false;
            }

            usedGroups[group][value] = true;
            usedRows[row][value] = true;
            usedCols[col][value] = true;

            matrix[row, col] = (short)value;
            return true;
        }

        private class UsedDigits 
        {
            bool[] digits;

            public UsedDigits()
            {
                this.digits = new bool[10];
            }

            public UsedDigits(IEnumerable<short?> digits) : this()
            {
                foreach (var usedDigit in digits)
                {
                    if(usedDigit != null) this.digits[(short)usedDigit] = true;
                }
            }

            public bool this[int index]
            {
                get { return this.digits[index]; }
                set { this.digits[index] = value; }
            }

        }

        public struct Point
        {
            public int X;
            public int Y;

            public Point(int v1, int v2) : this()
            {
                this.X = v1;
                this.Y = v2;
            }
            
        }
    }

    
}
