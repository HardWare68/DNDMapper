namespace BoardGlower
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
            this.lstPieces = new System.Windows.Forms.ListBox();
            this.lblPieces = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.txtSizeRows = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSizeCols = new System.Windows.Forms.TextBox();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpMoves = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstPieces
            // 
            this.lstPieces.FormattingEnabled = true;
            this.lstPieces.Location = new System.Drawing.Point(994, 38);
            this.lstPieces.Name = "lstPieces";
            this.lstPieces.Size = new System.Drawing.Size(516, 238);
            this.lstPieces.TabIndex = 2;
            // 
            // lblPieces
            // 
            this.lblPieces.AutoSize = true;
            this.lblPieces.Location = new System.Drawing.Point(991, 22);
            this.lblPieces.Name = "lblPieces";
            this.lblPieces.Size = new System.Drawing.Size(42, 13);
            this.lblPieces.TabIndex = 3;
            this.lblPieces.Text = "Pieces:";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(991, 305);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(61, 13);
            this.lblSize.TabIndex = 4;
            this.lblSize.Text = "Board Size:";
            // 
            // txtSizeRows
            // 
            this.txtSizeRows.Location = new System.Drawing.Point(1058, 302);
            this.txtSizeRows.Name = "txtSizeRows";
            this.txtSizeRows.Size = new System.Drawing.Size(21, 20);
            this.txtSizeRows.TabIndex = 5;
            this.txtSizeRows.Text = "10";
            this.txtSizeRows.TextChanged += new System.EventHandler(this.txtSizeRows_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1085, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "x";
            // 
            // txtSizeCols
            // 
            this.txtSizeCols.Location = new System.Drawing.Point(1103, 302);
            this.txtSizeCols.Name = "txtSizeCols";
            this.txtSizeCols.Size = new System.Drawing.Size(21, 20);
            this.txtSizeCols.TabIndex = 7;
            this.txtSizeCols.Text = "10";
            this.txtSizeCols.TextChanged += new System.EventHandler(this.txtSizeCols_TextChanged);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(1130, 300);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.TabIndex = 8;
            this.btnDefault.Text = "Default Size";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1211, 300);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear Map";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // grpMoves
            // 
            this.grpMoves.Location = new System.Drawing.Point(995, 333);
            this.grpMoves.Name = "grpMoves";
            this.grpMoves.Size = new System.Drawing.Size(290, 273);
            this.grpMoves.TabIndex = 10;
            this.grpMoves.TabStop = false;
            this.grpMoves.Text = "groupBox1";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtLog.Location = new System.Drawing.Point(1304, 519);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(205, 86);
            this.txtLog.TabIndex = 11;
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(1304, 500);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(28, 13);
            this.lblLog.TabIndex = 12;
            this.lblLog.Text = "Log:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1536, 620);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.grpMoves);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.txtSizeCols);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSizeRows);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblPieces);
            this.Controls.Add(this.lstPieces);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstPieces;
        private System.Windows.Forms.Label lblPieces;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox txtSizeRows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSizeCols;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpMoves;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblLog;
    }
}

