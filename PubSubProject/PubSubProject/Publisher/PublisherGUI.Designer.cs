namespace PubSubProject.Publisher
{
    partial class PublisherGUI
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
            this.uxNewTopicLabel = new System.Windows.Forms.Label();
            this.uxPostLabel = new System.Windows.Forms.Label();
            this.uxCreateTopicButton = new System.Windows.Forms.Button();
            this.uxTopicTextBox = new System.Windows.Forms.TextBox();
            this.uxMessageBox = new System.Windows.Forms.TextBox();
            this.uxPostMessageButton = new System.Windows.Forms.Button();
            this.uxHistoryLabel = new System.Windows.Forms.Label();
            this.uxPostToTopicLabel = new System.Windows.Forms.Label();
            this.uxTopicDropDown = new System.Windows.Forms.ComboBox();
            this.uxDeleteTopic = new System.Windows.Forms.Button();
            this.uxPostHistoryGrid = new System.Windows.Forms.DataGridView();
            this.topicNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.uxPostHistoryGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // uxNewTopicLabel
            // 
            this.uxNewTopicLabel.AutoSize = true;
            this.uxNewTopicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxNewTopicLabel.Location = new System.Drawing.Point(50, 9);
            this.uxNewTopicLabel.Name = "uxNewTopicLabel";
            this.uxNewTopicLabel.Size = new System.Drawing.Size(136, 20);
            this.uxNewTopicLabel.TabIndex = 0;
            this.uxNewTopicLabel.Text = "New Topic Name: ";
            // 
            // uxPostLabel
            // 
            this.uxPostLabel.AutoSize = true;
            this.uxPostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxPostLabel.Location = new System.Drawing.Point(50, 152);
            this.uxPostLabel.Name = "uxPostLabel";
            this.uxPostLabel.Size = new System.Drawing.Size(196, 20);
            this.uxPostLabel.TabIndex = 1;
            this.uxPostLabel.Text = "Enter New Post Message: ";
            // 
            // uxCreateTopicButton
            // 
            this.uxCreateTopicButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxCreateTopicButton.Location = new System.Drawing.Point(323, 35);
            this.uxCreateTopicButton.Name = "uxCreateTopicButton";
            this.uxCreateTopicButton.Size = new System.Drawing.Size(148, 32);
            this.uxCreateTopicButton.TabIndex = 2;
            this.uxCreateTopicButton.Text = "Create Topic";
            this.uxCreateTopicButton.UseVisualStyleBackColor = true;
            this.uxCreateTopicButton.Click += new System.EventHandler(this.uxCreateTopicButton_Click);
            // 
            // uxTopicTextBox
            // 
            this.uxTopicTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxTopicTextBox.Location = new System.Drawing.Point(280, 7);
            this.uxTopicTextBox.Name = "uxTopicTextBox";
            this.uxTopicTextBox.Size = new System.Drawing.Size(225, 22);
            this.uxTopicTextBox.TabIndex = 4;
            // 
            // uxMessageBox
            // 
            this.uxMessageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxMessageBox.Location = new System.Drawing.Point(280, 152);
            this.uxMessageBox.Multiline = true;
            this.uxMessageBox.Name = "uxMessageBox";
            this.uxMessageBox.Size = new System.Drawing.Size(225, 119);
            this.uxMessageBox.TabIndex = 5;
            // 
            // uxPostMessageButton
            // 
            this.uxPostMessageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxPostMessageButton.Location = new System.Drawing.Point(323, 277);
            this.uxPostMessageButton.Name = "uxPostMessageButton";
            this.uxPostMessageButton.Size = new System.Drawing.Size(148, 32);
            this.uxPostMessageButton.TabIndex = 6;
            this.uxPostMessageButton.Text = "Post Message";
            this.uxPostMessageButton.UseVisualStyleBackColor = true;
            this.uxPostMessageButton.Click += new System.EventHandler(this.uxPostMessageButton_Click);
            // 
            // uxHistoryLabel
            // 
            this.uxHistoryLabel.AutoSize = true;
            this.uxHistoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxHistoryLabel.Location = new System.Drawing.Point(702, 9);
            this.uxHistoryLabel.Name = "uxHistoryLabel";
            this.uxHistoryLabel.Size = new System.Drawing.Size(106, 20);
            this.uxHistoryLabel.TabIndex = 8;
            this.uxHistoryLabel.Text = "Post History";
            // 
            // uxPostToTopicLabel
            // 
            this.uxPostToTopicLabel.AutoSize = true;
            this.uxPostToTopicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxPostToTopicLabel.Location = new System.Drawing.Point(50, 80);
            this.uxPostToTopicLabel.Name = "uxPostToTopicLabel";
            this.uxPostToTopicLabel.Size = new System.Drawing.Size(113, 20);
            this.uxPostToTopicLabel.TabIndex = 9;
            this.uxPostToTopicLabel.Text = "Post To Topic: ";
            // 
            // uxTopicDropDown
            // 
            this.uxTopicDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxTopicDropDown.FormattingEnabled = true;
            this.uxTopicDropDown.Location = new System.Drawing.Point(280, 76);
            this.uxTopicDropDown.Name = "uxTopicDropDown";
            this.uxTopicDropDown.Size = new System.Drawing.Size(225, 24);
            this.uxTopicDropDown.TabIndex = 10;
            // 
            // uxDeleteTopic
            // 
            this.uxDeleteTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxDeleteTopic.Location = new System.Drawing.Point(323, 108);
            this.uxDeleteTopic.Name = "uxDeleteTopic";
            this.uxDeleteTopic.Size = new System.Drawing.Size(148, 32);
            this.uxDeleteTopic.TabIndex = 11;
            this.uxDeleteTopic.Text = "Delete Topic";
            this.uxDeleteTopic.UseVisualStyleBackColor = true;
            this.uxDeleteTopic.Click += new System.EventHandler(this.uxDeleteTopic_Click);
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
            this.uxPostHistoryGrid.TabIndex = 12;
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
            // PublisherGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 321);
            this.Controls.Add(this.uxPostHistoryGrid);
            this.Controls.Add(this.uxDeleteTopic);
            this.Controls.Add(this.uxTopicDropDown);
            this.Controls.Add(this.uxPostToTopicLabel);
            this.Controls.Add(this.uxHistoryLabel);
            this.Controls.Add(this.uxPostMessageButton);
            this.Controls.Add(this.uxMessageBox);
            this.Controls.Add(this.uxTopicTextBox);
            this.Controls.Add(this.uxCreateTopicButton);
            this.Controls.Add(this.uxPostLabel);
            this.Controls.Add(this.uxNewTopicLabel);
            this.Name = "PublisherGUI";
            this.Text = "PublisherGUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PublisherGUI_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.uxPostHistoryGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxNewTopicLabel;
        private System.Windows.Forms.Label uxPostLabel;
        private System.Windows.Forms.Button uxCreateTopicButton;
        private System.Windows.Forms.TextBox uxTopicTextBox;
        private System.Windows.Forms.TextBox uxMessageBox;
        private System.Windows.Forms.Button uxPostMessageButton;
        private System.Windows.Forms.Label uxHistoryLabel;
        private System.Windows.Forms.Label uxPostToTopicLabel;
        private System.Windows.Forms.ComboBox uxTopicDropDown;
        private System.Windows.Forms.Button uxDeleteTopic;
        private System.Windows.Forms.DataGridView uxPostHistoryGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn topicNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeColumn;
    }
}