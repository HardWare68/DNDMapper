﻿namespace BoardGlower
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
            this.btnReload = new System.Windows.Forms.Button();
            this.grpMoves = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.grpCompass = new System.Windows.Forms.GroupBox();
            this.radRight = new System.Windows.Forms.RadioButton();
            this.radLeft = new System.Windows.Forms.RadioButton();
            this.radDown = new System.Windows.Forms.RadioButton();
            this.radUp = new System.Windows.Forms.RadioButton();
            this.grpMapControls = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMapWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMapHeight = new System.Windows.Forms.TextBox();
            this.grpCompass.SuspendLayout();
            this.grpMapControls.SuspendLayout();
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
            this.lblSize.Location = new System.Drawing.Point(6, 24);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(61, 13);
            this.lblSize.TabIndex = 4;
            this.lblSize.Text = "Board Size:";
            // 
            // txtSizeRows
            // 
            this.txtSizeRows.Location = new System.Drawing.Point(73, 21);
            this.txtSizeRows.Name = "txtSizeRows";
            this.txtSizeRows.Size = new System.Drawing.Size(21, 20);
            this.txtSizeRows.TabIndex = 5;
            this.txtSizeRows.Text = "15";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "x";
            // 
            // txtSizeCols
            // 
            this.txtSizeCols.Location = new System.Drawing.Point(118, 21);
            this.txtSizeCols.Name = "txtSizeCols";
            this.txtSizeCols.Size = new System.Drawing.Size(21, 20);
            this.txtSizeCols.TabIndex = 7;
            this.txtSizeCols.Text = "15";
            // 
            // btnDefault
            // 
            this.btnDefault.BackColor = System.Drawing.SystemColors.Control;
            this.btnDefault.Location = new System.Drawing.Point(9, 90);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.TabIndex = 8;
            this.btnDefault.Text = "Default Size";
            this.btnDefault.UseVisualStyleBackColor = false;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(118, 90);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 9;
            this.btnReload.Text = "Reload Map";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // grpMoves
            // 
            this.grpMoves.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMoves.Location = new System.Drawing.Point(995, 300);
            this.grpMoves.Name = "grpMoves";
            this.grpMoves.Size = new System.Drawing.Size(290, 306);
            this.grpMoves.TabIndex = 10;
            this.grpMoves.TabStop = false;
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
            // grpCompass
            // 
            this.grpCompass.Controls.Add(this.radRight);
            this.grpCompass.Controls.Add(this.radLeft);
            this.grpCompass.Controls.Add(this.radDown);
            this.grpCompass.Controls.Add(this.radUp);
            this.grpCompass.Location = new System.Drawing.Point(1304, 300);
            this.grpCompass.Name = "grpCompass";
            this.grpCompass.Size = new System.Drawing.Size(75, 75);
            this.grpCompass.TabIndex = 13;
            this.grpCompass.TabStop = false;
            this.grpCompass.Text = "Compass";
            // 
            // radRight
            // 
            this.radRight.AutoSize = true;
            this.radRight.Location = new System.Drawing.Point(55, 37);
            this.radRight.Name = "radRight";
            this.radRight.Size = new System.Drawing.Size(14, 13);
            this.radRight.TabIndex = 3;
            this.radRight.TabStop = true;
            this.radRight.UseVisualStyleBackColor = true;
            // 
            // radLeft
            // 
            this.radLeft.AutoSize = true;
            this.radLeft.Location = new System.Drawing.Point(6, 37);
            this.radLeft.Name = "radLeft";
            this.radLeft.Size = new System.Drawing.Size(14, 13);
            this.radLeft.TabIndex = 2;
            this.radLeft.TabStop = true;
            this.radLeft.UseVisualStyleBackColor = true;
            // 
            // radDown
            // 
            this.radDown.AutoSize = true;
            this.radDown.Location = new System.Drawing.Point(30, 56);
            this.radDown.Name = "radDown";
            this.radDown.Size = new System.Drawing.Size(14, 13);
            this.radDown.TabIndex = 1;
            this.radDown.TabStop = true;
            this.radDown.UseVisualStyleBackColor = true;
            // 
            // radUp
            // 
            this.radUp.AutoSize = true;
            this.radUp.Location = new System.Drawing.Point(30, 19);
            this.radUp.Name = "radUp";
            this.radUp.Size = new System.Drawing.Size(14, 13);
            this.radUp.TabIndex = 0;
            this.radUp.TabStop = true;
            this.radUp.UseVisualStyleBackColor = true;
            // 
            // grpMapControls
            // 
            this.grpMapControls.Controls.Add(this.label2);
            this.grpMapControls.Controls.Add(this.txtMapWidth);
            this.grpMapControls.Controls.Add(this.label3);
            this.grpMapControls.Controls.Add(this.txtMapHeight);
            this.grpMapControls.Controls.Add(this.btnDefault);
            this.grpMapControls.Controls.Add(this.lblSize);
            this.grpMapControls.Controls.Add(this.txtSizeRows);
            this.grpMapControls.Controls.Add(this.label1);
            this.grpMapControls.Controls.Add(this.txtSizeCols);
            this.grpMapControls.Controls.Add(this.btnReload);
            this.grpMapControls.Location = new System.Drawing.Point(1304, 381);
            this.grpMapControls.Name = "grpMapControls";
            this.grpMapControls.Size = new System.Drawing.Size(205, 119);
            this.grpMapControls.TabIndex = 14;
            this.grpMapControls.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Square Size:";
            // 
            // txtMapWidth
            // 
            this.txtMapWidth.Location = new System.Drawing.Point(73, 52);
            this.txtMapWidth.Name = "txtMapWidth";
            this.txtMapWidth.Size = new System.Drawing.Size(21, 20);
            this.txtMapWidth.TabIndex = 11;
            this.txtMapWidth.Text = "30";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "x";
            // 
            // txtMapHeight
            // 
            this.txtMapHeight.Location = new System.Drawing.Point(118, 52);
            this.txtMapHeight.Name = "txtMapHeight";
            this.txtMapHeight.Size = new System.Drawing.Size(21, 20);
            this.txtMapHeight.TabIndex = 13;
            this.txtMapHeight.Text = "30";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1536, 620);
            this.Controls.Add(this.grpMapControls);
            this.Controls.Add(this.grpCompass);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.grpMoves);
            this.Controls.Add(this.lblPieces);
            this.Controls.Add(this.lstPieces);
            this.Name = "Form1";
            this.Text = "DND Mapper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpCompass.ResumeLayout(false);
            this.grpCompass.PerformLayout();
            this.grpMapControls.ResumeLayout(false);
            this.grpMapControls.PerformLayout();
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
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.GroupBox grpMoves;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.GroupBox grpCompass;
        private System.Windows.Forms.RadioButton radRight;
        private System.Windows.Forms.RadioButton radLeft;
        private System.Windows.Forms.RadioButton radDown;
        private System.Windows.Forms.RadioButton radUp;
        private System.Windows.Forms.GroupBox grpMapControls;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMapWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMapHeight;
    }
}

