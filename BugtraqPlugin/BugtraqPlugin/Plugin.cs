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
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BugtraqPlugin.Contracts;
using BugtraqPlugin.Contracts.DomainModel.Parameter;
using BugtraqPlugin.Forms;
using Interop.BugTraqProvider;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace BugtraqPlugin
{
   /// <summary>
   /// Plugin main class.
   /// </summary>
   [ComVisible(true), ClassInterface(ClassInterfaceType.None),
   Guid("3F568A2A-3AAC-4B0D-B187-F1240F931152")]
   public sealed class Plugin : IBugTraqProvider, IBugTraqProvider2, IDisposable
   {
      #region Fields

      private IUnityContainer microkernel;
      private UnityConfigurationSection config;

      #endregion

      #region Properties

      /// <summary>
      /// Gets the config.
      /// </summary>
      internal UnityConfigurationSection Config
      {
         get
         {
            if (config == null)
               config = (UnityConfigurationSection)ConfigurationManager.OpenExeConfiguration(GetType().Assembly.Location).GetSection("microkernel");

            return config;
         }
      }

      /// <summary>
      /// Gets the configured providers.
      /// </summary>
      internal IEnumerable<TypeMapping> ConfiguredProviders
      {
         get
         {
            Type dataProviderInterfaceType = typeof(IDataProvider);
            IEnumerable<TypeMapping> dataprovides = Config.Containers.Default.Types
               .Cast<UnityTypeElement>()
               .Where(typeElement => dataProviderInterfaceType.IsAssignableFrom(typeElement.MapTo))
               .Select(typeElement => new TypeMapping() { 
                  Name = typeElement.Name, 
                  From = typeElement.Type, 
                  To = typeElement.MapTo });

            return dataprovides;
         }
      }

      /// <summary>
      /// The DI-Container.
      /// </summary>
      internal IUnityContainer Microkernel
      {
         get
         {
            if (microkernel == null)
            {
               microkernel = new UnityContainer();
               Config.Containers.Default.Configure(microkernel);
            }

            return microkernel;
         }
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Initializes a new instance of the <see cref="Plugin"/> class.
      /// </summary>
      public Plugin()
      {
         AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
      }

      #endregion

      #region IBugTraqProvider Member

      /// <summary>
      /// Gets the commit message.
      /// See Documentation of <see cref="Interop.BugTraqProvider.IBugTraqProvider"/>
      /// </summary>
      /// <param name="hParentWnd">Handle to parent window.</param>
      /// <param name="parameters">The parameter string.</param>
      /// <param name="commonRoot">Parent root of all items</param>
      /// <param name="pathList">Pathes of the items.</param>
      /// <param name="originalMessage">The original commit message.</param>
      /// <returns>The new commit message.</returns>
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
      /// <param name="hParentWnd">Handle to parent window.</param>
      /// <param name="parameters">The parameter string.</param>
      /// <returns>The text displayed on the button.</returns>
      public string GetLinkText(IntPtr hParentWnd, string parameters)
      {
         return StringResources.LinkText;
      }

      /// <summary>
      /// Validates the plugin parameters.
      /// </summary>
      /// <param name="hParentWnd">Handle to the parent window.</param>
      /// <param name="parameters">The parameter string.</param>
      /// <returns><code>true</code> if parameters are valid; otherwise <code>false</code>.</returns>
      public bool ValidateParameters(IntPtr hParentWnd, string parameters)
      {
         return PluginParameter.Validate(parameters);
      }

      #endregion

      #region IBugTraqProvider2 Member

      /// <summary>
      /// Checks the state before commiting changes to the repository.
      /// See Documentation of <see cref="Interop.BugTraqProvider.IBugTraqProvider2"/>
      /// </summary>
      /// <param name="hParentWnd">Handle to parent window.</param>
      /// <param name="parameters">The parameter string.</param>
      /// <param name="commonURL">The parent URL of all items.</param>
      /// <param name="commonRoot">Parent root of all items</param>
      /// <param name="pathList">Pathes of the items.</param>
      /// <param name="commitMessage">The commit message.</param>
      /// <returns>The new commit message.</returns>
      public string CheckCommit(IntPtr hParentWnd, string parameters, string commonURL, string commonRoot, string[] pathList, string commitMessage)
      {
         return String.Empty;
      }

      /// <summary>
      /// Gets the commit message.
      /// See Documentation of <see cref="Interop.BugTraqProvider.IBugTraqProvider2"/>
      /// </summary>
      /// <param name="hParentWnd">Handle to parent window.</param>
      /// <param name="parameters">The parameter string.</param>
      /// <param name="commonURL">The parent URL of all items.</param>
      /// <param name="commonRoot">Parent root of all items</param>
      /// <param name="pathList">Pathes of the items.</param>
      /// <param name="originalMessage">The original commit message.</param>
      /// <param name="bugID">The bug ID.</param>
      /// <param name="bugIDOut">The bug ID out.</param>
      /// <param name="revPropNames">The revision property names.</param>
      /// <param name="revPropValues">The revision property values.</param>
      /// <returns>The new commit message.</returns>
      public string GetCommitMessage2(IntPtr hParentWnd, string parameters, string commonURL, string commonRoot, string[] pathList, string originalMessage, string bugID, out string bugIDOut, out string[] revPropNames, out string[] revPropValues)
      {
         bugIDOut = bugID;
         revPropNames = new string[0];
         revPropValues = new string[0];

         if (!PluginParameter.Validate(parameters))
         {
            MessageBox.Show(StringResources.Error_ParameterInvalid, StringResources.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return originalMessage;
         }

         PluginParameter parameter = new PluginParameter(parameters);
         Microkernel.RegisterInstance(parameter.GetType(), parameter);

         IDataProvider dataProvider = Microkernel.Resolve<IDataProvider>(parameter.DataProvider);

         MainForm main = new MainForm(dataProvider);
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
      /// Could be used to perform additional actions.
      /// </summary>
      /// <param name="hParentWnd">Handle to parent window.</param>
      /// <param name="commonRoot">The root path of all items.</param>
      /// <param name="pathList">The pathes of all items.</param>
      /// <param name="logMessage">The original logmessage.</param>
      /// <param name="revision">The revision</param>
      /// <returns>The new logmessage.</returns>
      public string OnCommitFinished(IntPtr hParentWnd, string commonRoot, string[] pathList, string logMessage, int revision)
      {
         return null;
      }

      /// <summary>
      /// Shows the options dialog.
      /// </summary>
      /// <param name="hParentWnd">Handle to parent window.</param>
      /// <param name="parameters">The parameter string.</param>
      /// <returns>The new parameter string.</returns>
      public string ShowOptionsDialog(IntPtr hParentWnd, string parameters)
      {
         PluginParameter parameter = new PluginParameter(parameters);

         OptionsForm options = new OptionsForm(parameter, ConfiguredProviders.Select(typeMapping => typeMapping.Name));
         if (options.ShowDialog() == DialogResult.OK)
         {
            return options.Parameter.ParameterString();
         }

         return parameters;
      }

      #endregion

      #region IDisposable Member

      /// <summary>
      /// Releases unmanaged resources and performs other cleanup operations before the
      /// <see cref="Plugin"/> is reclaimed by garbage collection.
      /// </summary>
      ~Plugin()
      {
         Dispose(false);
      }

      /// <summary>
      /// Releases unmanaged and - optionally - managed resources
      /// </summary>
      /// <param name="userDispose"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
      private void Dispose(bool userDispose)
      {
         if (userDispose)
         {
            if (microkernel != null)
               microkernel.Dispose();
         }

         AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
      }

      /// <summary>
      /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
      /// </summary>
      public void Dispose()
      {
         this.Dispose(true);
         GC.SuppressFinalize(this);
      }

      #endregion

      #region Eventhandler

      /// <summary>
      /// Handles the AssemblyResolve event of the CurrentDomain control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="args">The <see cref="System.ResolveEventArgs"/> instance containing the event data.</param>
      /// <returns>Returns the loaded <see cref="System.Reflection.Assembly"/> or <code>null</code>.</returns>
      private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
      {
         string searchLocation = Path.GetDirectoryName(GetType().Assembly.Location);

         AssemblyName assemblyName = new AssemblyName(args.Name);

         foreach (string candidate in Directory.GetFiles(searchLocation, assemblyName.Name + "*", SearchOption.AllDirectories))
         {
            try
            {
               AssemblyName candidateName = AssemblyName.GetAssemblyName(candidate);
               if (AssemblyName.ReferenceMatchesDefinition(assemblyName, candidateName))
                  return Assembly.Load(candidateName);
            }
            catch
            {
               // not a .NET assembly
            }
         }
         return null;
      }

      #endregion
   }
}