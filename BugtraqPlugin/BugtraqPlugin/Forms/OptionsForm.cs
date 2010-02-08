//////////////////////////////////////////////////////////////////////////////////
//
// Project            : Tortoise Bugtraq Plugin
// Module:            : BugtraqPlugin
// Description        : Options form.
// 
// Repository         : $URL$
// Last changed by    : $LastChangedBy$
// Revision           : $LastChangedRevision$
// Last Changed       : $LastChangedDate$
// Author             : $Author$
//
// Id:                : $Id$
//
// Copyright:         (c) 2010 Torsten Bär
//
// Published under the MIT License. See license.txt or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////

using System;
using System.ComponentModel;
using BugtraqPlugin.DomainModel.Parameter;
using System.Windows.Forms;

namespace BugtraqPlugin.Forms
{
   /// <summary>
   /// Options form.
   /// </summary>
   public partial class OptionsForm : PluginFormBase
   {
      #region Properties

      #endregion

      #region Constructors

      /// <summary>
      /// Initializes a new instance of the <see cref="OptionsForm"/> class.
      /// </summary>
      /// <param name="parameter">The parameter.</param>
      public OptionsForm(PluginParameter parameter)
         : base(parameter)
      {
         InitializeComponent();

         if (parameter.BugtrackUri != null)
            this.textBoxProjectUri.Text = parameter.BugtrackUri.AbsoluteUri;

         if (!String.IsNullOrEmpty(parameter.UserName))
            textBoxUser.Text = parameter.UserName;

         if (!String.IsNullOrEmpty(parameter.Password))
            textBoxPass.Text = parameter.Password;

         radioButtonSupplied.Checked = !String.IsNullOrEmpty(parameter.UserName) || !String.IsNullOrEmpty(parameter.UserName);

         if (parameter.UseCurrentUser.HasValue)
            radioButtonCurrentUser.Checked = parameter.UseCurrentUser.Value;

         if (!radioButtonSupplied.Checked && !radioButtonCurrentUser.Checked)
            radioButtonNoCredentials.Checked = true;
      }

      #endregion

      #region Methods

      /// <summary>
      /// Raises the <see cref="E:System.Windows.Forms.Form.Closing"/> event.
      /// </summary>
      /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"/> that contains the event data.</param>
      protected override void OnClosing(CancelEventArgs e)
      {
         Uri uri = null;
         if (!String.IsNullOrEmpty(textBoxProjectUri.Text))
         {
            if (Uri.TryCreate(textBoxProjectUri.Text, UriKind.Absolute, out uri))
            {
               if (!uri.IsWellFormedOriginalString())
               {
                  textBoxProjectUri.Text = Uri.EscapeUriString(textBoxProjectUri.Text);
                  uri = new Uri(textBoxProjectUri.Text);
               }
               errorProvider.SetError(textBoxProjectUri, null);
            }
            else
            {
               errorProvider.SetError(textBoxProjectUri, "Uri is not valid.");
            }
         }
         else
         {
            errorProvider.SetError(textBoxProjectUri, "Please enter project url.");
         }

         e.Cancel = uri == null;

         if (!e.Cancel)
         {
            if (radioButtonSupplied.Checked && String.IsNullOrEmpty(textBoxUser.Text))
            {
               e.Cancel = true;
               errorProvider.SetError(textBoxUser, "Username missing");
            }
            else
            {
               errorProvider.SetError(textBoxUser, null);

               if (Parameter.BugtrackUri == null || uri.AbsoluteUri.ToLower() != Parameter.BugtrackUri.AbsoluteUri)
                  Parameter.BugtrackUri = uri;

               if (radioButtonNoCredentials.Checked)
               {
                  Parameter.UseCurrentUser = null;
                  Parameter.UserName = null;
                  Parameter.Password = null;
               }
               else if (radioButtonCurrentUser.Checked)
               {
                  Parameter.UseCurrentUser = true;
                  Parameter.UserName = null;
                  Parameter.Password = null;
               }
               else if (radioButtonSupplied.Checked)
               {
                  Parameter.UseCurrentUser = false;
                  Parameter.UserName = textBoxUser.Text;
                  Parameter.Password = textBoxPass.Text;
               }
            }
         }

      #endregion

         base.OnClosing(e);
      }

      #region Eventhandler

      /// <summary>
      /// Handles the CheckedChanged event of the radioButton control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
      private void radioButton_CheckedChanged(object sender, EventArgs e)
      {
         textBoxUser.Enabled = radioButtonSupplied.Checked;
         textBoxPass.Enabled = radioButtonSupplied.Checked;
      }

      #endregion
   }
}
