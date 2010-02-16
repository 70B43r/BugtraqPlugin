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
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using BugtraqPlugin.Contracts;
using BugtraqPlugin.Contracts.DomainModel.Parameter;
using Microsoft.Practices.Unity.Configuration;

namespace BugtraqPlugin.Forms
{
   /// <summary>
   /// Options form.
   /// </summary>
   public partial class OptionsForm : Form
   {
      #region Properties

      /// <summary>
      /// Gets the current parameters.
      /// </summary>
      public PluginParameter Parameter { get; private set; }

      #endregion

      #region Constructors

      /// <summary>
      /// Initializes a new instance of the <see cref="OptionsForm"/> class.
      /// </summary>
      /// <param name="parameter">The parameter.</param>
      /// <param name="dataProviderNames">The data provider names.</param>
      public OptionsForm(PluginParameter parameter, IEnumerable<string> dataProviderNames)
         : base()
      {
         InitializeComponent();

         this.Parameter = parameter;

         if (parameter.BugtrackUri != null)
            this.textBoxProjectUri.Text = parameter.BugtrackUri.AbsoluteUri;

         if (!String.IsNullOrEmpty(parameter.UserName))
            textBoxUser.Text = parameter.UserName;

         if (!String.IsNullOrEmpty(parameter.Password))
            textBoxPass.Text = parameter.Password;

         radioButtonSupplied.Checked = !String.IsNullOrEmpty(parameter.UserName) || !String.IsNullOrEmpty(parameter.UserName);

         if (parameter.UseCurrentUser.HasValue)
            radioButtonCurrentUser.Checked = parameter.UseCurrentUser.Value;

         if (String.IsNullOrEmpty(parameter.UserName) & String.IsNullOrEmpty(parameter.UserName) && !parameter.UseCurrentUser.HasValue)
            radioButtonNoCredentials.Checked = true;

         foreach (string dataProviderName in dataProviderNames)
         {
            int idx = comboBoxDataProvider.Items.Add(dataProviderName);
            if (StringComparer.InvariantCultureIgnoreCase.Compare(dataProviderName, parameter.DataProvider) == 0)
               comboBoxDataProvider.SelectedIndex = idx;
         }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Raises the <see cref="E:System.Windows.Forms.Form.Closing"/> event.
      /// </summary>
      /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"/> that contains the event data.</param>
      protected override void OnClosing(CancelEventArgs e)
      {
         if (this.DialogResult != DialogResult.Cancel)
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

               if (comboBoxDataProvider.SelectedIndex > -1)
               {
                  errorProvider.SetError(comboBoxDataProvider, null);

                  this.Parameter.DataProvider = comboBoxDataProvider.Items[comboBoxDataProvider.SelectedIndex].ToString();
               }
               else
               {
                  errorProvider.SetError(comboBoxDataProvider, "Dataprovider missing");
                  e.Cancel = true;
               }
            }
         }
         base.OnClosing(e);
      }

      #endregion

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
