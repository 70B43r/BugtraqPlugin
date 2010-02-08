//////////////////////////////////////////////////////////////////////////////////
//
// Project            : Tortoise Bugtraq Plugin
// Module:            : BugtraqPlugin
// Description        : Form base class.
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

using System.Windows.Forms;
using BugtraqPlugin.DomainModel.Parameter;

namespace BugtraqPlugin.Forms
{
   /// <summary>
   /// Form base class.
   /// </summary>
   public partial class PluginFormBase : Form
   {
      #region Properties

      /// <summary>
      /// Gets the current parameters.
      /// </summary>
      public PluginParameter Parameter { get; private set; }

      #endregion

      #region Constructors

      /// <summary>
      /// Initializes a new instance of the <see cref="PluginFormBase"/> class.
      /// </summary>
      private PluginFormBase()
      {
         InitializeComponent();
         this.DialogResult = DialogResult.Cancel;
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="PluginFormBase"/> class.
      /// </summary>
      /// <param name="parameter">The parameter.</param>
      public PluginFormBase(PluginParameter parameter)
         : this()
      {
         this.Parameter = parameter;
      }

      #endregion
   }
}
