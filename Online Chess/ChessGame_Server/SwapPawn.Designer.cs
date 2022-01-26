
namespace ChessGame
{
    partial class SwapPawn
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
            this.buttonKnight = new System.Windows.Forms.Button();
            this.buttonBishop = new System.Windows.Forms.Button();
            this.buttonRook = new System.Windows.Forms.Button();
            this.buttonQueen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonKnight
            // 
            this.buttonKnight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonKnight.BackgroundImage = global::ChessGame.Properties.Resources.DarkKnight;
            this.buttonKnight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonKnight.Location = new System.Drawing.Point(12, 12);
            this.buttonKnight.Name = "buttonKnight";
            this.buttonKnight.Size = new System.Drawing.Size(100, 100);
            this.buttonKnight.TabIndex = 0;
            this.buttonKnight.UseVisualStyleBackColor = false;
            this.buttonKnight.Click += new System.EventHandler(this.SelectPiece);
            // 
            // buttonBishop
            // 
            this.buttonBishop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonBishop.BackgroundImage = global::ChessGame.Properties.Resources.DarkBishop;
            this.buttonBishop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonBishop.Location = new System.Drawing.Point(118, 12);
            this.buttonBishop.Name = "buttonBishop";
            this.buttonBishop.Size = new System.Drawing.Size(100, 100);
            this.buttonBishop.TabIndex = 1;
            this.buttonBishop.UseVisualStyleBackColor = false;
            this.buttonBishop.Click += new System.EventHandler(this.SelectPiece);
            // 
            // buttonRook
            // 
            this.buttonRook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonRook.BackgroundImage = global::ChessGame.Properties.Resources.DarkRook;
            this.buttonRook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRook.Location = new System.Drawing.Point(224, 12);
            this.buttonRook.Name = "buttonRook";
            this.buttonRook.Size = new System.Drawing.Size(100, 100);
            this.buttonRook.TabIndex = 2;
            this.buttonRook.UseVisualStyleBackColor = false;
            this.buttonRook.Click += new System.EventHandler(this.SelectPiece);
            // 
            // buttonQueen
            // 
            this.buttonQueen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonQueen.BackgroundImage = global::ChessGame.Properties.Resources.DarkQueen;
            this.buttonQueen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonQueen.Location = new System.Drawing.Point(330, 12);
            this.buttonQueen.Name = "buttonQueen";
            this.buttonQueen.Size = new System.Drawing.Size(100, 100);
            this.buttonQueen.TabIndex = 3;
            this.buttonQueen.UseVisualStyleBackColor = false;
            this.buttonQueen.Click += new System.EventHandler(this.SelectPiece);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(125, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "CHOOSE A PIECE";
            // 
            // SwapPawn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(444, 161);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonQueen);
            this.Controls.Add(this.buttonRook);
            this.Controls.Add(this.buttonBishop);
            this.Controls.Add(this.buttonKnight);
            this.Name = "SwapPawn";
            this.Text = "SwapPawn";
            this.Load += new System.EventHandler(this.SwapPawn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonKnight;
        private System.Windows.Forms.Button buttonBishop;
        private System.Windows.Forms.Button buttonRook;
        private System.Windows.Forms.Button buttonQueen;
        private System.Windows.Forms.Label label1;
    }
}