//////////////////////////////////////////////////////////////////////////////////
//
// Project            : Tortoise Bugtraq Plugin
// Module:            : BugtraqPlugin
// Description        : Plugin main form.
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
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using BugtraqPlugin.DomainModel;
using BugtraqPlugin.DomainModel.Parameter;

namespace BugtraqPlugin.Forms
{
   /// <summary>
   /// Main form of the Plugin.
   /// </summary>
   public partial class MainForm : PluginFormBase
   {
      #region Properties

      /// <summary>
      /// Gets or sets the data provider.
      /// </summary>
      /// <value>The data provider.</value>
      public DataProvider.DataProvider DataProvider { get; private set; }

      /// <summary>
      /// Gets the selected issues.
      /// </summary>
      public ReadOnlyCollection<Issue> SelectedIssues
      {
         get
         {
            List<Issue> selected = listViewIssues.Items.Cast<ListViewItem>()
               .Where(item => item.Checked)
               .Select(item => item.Tag)
               .Cast<Issue>()
               .ToList();

            return selected.AsReadOnly();
         }
      }

      #endregion
      
      #region Constructors

      /// <summary>
      /// Initializes a new instance of the <see cref="MainForm"/> class.
      /// </summary>
      /// <param name="parameter">The parameter.</param>
      /// <param name="dataProvider">The data provider.</param>
      public MainForm(PluginParameter parameter, DataProvider.DataProvider dataProvider)
         : base(parameter)
      {
         InitializeComponent();

         this.DataProvider = dataProvider;
      }

      #endregion

      #region Methods

      /// <summary>
      /// Raises the <see cref="E:System.Windows.Forms.Form.Load"/> event.
      /// </summary>
      /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
      protected override void OnLoad(EventArgs e)
      {
         base.OnLoad(e);

         foreach (Issue issue in DataProvider.Issues)
         {
            this.listViewIssues.Items.Add(new ListViewItem(new string[] { 
               null, issue.Id.ToString(), issue.Summary
            })).Tag = issue;
         }
      }

      #endregion
   }
}
