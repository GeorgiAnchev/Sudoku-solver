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
        private bool manualKeyPressed = false;

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
                    //SelectNextControl(this, true, true, true, true);
                    if (manualKeyPressed)
                    {
                        SendKeys.Send("{TAB}");
                    }
                }
                else
                {
                    this.Text = string.Empty;
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            manualKeyPressed = true;
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            manualKeyPressed = false;
        }
    }
}
