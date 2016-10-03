namespace sudokuSolver
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.digitBox1 = new sudokuSolver.DigitBox();
            this.sudokuGrid1 = new sudokuSolver.SudokuGrid();
            this.SuspendLayout();
            // 
            // digitBox1
            // 
            this.digitBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.digitBox1.Location = new System.Drawing.Point(34, 28);
            this.digitBox1.Margin = new System.Windows.Forms.Padding(0);
            this.digitBox1.MaximumSize = new System.Drawing.Size(20, 20);
            this.digitBox1.MaxLength = 1;
            this.digitBox1.MinimumSize = new System.Drawing.Size(20, 20);
            this.digitBox1.Multiline = false;
            this.digitBox1.Name = "digitBox1";
            this.digitBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.digitBox1.Size = new System.Drawing.Size(20, 20);
            this.digitBox1.TabIndex = 0;
            this.digitBox1.Text = "";
            // 
            // sudokuGrid1
            // 
            this.sudokuGrid1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sudokuGrid1.Location = new System.Drawing.Point(105, 85);
            this.sudokuGrid1.Name = "sudokuGrid1";
            this.sudokuGrid1.Size = new System.Drawing.Size(406, 349);
            this.sudokuGrid1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 467);
            this.Controls.Add(this.sudokuGrid1);
            this.Controls.Add(this.digitBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private DigitBox digitBox1;
        private SudokuGrid sudokuGrid1;
    }
}

