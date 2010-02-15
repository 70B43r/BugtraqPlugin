namespace BugtraqPlugin.Forms
{
   partial class MainForm
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
         this.listViewIssues = new System.Windows.Forms.ListView();
         this.columnCheckBox = new System.Windows.Forms.ColumnHeader();
         this.columnIssueId = new System.Windows.Forms.ColumnHeader();
         this.columnSummary = new System.Windows.Forms.ColumnHeader();
         this.buttonOK = new System.Windows.Forms.Button();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // listViewIssues
         // 
         this.listViewIssues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.listViewIssues.CheckBoxes = true;
         this.listViewIssues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnCheckBox,
            this.columnIssueId,
            this.columnSummary});
         this.listViewIssues.FullRowSelect = true;
         this.listViewIssues.Location = new System.Drawing.Point(12, 12);
         this.listViewIssues.Name = "listViewIssues";
         this.listViewIssues.Size = new System.Drawing.Size(620, 309);
         this.listViewIssues.TabIndex = 2;
         this.listViewIssues.UseCompatibleStateImageBehavior = false;
         this.listViewIssues.View = System.Windows.Forms.View.Details;
         // 
         // columnCheckBox
         // 
         this.columnCheckBox.Text = "";
         this.columnCheckBox.Width = 39;
         // 
         // columnIssueId
         // 
         this.columnIssueId.Text = "#";
         // 
         // columnSummary
         // 
         this.columnSummary.Text = "Summary";
         this.columnSummary.Width = 350;
         // 
         // buttonOK
         // 
         this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(12, 328);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 3;
         this.buttonOK.Text = "OK";
         this.buttonOK.UseVisualStyleBackColor = true;
         // 
         // buttonCancel
         // 
         this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(557, 328);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 4;
         this.buttonCancel.Text = "Cancel";
         this.buttonCancel.UseVisualStyleBackColor = true;
         // 
         // MainForm
         // 
         this.AcceptButton = this.buttonOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(644, 362);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.listViewIssues);
         this.Name = "MainForm";
         this.Text = "Issues";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ListView listViewIssues;
      private System.Windows.Forms.ColumnHeader columnCheckBox;
      private System.Windows.Forms.ColumnHeader columnIssueId;
      private System.Windows.Forms.ColumnHeader columnSummary;
      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.Button buttonCancel;
   }
}