namespace TransactionScope
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
            this.textBoxPasswordB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxUserB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxUrlB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.buttonConA = new System.Windows.Forms.Button();
            this.buttonConB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUrlA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUserA = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPasswordA = new System.Windows.Forms.TextBox();
            this.buttonPrepareTest = new System.Windows.Forms.Button();
            this.buttonTestWoTS = new System.Windows.Forms.Button();
            this.buttonTestWTS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxPasswordB
            // 
            this.textBoxPasswordB.Location = new System.Drawing.Point(500, 166);
            this.textBoxPasswordB.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPasswordB.Name = "textBoxPasswordB";
            this.textBoxPasswordB.PasswordChar = '*';
            this.textBoxPasswordB.Size = new System.Drawing.Size(233, 22);
            this.textBoxPasswordB.TabIndex = 11;
            this.textBoxPasswordB.Text = "Technology3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(417, 170);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Password:";
            // 
            // textBoxUserB
            // 
            this.textBoxUserB.Location = new System.Drawing.Point(129, 166);
            this.textBoxUserB.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUserB.Name = "textBoxUserB";
            this.textBoxUserB.Size = new System.Drawing.Size(229, 22);
            this.textBoxUserB.TabIndex = 9;
            this.textBoxUserB.Text = "sa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 170);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "User:";
            // 
            // textBoxUrlB
            // 
            this.textBoxUrlB.Location = new System.Drawing.Point(129, 127);
            this.textBoxUrlB.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUrlB.Name = "textBoxUrlB";
            this.textBoxUrlB.Size = new System.Drawing.Size(712, 22);
            this.textBoxUrlB.TabIndex = 7;
            this.textBoxUrlB.Text = "l3.kaje.ucnit20.eu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 130);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Database URL:";
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(500, 231);
            this.textBoxResult.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(549, 307);
            this.textBoxResult.TabIndex = 12;
            // 
            // buttonConA
            // 
            this.buttonConA.Location = new System.Drawing.Point(875, 26);
            this.buttonConA.Margin = new System.Windows.Forms.Padding(4);
            this.buttonConA.Name = "buttonConA";
            this.buttonConA.Size = new System.Drawing.Size(104, 28);
            this.buttonConA.TabIndex = 13;
            this.buttonConA.Text = "Test A";
            this.buttonConA.UseVisualStyleBackColor = true;
            this.buttonConA.Click += new System.EventHandler(this.buttonConA_Click);
            // 
            // buttonConB
            // 
            this.buttonConB.Location = new System.Drawing.Point(875, 124);
            this.buttonConB.Margin = new System.Windows.Forms.Padding(4);
            this.buttonConB.Name = "buttonConB";
            this.buttonConB.Size = new System.Drawing.Size(104, 28);
            this.buttonConB.TabIndex = 13;
            this.buttonConB.Text = "Test B";
            this.buttonConB.UseVisualStyleBackColor = true;
            this.buttonConB.Click += new System.EventHandler(this.buttonConB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database URL:";
            // 
            // textBoxUrlA
            // 
            this.textBoxUrlA.Location = new System.Drawing.Point(129, 28);
            this.textBoxUrlA.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUrlA.Name = "textBoxUrlA";
            this.textBoxUrlA.Size = new System.Drawing.Size(712, 22);
            this.textBoxUrlA.TabIndex = 1;
            this.textBoxUrlA.Text = "l2.kaje.ucnit20.eu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "User:";
            // 
            // textBoxUserA
            // 
            this.textBoxUserA.Location = new System.Drawing.Point(129, 68);
            this.textBoxUserA.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUserA.Name = "textBoxUserA";
            this.textBoxUserA.Size = new System.Drawing.Size(229, 22);
            this.textBoxUserA.TabIndex = 3;
            this.textBoxUserA.Text = "sa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(417, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // textBoxPasswordA
            // 
            this.textBoxPasswordA.Location = new System.Drawing.Point(500, 68);
            this.textBoxPasswordA.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPasswordA.Name = "textBoxPasswordA";
            this.textBoxPasswordA.PasswordChar = '*';
            this.textBoxPasswordA.Size = new System.Drawing.Size(233, 22);
            this.textBoxPasswordA.TabIndex = 5;
            this.textBoxPasswordA.Text = "Technology3";
            // 
            // buttonPrepareTest
            // 
            this.buttonPrepareTest.Location = new System.Drawing.Point(21, 231);
            this.buttonPrepareTest.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPrepareTest.Name = "buttonPrepareTest";
            this.buttonPrepareTest.Size = new System.Drawing.Size(131, 28);
            this.buttonPrepareTest.TabIndex = 14;
            this.buttonPrepareTest.Text = "Prepare for Test";
            this.buttonPrepareTest.UseVisualStyleBackColor = true;
            this.buttonPrepareTest.Click += new System.EventHandler(this.buttonPrepareTest_Click);
            // 
            // buttonTestWoTS
            // 
            this.buttonTestWoTS.Location = new System.Drawing.Point(21, 288);
            this.buttonTestWoTS.Name = "buttonTestWoTS";
            this.buttonTestWoTS.Size = new System.Drawing.Size(131, 28);
            this.buttonTestWoTS.TabIndex = 15;
            this.buttonTestWoTS.Text = "Test wo TS";
            this.buttonTestWoTS.UseVisualStyleBackColor = true;
            this.buttonTestWoTS.Click += new System.EventHandler(this.buttonTestWoTS_Click);
            // 
            // buttonTestWTS
            // 
            this.buttonTestWTS.Location = new System.Drawing.Point(21, 322);
            this.buttonTestWTS.Name = "buttonTestWTS";
            this.buttonTestWTS.Size = new System.Drawing.Size(131, 29);
            this.buttonTestWTS.TabIndex = 16;
            this.buttonTestWTS.Text = "Test w TS";
            this.buttonTestWTS.UseVisualStyleBackColor = true;
            this.buttonTestWTS.Click += new System.EventHandler(this.buttonTestWTS_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.buttonTestWTS);
            this.Controls.Add(this.buttonTestWoTS);
            this.Controls.Add(this.buttonPrepareTest);
            this.Controls.Add(this.buttonConB);
            this.Controls.Add(this.buttonConA);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.textBoxPasswordB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxUserB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxUrlB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxPasswordA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxUserA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxUrlA);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxPasswordB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxUserB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxUrlB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Button buttonConA;
        private System.Windows.Forms.Button buttonConB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUrlA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUserA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPasswordA;
        private System.Windows.Forms.Button buttonPrepareTest;
        private System.Windows.Forms.Button buttonTestWoTS;
        private System.Windows.Forms.Button buttonTestWTS;
    }
}

