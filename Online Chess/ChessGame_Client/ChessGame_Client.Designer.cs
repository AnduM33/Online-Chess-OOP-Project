
using System;
using System.Windows.Forms;

namespace ChessGame
{
    partial class ChessGame_Client
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnConect = new System.Windows.Forms.Button();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.connectLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Desktop;
            this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(810, 10);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(200, 500);
            this.textBox1.TabIndex = 0;
            this.textBox1.WordWrap = false;
            // 
            // btnConect
            // 
            this.btnConect.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnConect.BackgroundImage = global::ChessGame.Properties.Resources.AntennaBlack;
            this.btnConect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConect.Location = new System.Drawing.Point(911, 544);
            this.btnConect.Name = "btnConect";
            this.btnConect.Size = new System.Drawing.Size(75, 75);
            this.btnConect.TabIndex = 3;
            this.btnConect.UseVisualStyleBackColor = false;
            this.btnConect.Click += new System.EventHandler(this.BtnConect_Click);
            // 
            // tbAddress
            // 
            this.tbAddress.BackColor = System.Drawing.SystemColors.Desktop;
            this.tbAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddress.ForeColor = System.Drawing.SystemColors.Window;
            this.tbAddress.Location = new System.Drawing.Point(901, 516);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(109, 22);
            this.tbAddress.TabIndex = 4;
            this.tbAddress.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(807, 519);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "IP Address:";
            // 
            // connectLabel
            // 
            this.connectLabel.AutoSize = true;
            this.connectLabel.Location = new System.Drawing.Point(928, 626);
            this.connectLabel.Name = "connectLabel";
            this.connectLabel.Size = new System.Drawing.Size(47, 13);
            this.connectLabel.TabIndex = 6;
            this.connectLabel.Text = "Connect";
            // 
            // ChessGame_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1014, 811);
            this.Controls.Add(this.connectLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.btnConect);
            this.Controls.Add(this.textBox1);
            this.Icon = global::ChessGame.Properties.Resources.IconC;
            this.Name = "ChessGame_Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChessGame_Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.ChessGame_Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox textBox1;
        private Button btnConect;
        private TextBox tbAddress;
        private Label label1;
        private Label connectLabel;
    }
}

