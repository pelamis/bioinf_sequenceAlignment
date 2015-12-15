namespace Bioinf_alignment
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
            this.AlignmentType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Penalty = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ContGapPenalty = new System.Windows.Forms.TextBox();
            this.OpeningGapPenalty = new System.Windows.Forms.TextBox();
            this.LoadFile2 = new System.Windows.Forms.Button();
            this.LoadFile1 = new System.Windows.Forms.Button();
            this.Seq2Inp = new System.Windows.Forms.TextBox();
            this.Seq1Inp = new System.Windows.Forms.TextBox();
            this.RunAligner = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Output = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AlignmentType
            // 
            this.AlignmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AlignmentType.FormattingEnabled = true;
            this.AlignmentType.Items.AddRange(new object[] {
            "Global",
            "Local"});
            this.AlignmentType.Location = new System.Drawing.Point(6, 78);
            this.AlignmentType.Name = "AlignmentType";
            this.AlignmentType.Size = new System.Drawing.Size(118, 21);
            this.AlignmentType.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Sequence 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Sequence 1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AlignmentType);
            this.groupBox1.Controls.Add(this.Penalty);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ContGapPenalty);
            this.groupBox1.Controls.Add(this.OpeningGapPenalty);
            this.groupBox1.Location = new System.Drawing.Point(15, 163);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 114);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // Penalty
            // 
            this.Penalty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Penalty.FormattingEnabled = true;
            this.Penalty.Items.AddRange(new object[] {
            "Linear",
            "Affine"});
            this.Penalty.Location = new System.Drawing.Point(6, 31);
            this.Penalty.Name = "Penalty";
            this.Penalty.Size = new System.Drawing.Size(118, 21);
            this.Penalty.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // ContGapPenalty
            // 
            this.ContGapPenalty.Location = new System.Drawing.Point(130, 78);
            this.ContGapPenalty.Name = "ContGapPenalty";
            this.ContGapPenalty.Size = new System.Drawing.Size(75, 20);
            this.ContGapPenalty.TabIndex = 7;
            // 
            // OpeningGapPenalty
            // 
            this.OpeningGapPenalty.Location = new System.Drawing.Point(130, 32);
            this.OpeningGapPenalty.Name = "OpeningGapPenalty";
            this.OpeningGapPenalty.Size = new System.Drawing.Size(75, 20);
            this.OpeningGapPenalty.TabIndex = 7;
            // 
            // LoadFile2
            // 
            this.LoadFile2.Location = new System.Drawing.Point(294, 104);
            this.LoadFile2.Name = "LoadFile2";
            this.LoadFile2.Size = new System.Drawing.Size(75, 23);
            this.LoadFile2.TabIndex = 13;
            this.LoadFile2.Text = "button2";
            this.LoadFile2.UseVisualStyleBackColor = true;
            // 
            // LoadFile1
            // 
            this.LoadFile1.Location = new System.Drawing.Point(294, 49);
            this.LoadFile1.Name = "LoadFile1";
            this.LoadFile1.Size = new System.Drawing.Size(75, 23);
            this.LoadFile1.TabIndex = 12;
            this.LoadFile1.Text = "button1";
            this.LoadFile1.UseVisualStyleBackColor = true;
            this.LoadFile1.Click += new System.EventHandler(this.LoadFile1_Click);
            // 
            // Seq2Inp
            // 
            this.Seq2Inp.Location = new System.Drawing.Point(15, 106);
            this.Seq2Inp.Name = "Seq2Inp";
            this.Seq2Inp.Size = new System.Drawing.Size(254, 20);
            this.Seq2Inp.TabIndex = 11;
            // 
            // Seq1Inp
            // 
            this.Seq1Inp.Location = new System.Drawing.Point(15, 51);
            this.Seq1Inp.Name = "Seq1Inp";
            this.Seq1Inp.Size = new System.Drawing.Size(254, 20);
            this.Seq1Inp.TabIndex = 10;
            // 
            // RunAligner
            // 
            this.RunAligner.Location = new System.Drawing.Point(407, 80);
            this.RunAligner.Name = "RunAligner";
            this.RunAligner.Size = new System.Drawing.Size(75, 23);
            this.RunAligner.TabIndex = 19;
            this.RunAligner.Text = "button3";
            this.RunAligner.UseVisualStyleBackColor = true;
            this.RunAligner.Click += new System.EventHandler(this.RunAligner_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(520, 80);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 20;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Output
            // 
            this.Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Output.Location = new System.Drawing.Point(241, 145);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(354, 151);
            this.Output.TabIndex = 18;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 308);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.RunAligner);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LoadFile2);
            this.Controls.Add(this.LoadFile1);
            this.Controls.Add(this.Seq2Inp);
            this.Controls.Add(this.Seq1Inp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ContGapPenalty;
        private System.Windows.Forms.TextBox OpeningGapPenalty;
        private System.Windows.Forms.Button LoadFile2;
        private System.Windows.Forms.Button LoadFile1;
        private System.Windows.Forms.TextBox Seq2Inp;
        private System.Windows.Forms.TextBox Seq1Inp;
        private System.Windows.Forms.Button RunAligner;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox AlignmentType;
        private System.Windows.Forms.ComboBox Penalty;
        private System.Windows.Forms.TextBox Output;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;



    }
}

