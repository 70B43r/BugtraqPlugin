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
         this.groupBoxProjectUri = new System.Windows.Forms.GroupBox();
         this.groupBoxUserCredentials = new System.Windows.Forms.GroupBox();
         this.labelPass = new System.Windows.Forms.Label();
         this.labelUser = new System.Windows.Forms.Label();
         this.textBoxPass = new System.Windows.Forms.TextBox();
         this.textBoxUser = new System.Windows.Forms.TextBox();
         this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
         this.groupBoxProjectUri.SuspendLayout();
         this.groupBoxUserCredentials.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
         this.SuspendLayout();
         // 
         // textBoxProjectUri
         // 
         this.textBoxProjectUri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.errorProvider.SetIconPadding(this.textBoxProjectUri, -20);
         this.textBoxProjectUri.Location = new System.Drawing.Point(6, 19);
         this.textBoxProjectUri.Name = "textBoxProjectUri";
         this.textBoxProjectUri.Size = new System.Drawing.Size(548, 20);
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
         // groupBoxProjectUri
         // 
         this.groupBoxProjectUri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxProjectUri.Controls.Add(this.textBoxProjectUri);
         this.groupBoxProjectUri.Location = new System.Drawing.Point(12, 12);
         this.groupBoxProjectUri.Name = "groupBoxProjectUri";
         this.groupBoxProjectUri.Size = new System.Drawing.Size(560, 53);
         this.groupBoxProjectUri.TabIndex = 6;
         this.groupBoxProjectUri.TabStop = false;
         this.groupBoxProjectUri.Text = "Project-URL";
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
         this.groupBoxUserCredentials.Size = new System.Drawing.Size(432, 144);
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
         this.textBoxPass.Size = new System.Drawing.Size(130, 20);
         this.textBoxPass.TabIndex = 7;
         this.textBoxPass.UseSystemPasswordChar = true;
         // 
         // textBoxUser
         // 
         this.textBoxUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxUser.Location = new System.Drawing.Point(96, 88);
         this.textBoxUser.Name = "textBoxUser";
         this.textBoxUser.Size = new System.Drawing.Size(130, 20);
         this.textBoxUser.TabIndex = 6;
         // 
         // errorProvider
         // 
         this.errorProvider.ContainerControl = this;
         // 
         // OptionsForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(584, 314);
         this.Controls.Add(this.groupBoxProjectUri);
         this.Controls.Add(this.groupBoxUserCredentials);
         this.Name = "OptionsForm";
         this.Text = "OptionsForm";
         this.Controls.SetChildIndex(this.groupBoxUserCredentials, 0);
         this.Controls.SetChildIndex(this.groupBoxProjectUri, 0);
         this.groupBoxProjectUri.ResumeLayout(false);
         this.groupBoxProjectUri.PerformLayout();
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
      private System.Windows.Forms.GroupBox groupBoxProjectUri;
      private System.Windows.Forms.GroupBox groupBoxUserCredentials;
      private System.Windows.Forms.TextBox textBoxPass;
      private System.Windows.Forms.TextBox textBoxUser;
      private System.Windows.Forms.Label labelPass;
      private System.Windows.Forms.Label labelUser;
      private System.Windows.Forms.ErrorProvider errorProvider;
   }
}