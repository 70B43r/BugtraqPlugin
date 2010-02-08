//////////////////////////////////////////////////////////////////////////////////
//
// Project            : Tortoise Bugtraq Plugin
// Module:            : BugtraqPlugin
// Description        : Main plugin class.
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
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BugtraqPlugin.DomainModel.Parameter;
using BugtraqPlugin.Forms;
using Interop.BugTraqProvider;

namespace BugtraqPlugin
{
   /// <summary>
   /// Plugin main class.
   /// </summary>
   [ComVisible(true), ClassInterface(ClassInterfaceType.None),
   Guid("3F568A2A-3AAC-4B0D-B187-F1240F931152")]
   public class Plugin : IBugTraqProvider, IBugTraqProvider2
   {
      #region IBugTraqProvider Member

      /// <summary>
      /// Gets the commit message.
      /// </summary>
      /// <param name="hParentWnd"></param>
      /// <param name="parameters"></param>
      /// <param name="commonRoot"></param>
      /// <param name="pathList"></param>
      /// <param name="originalMessage"></param>
      /// <returns></returns>
      public string GetCommitMessage(IntPtr hParentWnd, string parameters, string commonRoot, string[] pathList, string originalMessage)
      {
         string bugIDOut;
         string[] revPropNames = new string[0];
         string[] revPropValues = new string[0];

         return GetCommitMessage2(hParentWnd, parameters, String.Empty, commonRoot, pathList, originalMessage, String.Empty, out bugIDOut, out revPropNames, out revPropValues);
      }

      /// <summary>
      /// Gets the link text.
      /// </summary>
      /// <param name="hParentWnd"></param>
      /// <param name="parameters"></param>
      /// <returns></returns>
      public string GetLinkText(IntPtr hParentWnd, string parameters)
      {
         return StringResources.LinkText;
      }

      /// <summary>
      /// Validates the plugin parameters.
      /// </summary>
      /// <param name="hParentWnd"></param>
      /// <param name="parameters"></param>
      /// <returns></returns>
      public bool ValidateParameters(IntPtr hParentWnd, string parameters)
      {
         return PluginParameter.Validate(parameters);
      }

      #endregion

      #region IBugTraqProvider2 Member

      /// <summary>
      /// Checks the state before commiting changes to the repository.
      /// </summary>
      /// <param name="hParentWnd"></param>
      /// <param name="parameters"></param>
      /// <param name="commonURL"></param>
      /// <param name="commonRoot"></param>
      /// <param name="pathList"></param>
      /// <param name="commitMessage"></param>
      /// <returns></returns>
      public string CheckCommit(IntPtr hParentWnd, string parameters, string commonURL, string commonRoot, string[] pathList, string commitMessage)
      {
         return String.Empty;
      }

      /// <summary>
      /// Gets the commit message.
      /// </summary>
      /// <param name="hParentWnd"></param>
      /// <param name="parameters"></param>
      /// <param name="commonURL"></param>
      /// <param name="commonRoot"></param>
      /// <param name="pathList"></param>
      /// <param name="originalMessage"></param>
      /// <param name="bugID"></param>
      /// <param name="bugIDOut"></param>
      /// <param name="revPropNames"></param>
      /// <param name="revPropValues"></param>
      /// <returns></returns>
      public string GetCommitMessage2(IntPtr hParentWnd, string parameters, string commonURL, string commonRoot, string[] pathList, string originalMessage, string bugID, out string bugIDOut, out string[] revPropNames, out string[] revPropValues)
      {
         bugIDOut = bugID;
         revPropNames = new string[0];
         revPropValues = new string[0];

         PluginParameter parameter = new PluginParameter(parameters);

         DataProvider.DataProvider dataProvider = DataProvider.DataProviderFactory.GetProvider(parameter);

         MainForm main = new MainForm(parameter, dataProvider);
         if (main.ShowDialog() == DialogResult.OK)
         {
            string newBugIds = String.Join(",", main.SelectedIssues.Select(issue => issue.Id.ToString()).ToArray());

            if (!String.IsNullOrEmpty(bugID))
               bugIDOut = String.Concat(bugID, ",", newBugIds);
            else
               bugIDOut = newBugIds;

            return String.Concat(originalMessage, Environment.NewLine, Environment.NewLine,
               "fixes " + String.Join(", ", main.SelectedIssues.Select(issue => String.Format("#{0}", issue.Id)).ToArray()));
         }

         return originalMessage;
      }

      /// <summary>
      /// Indicates that the plugin provides options.
      /// </summary>
      /// <returns><code>true</code> if plugin publishes options, otherwise <code>false</code>.</returns>
      public bool HasOptions()
      {
         return true;
      }

      /// <summary>
      /// Called after successful commit.
      /// Could be used to 
      /// </summary>
      /// <param name="hParentWnd"></param>
      /// <param name="commonRoot"></param>
      /// <param name="pathList"></param>
      /// <param name="logMessage"></param>
      /// <param name="revision"></param>
      /// <returns></returns>
      public string OnCommitFinished(IntPtr hParentWnd, string commonRoot, string[] pathList, string logMessage, int revision)
      {
         return null;
      }

      /// <summary>
      /// Shows the options dialog.
      /// </summary>
      /// <param name="hParentWnd"></param>
      /// <param name="parameters"></param>
      /// <returns></returns>
      public string ShowOptionsDialog(IntPtr hParentWnd, string parameters)
      {
         PluginParameter parameter = new PluginParameter(parameters);

         OptionsForm options = new OptionsForm(parameter);
         if (options.ShowDialog() == DialogResult.OK)
         {
            return options.Parameter.ParameterString();
         }
         return parameters;
      }

      #endregion
   }
}