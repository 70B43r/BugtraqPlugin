//////////////////////////////////////////////////////////////////////////////////
//
// Project            : Tortoise Bugtraq Plugin
// Module:            : BugtraqPluginDataProvider
// Description        : Data provider for Redmine Bugtraq system.
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
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using BugtraqPlugin.Contracts.DomainModel;
using BugtraqPlugin.Contracts.DomainModel.Parameter;
using Microsoft.Practices.Unity;

namespace BugtraqPlugin.DataProvider
{
   /// <summary>
   /// Data provider for Redmine bugtrack system.
   /// </summary>
   internal class RedmineDataProvider : WebDataProvider
   {
      #region Constants

      private const string ISSUE_DATAPATH = "issues";
      private const string ISSUE_QUERY = "format=csv";

      #endregion

      #region Fields

      private Uri dataRequestUri;

      #endregion

      #region Properties

      /// <summary>
      /// Gets the data request URI.
      /// </summary>
      protected override Uri DataRequestUri
      {
         get
         {
            if (dataRequestUri == null)
            {
               UriBuilder builder = new UriBuilder(Parameter.BugtrackUri);
               builder.Path += builder.Path.EndsWith("/") ? ISSUE_DATAPATH : "/" + ISSUE_DATAPATH;
               builder.Query = ISSUE_QUERY;
               dataRequestUri = builder.Uri;
            }
            return dataRequestUri;
         }
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Initializes a new instance of the <see cref="RedmineDataProvider"/> class.
      /// </summary>
      /// <param name="parameter">The parameter.</param>
      [InjectionConstructor]
      public RedmineDataProvider([Dependency]PluginParameter parameter)
         : base(parameter)
      { }

      #endregion

      #region Methods

      /// <summary>
      /// Handles loaded data.
      /// </summary>
      /// <param name="data">The data.</param>
      protected override void HandleData(string data)
      {
         using (StringReader reader = new StringReader(data))
         {
            string line = reader.ReadLine(); // skip column definition
            StringBuilder dataCache = new StringBuilder();
            while ((line = reader.ReadLine()) != null)
            {
               // new issue?
               if (Regex.IsMatch(line, @"^\d+;", RegexOptions.Singleline) && dataCache.Length > 0)
               {
                  HandleTicketData(dataCache.ToString());
                  dataCache.Length = 0;
               }

               dataCache.AppendLine(line);
            }

            // process last issue
            HandleTicketData(dataCache.ToString());
         }
      }

      /// <summary>
      /// Handles the ticket data.
      /// </summary>
      /// <param name="data">The data.</param>
      private void HandleTicketData(string data)
      {
         if (!String.IsNullOrEmpty(data))
         {
            using (StringReader reader = new StringReader(data))
            {
               string line = reader.ReadLine();
               string[] lineData = line.Split(';');

               int id = int.Parse(lineData[0]);

               this.Issues.Add(new Issue(id, lineData[5]));
            }
         }
      }

      #endregion
   }
}
