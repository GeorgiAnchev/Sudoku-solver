using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudokuSolver
{
    public partial class DigitBox : RichTextBox
    {
        public short? Value = null;
        public int ID;
        public DigitBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void DigitBox_TextChanged(object sender, EventArgs e)
        {
            if (this.Text == string.Empty )
            {
                this.Value = null;
            }
            else
            {
                short value;
                if (short.TryParse(this.Text, out value) && value != 0)
                {
                    this.Value = value;
                }
                else
                {
                    this.Text = string.Empty;
                }
            }
        }
    }
}
