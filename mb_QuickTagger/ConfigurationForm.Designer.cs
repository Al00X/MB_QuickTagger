namespace MusicBeePlugin
{
    partial class ConfigurationForm
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
            this.tagTable = new System.Windows.Forms.DataGridView();
            this.tableTagField = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tableValueField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tableAddBtn = new System.Windows.Forms.Button();
            this.tableRemoveBtn = new System.Windows.Forms.Button();
            this.aboytLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tagTable)).BeginInit();
            this.SuspendLayout();
            // 
            // tagTable
            // 
            this.tagTable.AllowUserToAddRows = false;
            this.tagTable.AllowUserToDeleteRows = false;
            this.tagTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tagTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tableTagField,
            this.tableValueField});
            this.tagTable.Location = new System.Drawing.Point(12, 33);
            this.tagTable.MultiSelect = false;
            this.tagTable.Name = "tagTable";
            this.tagTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tagTable.Size = new System.Drawing.Size(642, 257);
            this.tagTable.TabIndex = 1;
            // 
            // tableTagField
            // 
            this.tableTagField.HeaderText = "Tag Name";
            this.tableTagField.Name = "tableTagField";
            this.tableTagField.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tableTagField.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tableTagField.Width = 130;
            // 
            // tableValueField
            // 
            this.tableValueField.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tableValueField.HeaderText = "Values (separate using semicolon)";
            this.tableValueField.Name = "tableValueField";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tags: ";
            // 
            // tableAddBtn
            // 
            this.tableAddBtn.Location = new System.Drawing.Point(499, 296);
            this.tableAddBtn.Name = "tableAddBtn";
            this.tableAddBtn.Size = new System.Drawing.Size(66, 23);
            this.tableAddBtn.TabIndex = 3;
            this.tableAddBtn.Text = "+ Add";
            this.tableAddBtn.UseVisualStyleBackColor = true;
            this.tableAddBtn.Click += new System.EventHandler(this.tableAddBtn_Click);
            // 
            // tableRemoveBtn
            // 
            this.tableRemoveBtn.Location = new System.Drawing.Point(571, 296);
            this.tableRemoveBtn.Name = "tableRemoveBtn";
            this.tableRemoveBtn.Size = new System.Drawing.Size(75, 23);
            this.tableRemoveBtn.TabIndex = 4;
            this.tableRemoveBtn.Text = "- Remove";
            this.tableRemoveBtn.UseVisualStyleBackColor = true;
            this.tableRemoveBtn.Click += new System.EventHandler(this.tableRemoveBtn_Click);
            // 
            // aboytLbl
            // 
            this.aboytLbl.AutoSize = true;
            this.aboytLbl.Location = new System.Drawing.Point(9, 403);
            this.aboytLbl.Name = "aboytLbl";
            this.aboytLbl.Size = new System.Drawing.Size(120, 13);
            this.aboytLbl.TabIndex = 6;
            this.aboytLbl.Text = "QuickTagger by Al00X -";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(373, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "NOTE: You have to restart the program to apply all the changes.\r\n";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(479, 377);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(86, 34);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(571, 377);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(86, 34);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(669, 423);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.aboytLbl);
            this.Controls.Add(this.tableRemoveBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.tableAddBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tagTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quick Tagger Configuration";
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tagTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView tagTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button tableAddBtn;
        private System.Windows.Forms.Button tableRemoveBtn;
        private System.Windows.Forms.Label aboytLbl;
        private System.Windows.Forms.DataGridViewComboBoxColumn tableTagField;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableValueField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}