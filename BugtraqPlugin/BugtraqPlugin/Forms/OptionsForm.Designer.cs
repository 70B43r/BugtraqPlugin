namespace BugtraqPlugin.Forms
{
   partial class OptionsForm
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
         this.components = new System.ComponentModel.Container();
         this.textBoxProjectUri = new System.Windows.Forms.TextBox();
         this.radioButtonNoCredentials = new System.Windows.Forms.RadioButton();
         this.radioButtonSupplied = new System.Windows.Forms.RadioButton();
         this.radioButtonCurrentUser = new System.Windows.Forms.RadioButton();
         this.groupBoxBugtraqSystem = new System.Windows.Forms.GroupBox();
         this.labelURL = new System.Windows.Forms.Label();
         this.comboBoxDataProvider = new System.Windows.Forms.ComboBox();
         this.groupBoxUserCredentials = new System.Windows.Forms.GroupBox();
         this.labelPass = new System.Windows.Forms.Label();
         this.labelUser = new System.Windows.Forms.Label();
         this.textBoxPass = new System.Windows.Forms.TextBox();
         this.textBoxUser = new System.Windows.Forms.TextBox();
         this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
         this.buttonOK = new System.Windows.Forms.Button();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.groupBoxBugtraqSystem.SuspendLayout();
         this.groupBoxUserCredentials.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
         this.SuspendLayout();
         // 
         // textBoxProjectUri
         // 
         this.textBoxProjectUri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.errorProvider.SetIconPadding(this.textBoxProjectUri, -20);
         this.textBoxProjectUri.Location = new System.Drawing.Point(214, 19);
         this.textBoxProjectUri.Name = "textBoxProjectUri";
         this.textBoxProjectUri.Size = new System.Drawing.Size(312, 20);
         this.textBoxProjectUri.TabIndex = 2;
         // 
         // radioButtonNoCredentials
         // 
         this.radioButtonNoCredentials.AutoSize = true;
         this.radioButtonNoCredentials.Location = new System.Drawing.Point(6, 19);
         this.radioButtonNoCredentials.Name = "radioButtonNoCredentials";
         this.radioButtonNoCredentials.Size = new System.Drawing.Size(51, 17);
         this.radioButtonNoCredentials.TabIndex = 3;
         this.radioButtonNoCredentials.TabStop = true;
         this.radioButtonNoCredentials.Text = "None";
         this.radioButtonNoCredentials.UseVisualStyleBackColor = true;
         // 
         // radioButtonSupplied
         // 
         this.radioButtonSupplied.AutoSize = true;
         this.radioButtonSupplied.Location = new System.Drawing.Point(6, 65);
         this.radioButtonSupplied.Name = "radioButtonSupplied";
         this.radioButtonSupplied.Size = new System.Drawing.Size(121, 17);
         this.radioButtonSupplied.TabIndex = 4;
         this.radioButtonSupplied.Text = "Supplied Credentials";
         this.radioButtonSupplied.UseVisualStyleBackColor = true;
         this.radioButtonSupplied.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
         // 
         // radioButtonCurrentUser
         // 
         this.radioButtonCurrentUser.AutoSize = true;
         this.radioButtonCurrentUser.Checked = true;
         this.radioButtonCurrentUser.Location = new System.Drawing.Point(6, 42);
         this.radioButtonCurrentUser.Name = "radioButtonCurrentUser";
         this.radioButtonCurrentUser.Size = new System.Drawing.Size(84, 17);
         this.radioButtonCurrentUser.TabIndex = 5;
         this.radioButtonCurrentUser.TabStop = true;
         this.radioButtonCurrentUser.Text = "Current User";
         this.radioButtonCurrentUser.UseVisualStyleBackColor = true;
         // 
         // groupBoxBugtraqSystem
         // 
         this.groupBoxBugtraqSystem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxBugtraqSystem.Controls.Add(this.labelURL);
         this.groupBoxBugtraqSystem.Controls.Add(this.comboBoxDataProvider);
         this.groupBoxBugtraqSystem.Controls.Add(this.textBoxProjectUri);
         this.groupBoxBugtraqSystem.Location = new System.Drawing.Point(12, 12);
         this.groupBoxBugtraqSystem.Name = "groupBoxBugtraqSystem";
         this.groupBoxBugtraqSystem.Size = new System.Drawing.Size(532, 53);
         this.groupBoxBugtraqSystem.TabIndex = 6;
         this.groupBoxBugtraqSystem.TabStop = false;
         this.groupBoxBugtraqSystem.Text = "Bucgtrack-System";
         // 
         // labelURL
         // 
         this.labelURL.AutoSize = true;
         this.labelURL.Location = new System.Drawing.Point(179, 22);
         this.labelURL.Name = "labelURL";
         this.labelURL.Size = new System.Drawing.Size(29, 13);
         this.labelURL.TabIndex = 8;
         this.labelURL.Text = "URL";
         // 
         // comboBoxDataProvider
         // 
         this.comboBoxDataProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxDataProvider.FormattingEnabled = true;
         this.comboBoxDataProvider.Location = new System.Drawing.Point(6, 19);
         this.comboBoxDataProvider.Name = "comboBoxDataProvider";
         this.comboBoxDataProvider.Size = new System.Drawing.Size(155, 21);
         this.comboBoxDataProvider.Sorted = true;
         this.comboBoxDataProvider.TabIndex = 8;
         // 
         // groupBoxUserCredentials
         // 
         this.groupBoxUserCredentials.Controls.Add(this.labelPass);
         this.groupBoxUserCredentials.Controls.Add(this.labelUser);
         this.groupBoxUserCredentials.Controls.Add(this.textBoxPass);
         this.groupBoxUserCredentials.Controls.Add(this.textBoxUser);
         this.groupBoxUserCredentials.Controls.Add(this.radioButtonNoCredentials);
         this.groupBoxUserCredentials.Controls.Add(this.radioButtonSupplied);
         this.groupBoxUserCredentials.Controls.Add(this.radioButtonCurrentUser);
         this.groupBoxUserCredentials.Location = new System.Drawing.Point(12, 71);
         this.groupBoxUserCredentials.Name = "groupBoxUserCredentials";
         this.groupBoxUserCredentials.Size = new System.Drawing.Size(263, 144);
         this.groupBoxUserCredentials.TabIndex = 7;
         this.groupBoxUserCredentials.TabStop = false;
         this.groupBoxUserCredentials.Text = "User Credentials";
         // 
         // labelPass
         // 
         this.labelPass.AutoSize = true;
         this.labelPass.Location = new System.Drawing.Point(35, 117);
         this.labelPass.Name = "labelPass";
         this.labelPass.Size = new System.Drawing.Size(53, 13);
         this.labelPass.TabIndex = 9;
         this.labelPass.Text = "Password";
         // 
         // labelUser
         // 
         this.labelUser.AutoSize = true;
         this.labelUser.Location = new System.Drawing.Point(35, 91);
         this.labelUser.Name = "labelUser";
         this.labelUser.Size = new System.Drawing.Size(55, 13);
         this.labelUser.TabIndex = 8;
         this.labelUser.Text = "Username";
         // 
         // textBoxPass
         // 
         this.textBoxPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxPass.Location = new System.Drawing.Point(96, 114);
         this.textBoxPass.Name = "textBoxPass";
         this.textBoxPass.PasswordChar = '*';
         this.textBoxPass.Size = new System.Drawing.Size(161, 20);
         this.textBoxPass.TabIndex = 7;
         this.textBoxPass.UseSystemPasswordChar = true;
         // 
         // textBoxUser
         // 
         this.textBoxUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxUser.Location = new System.Drawing.Point(96, 88);
         this.textBoxUser.Name = "textBoxUser";
         this.textBoxUser.Size = new System.Drawing.Size(161, 20);
         this.textBoxUser.TabIndex = 6;
         // 
         // errorProvider
         // 
         this.errorProvider.ContainerControl = this;
         // 
         // buttonOK
         // 
         this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(12, 225);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 8;
         this.buttonOK.Text = "OK";
         this.buttonOK.UseVisualStyleBackColor = true;
         // 
         // buttonCancel
         // 
         this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(469, 225);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 9;
         this.buttonCancel.Text = "Cancel";
         this.buttonCancel.UseVisualStyleBackColor = true;
         // 
         // OptionsForm
         // 
         this.AcceptButton = this.buttonOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(556, 260);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.groupBoxBugtraqSystem);
         this.Controls.Add(this.groupBoxUserCredentials);
         this.Name = "OptionsForm";
         this.Text = "OptionsForm";
         this.groupBoxBugtraqSystem.ResumeLayout(false);
         this.groupBoxBugtraqSystem.PerformLayout();
         this.groupBoxUserCredentials.ResumeLayout(false);
         this.groupBoxUserCredentials.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TextBox textBoxProjectUri;
      private System.Windows.Forms.RadioButton radioButtonNoCredentials;
      private System.Windows.Forms.RadioButton radioButtonSupplied;
      private System.Windows.Forms.RadioButton radioButtonCurrentUser;
      private System.Windows.Forms.GroupBox groupBoxBugtraqSystem;
      private System.Windows.Forms.GroupBox groupBoxUserCredentials;
      private System.Windows.Forms.TextBox textBoxPass;
      private System.Windows.Forms.TextBox textBoxUser;
      private System.Windows.Forms.Label labelPass;
      private System.Windows.Forms.Label labelUser;
      private System.Windows.Forms.ErrorProvider errorProvider;
      private System.Windows.Forms.ComboBox comboBoxDataProvider;
      private System.Windows.Forms.Label labelURL;
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.Button buttonOK;
   }
}