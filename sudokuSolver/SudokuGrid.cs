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
    }
}
