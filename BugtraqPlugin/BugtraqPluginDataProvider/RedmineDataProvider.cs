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
using System.Collections.Generic;

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
      public override Uri DataRequestUri
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

#if DEBUG

      /// <summary>
      /// Initializes a new instance of the <see cref="RedmineDataProvider"/> class.
      /// </summary>
      /// <param name="parameter">The parameter.</param>
      /// <param name="dataRequestUri">The data request URI.</param>
      internal RedmineDataProvider(PluginParameter parameter, Uri dataRequestUri)
         : this(parameter)
      {
         this.dataRequestUri = dataRequestUri;
      }

#endif

      #endregion

      #region Methods

      /// <summary>
      /// Handles loaded data.
      /// </summary>
      /// <param name="data">The data.</param>
      protected override IEnumerable<Issue> HandleData(string data)
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
                  yield return HandleTicketData(dataCache.ToString());
                  dataCache.Length = 0;
               }

               dataCache.AppendLine(line);
            }

            // process last issue
            yield return HandleTicketData(dataCache.ToString());
         }
      }

      /// <summary>
      /// Handles the ticket data.
      /// </summary>
      /// <param name="data">The data.</param>
      private Issue HandleTicketData(string data)
      {
         if (!String.IsNullOrEmpty(data))
         {
            using (StringReader reader = new StringReader(data))
            {
               string line = reader.ReadLine();
               string[] lineData = line.Split(';');

               int id = int.Parse(lineData[0]);

               return new Issue(id, lineData[5]);
            }
         }
         return null;
      }

      #endregion
   }
}
