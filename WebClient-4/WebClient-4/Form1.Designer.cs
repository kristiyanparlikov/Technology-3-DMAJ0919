namespace WebClient_4
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
            this.tbHeader = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBody = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btSendRequest = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbURL = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbHeader
            // 
            this.tbHeader.Location = new System.Drawing.Point(15, 176);
            this.tbHeader.Multiline = true;
            this.tbHeader.Name = "tbHeader";
            this.tbHeader.Size = new System.Drawing.Size(590, 66);
            this.tbHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(593, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "This WebClient should connect to http://ptsv2.com/ for a dump. Please correct the" +
    " dump URL";
            // 
            // tbBody
            // 
            this.tbBody.Location = new System.Drawing.Point(15, 287);
            this.tbBody.Multiline = true;
            this.tbBody.Name = "tbBody";
            this.tbBody.Size = new System.Drawing.Size(590, 75);
            this.tbBody.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Return Header";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Return Body";
            // 
            // btSendRequest
            // 
            this.btSendRequest.AutoEllipsis = true;
            this.btSendRequest.Location = new System.Drawing.Point(12, 91);
            this.btSendRequest.Name = "btSendRequest";
            this.btSendRequest.Size = new System.Drawing.Size(118, 23);
            this.btSendRequest.TabIndex = 15;
            this.btSendRequest.Text = "Send Request";
            this.btSendRequest.UseVisualStyleBackColor = true;
            this.btSendRequest.Click += new System.EventHandler(this.btSendRequest_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Toilet URL";
            // 
            // tbURL
            // 
            this.tbURL.Location = new System.Drawing.Point(12, 63);
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(590, 22);
            this.tbURL.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 419);
            this.Controls.Add(this.btSendRequest);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbURL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbBody);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbHeader);
            this.Name = "Form1";
            this.Text = "WebClient-4";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBody;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btSendRequest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbURL;
    }
}

