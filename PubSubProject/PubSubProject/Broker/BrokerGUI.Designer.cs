namespace PubSubProject
{
    partial class BrokerGUI
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
            this.uxPublishersLabel = new System.Windows.Forms.Label();
            this.uxSubscribersLabel = new System.Windows.Forms.Label();
            this.uxPubs = new System.Windows.Forms.ListBox();
            this.uxSubs = new System.Windows.Forms.ListBox();
            this.uxPubTopics = new System.Windows.Forms.ListBox();
            this.uxSubTopics = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // uxPublishersLabel
            // 
            this.uxPublishersLabel.AutoSize = true;
            this.uxPublishersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxPublishersLabel.Location = new System.Drawing.Point(89, 38);
            this.uxPublishersLabel.Name = "uxPublishersLabel";
            this.uxPublishersLabel.Size = new System.Drawing.Size(82, 20);
            this.uxPublishersLabel.TabIndex = 0;
            this.uxPublishersLabel.Text = "Publishers";
            // 
            // uxSubscribersLabel
            // 
            this.uxSubscribersLabel.AutoSize = true;
            this.uxSubscribersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSubscribersLabel.Location = new System.Drawing.Point(449, 38);
            this.uxSubscribersLabel.Name = "uxSubscribersLabel";
            this.uxSubscribersLabel.Size = new System.Drawing.Size(93, 20);
            this.uxSubscribersLabel.TabIndex = 1;
            this.uxSubscribersLabel.Text = "Subscribers";
            // 
            // uxPubs
            // 
            this.uxPubs.FormattingEnabled = true;
            this.uxPubs.Location = new System.Drawing.Point(30, 61);
            this.uxPubs.Name = "uxPubs";
            this.uxPubs.Size = new System.Drawing.Size(200, 95);
            this.uxPubs.TabIndex = 2;
            this.uxPubs.SelectedIndexChanged += new System.EventHandler(this.uxPubs_SelectedIndexChanged);
            // 
            // uxSubs
            // 
            this.uxSubs.FormattingEnabled = true;
            this.uxSubs.Location = new System.Drawing.Point(390, 61);
            this.uxSubs.Name = "uxSubs";
            this.uxSubs.Size = new System.Drawing.Size(200, 95);
            this.uxSubs.TabIndex = 3;
            this.uxSubs.SelectedIndexChanged += new System.EventHandler(this.uxSubs_SelectedIndexChanged);
            // 
            // uxPubTopics
            // 
            this.uxPubTopics.FormattingEnabled = true;
            this.uxPubTopics.Location = new System.Drawing.Point(30, 174);
            this.uxPubTopics.Name = "uxPubTopics";
            this.uxPubTopics.Size = new System.Drawing.Size(200, 95);
            this.uxPubTopics.TabIndex = 4;
            // 
            // uxSubTopics
            // 
            this.uxSubTopics.FormattingEnabled = true;
            this.uxSubTopics.Location = new System.Drawing.Point(390, 174);
            this.uxSubTopics.Name = "uxSubTopics";
            this.uxSubTopics.Size = new System.Drawing.Size(200, 95);
            this.uxSubTopics.TabIndex = 5;
            // 
            // BrokerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 305);
            this.Controls.Add(this.uxSubTopics);
            this.Controls.Add(this.uxPubTopics);
            this.Controls.Add(this.uxSubs);
            this.Controls.Add(this.uxPubs);
            this.Controls.Add(this.uxSubscribersLabel);
            this.Controls.Add(this.uxPublishersLabel);
            this.Name = "BrokerGUI";
            this.Text = "Broker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BrokerGUI_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxPublishersLabel;
        private System.Windows.Forms.Label uxSubscribersLabel;
        private System.Windows.Forms.ListBox uxPubs;
        private System.Windows.Forms.ListBox uxSubs;
        private System.Windows.Forms.ListBox uxPubTopics;
        private System.Windows.Forms.ListBox uxSubTopics;
    }
}

