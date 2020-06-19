namespace PubSubProject.Subscriber
{
    partial class SubscriberGUI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uxHistoryLabel = new System.Windows.Forms.Label();
            this.uxActiveTopicsLabel = new System.Windows.Forms.Label();
            this.uxSubscribedTopicsLabel = new System.Windows.Forms.Label();
            this.uxSubscribeButton = new System.Windows.Forms.Button();
            this.uxUnsubscribeButton = new System.Windows.Forms.Button();
            this.uxActiveTopicsList = new System.Windows.Forms.ListBox();
            this.uxSubbedTopicsList = new System.Windows.Forms.ListBox();
            this.uxPostHistoryGrid = new System.Windows.Forms.DataGridView();
            this.topicNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.uxPostHistoryGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // uxHistoryLabel
            // 
            this.uxHistoryLabel.AutoSize = true;
            this.uxHistoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxHistoryLabel.Location = new System.Drawing.Point(702, 9);
            this.uxHistoryLabel.Name = "uxHistoryLabel";
            this.uxHistoryLabel.Size = new System.Drawing.Size(106, 20);
            this.uxHistoryLabel.TabIndex = 9;
            this.uxHistoryLabel.Text = "Post History";
            // 
            // uxActiveTopicsLabel
            // 
            this.uxActiveTopicsLabel.AutoSize = true;
            this.uxActiveTopicsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxActiveTopicsLabel.Location = new System.Drawing.Point(59, 35);
            this.uxActiveTopicsLabel.Name = "uxActiveTopicsLabel";
            this.uxActiveTopicsLabel.Size = new System.Drawing.Size(110, 20);
            this.uxActiveTopicsLabel.TabIndex = 10;
            this.uxActiveTopicsLabel.Text = "Active Topics: ";
            // 
            // uxSubscribedTopicsLabel
            // 
            this.uxSubscribedTopicsLabel.AutoSize = true;
            this.uxSubscribedTopicsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSubscribedTopicsLabel.Location = new System.Drawing.Point(59, 174);
            this.uxSubscribedTopicsLabel.Name = "uxSubscribedTopicsLabel";
            this.uxSubscribedTopicsLabel.Size = new System.Drawing.Size(169, 20);
            this.uxSubscribedTopicsLabel.TabIndex = 11;
            this.uxSubscribedTopicsLabel.Text = "Topics Subscribed To: ";
            // 
            // uxSubscribeButton
            // 
            this.uxSubscribeButton.Location = new System.Drawing.Point(323, 141);
            this.uxSubscribeButton.Name = "uxSubscribeButton";
            this.uxSubscribeButton.Size = new System.Drawing.Size(75, 23);
            this.uxSubscribeButton.TabIndex = 13;
            this.uxSubscribeButton.Text = "Subscribe";
            this.uxSubscribeButton.UseVisualStyleBackColor = true;
            this.uxSubscribeButton.Click += new System.EventHandler(this.uxSubscribeButton_Click);
            // 
            // uxUnsubscribeButton
            // 
            this.uxUnsubscribeButton.Location = new System.Drawing.Point(323, 280);
            this.uxUnsubscribeButton.Name = "uxUnsubscribeButton";
            this.uxUnsubscribeButton.Size = new System.Drawing.Size(75, 23);
            this.uxUnsubscribeButton.TabIndex = 14;
            this.uxUnsubscribeButton.Text = "Unsubscribe";
            this.uxUnsubscribeButton.UseVisualStyleBackColor = true;
            this.uxUnsubscribeButton.Click += new System.EventHandler(this.uxUnsubscribeButton_Click);
            // 
            // uxActiveTopicsList
            // 
            this.uxActiveTopicsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxActiveTopicsList.FormattingEnabled = true;
            this.uxActiveTopicsList.ItemHeight = 16;
            this.uxActiveTopicsList.Location = new System.Drawing.Point(245, 35);
            this.uxActiveTopicsList.Name = "uxActiveTopicsList";
            this.uxActiveTopicsList.Size = new System.Drawing.Size(230, 100);
            this.uxActiveTopicsList.TabIndex = 15;
            // 
            // uxSubbedTopicsList
            // 
            this.uxSubbedTopicsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSubbedTopicsList.FormattingEnabled = true;
            this.uxSubbedTopicsList.ItemHeight = 16;
            this.uxSubbedTopicsList.Location = new System.Drawing.Point(245, 174);
            this.uxSubbedTopicsList.Name = "uxSubbedTopicsList";
            this.uxSubbedTopicsList.Size = new System.Drawing.Size(230, 100);
            this.uxSubbedTopicsList.TabIndex = 16;
            // 
            // uxPostHistoryGrid
            // 
            this.uxPostHistoryGrid.AllowUserToResizeColumns = false;
            this.uxPostHistoryGrid.AllowUserToResizeRows = false;
            this.uxPostHistoryGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.uxPostHistoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uxPostHistoryGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.topicNameColumn,
            this.messageColumn,
            this.dateTimeColumn});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uxPostHistoryGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.uxPostHistoryGrid.Location = new System.Drawing.Point(532, 35);
            this.uxPostHistoryGrid.Name = "uxPostHistoryGrid";
            this.uxPostHistoryGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uxPostHistoryGrid.Size = new System.Drawing.Size(450, 274);
            this.uxPostHistoryGrid.TabIndex = 17;
            // 
            // topicNameColumn
            // 
            this.topicNameColumn.HeaderText = "Topic";
            this.topicNameColumn.Name = "topicNameColumn";
            this.topicNameColumn.ReadOnly = true;
            // 
            // messageColumn
            // 
            this.messageColumn.HeaderText = "Message";
            this.messageColumn.Name = "messageColumn";
            this.messageColumn.ReadOnly = true;
            this.messageColumn.Width = 225;
            // 
            // dateTimeColumn
            // 
            this.dateTimeColumn.HeaderText = "Date";
            this.dateTimeColumn.Name = "dateTimeColumn";
            this.dateTimeColumn.ReadOnly = true;
            // 
            // SubscriberGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 321);
            this.Controls.Add(this.uxPostHistoryGrid);
            this.Controls.Add(this.uxSubbedTopicsList);
            this.Controls.Add(this.uxActiveTopicsList);
            this.Controls.Add(this.uxUnsubscribeButton);
            this.Controls.Add(this.uxSubscribeButton);
            this.Controls.Add(this.uxSubscribedTopicsLabel);
            this.Controls.Add(this.uxActiveTopicsLabel);
            this.Controls.Add(this.uxHistoryLabel);
            this.Name = "SubscriberGUI";
            this.Text = "SubscriberGUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SubscriberGUI_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.uxPostHistoryGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label uxHistoryLabel;
        private System.Windows.Forms.Label uxActiveTopicsLabel;
        private System.Windows.Forms.Label uxSubscribedTopicsLabel;
        private System.Windows.Forms.Button uxSubscribeButton;
        private System.Windows.Forms.Button uxUnsubscribeButton;
        private System.Windows.Forms.ListBox uxActiveTopicsList;
        private System.Windows.Forms.ListBox uxSubbedTopicsList;
        private System.Windows.Forms.DataGridView uxPostHistoryGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn topicNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeColumn;
    }
}