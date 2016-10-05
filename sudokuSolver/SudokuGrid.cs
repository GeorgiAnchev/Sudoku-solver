using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudokuSolver
{
    public partial class SudokuGrid : UserControl
    {
        private short?[] digits = new short?[81];

        public SudokuGrid()
        {
            InitializeComponent();
        }

        private void InitializeDigits()
        {
            for (int i = 1; i <= 81; i++)
            {
                AssignId(i);
            }
        }

        private void ChangeDigitValue(DigitBox box)
        {
            digits[box.ID] = box.Value;
        }

        private void AssignId(int index)
        {
            System.Reflection.FieldInfo fieldInfo = typeof(SudokuGrid).GetField("digitBox" + index.ToString(), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var box = fieldInfo.GetValue(this) as DigitBox;
            box.ID = index - 1; //we change from 1 based to 0 based for easier calculations

            ChangeDigitValue(box);

            box.TextChanged += new System.EventHandler(DigitBoxText_Changed);
        }

        private void SudokuGrid_Load(object sender, EventArgs e)
        {
            InitializeDigits();
        }

        private void DigitBoxText_Changed(object sender, EventArgs e)
        {
            ChangeDigitValue(sender as DigitBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Solve();
        }

        private void Solve()
        {
            var  answer = (new BruteForceSolver()).Solve(this.digits);
            if (answer != null) SetGridTo(answer);
            else
            {
                //TODO
                //blink in red and stuff
            }
        }

        private void SetGridTo(short?[,] matrix)
        {
            int boxNumber = 1; 
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    System.Reflection.FieldInfo fieldInfo = typeof(SudokuGrid).GetField("digitBox" + boxNumber.ToString(), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    var box = fieldInfo.GetValue(this) as DigitBox;
                    box.Text = matrix[i, j].ToString();

                    boxNumber++;
                }
            }
        }
    }
}
