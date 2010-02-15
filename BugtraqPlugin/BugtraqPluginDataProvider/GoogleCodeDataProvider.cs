//////////////////////////////////////////////////////////////////////////////////
//
// Project            : BugtraqPlugin
// Module:            : BugtraqPluginDataProvider
// Description        : DataProvider for Google Code Bugtracking.
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
using System.Text.RegularExpressions;
using BugtraqPlugin.Contracts.DomainModel;
using BugtraqPlugin.Contracts.DomainModel.Parameter;
using Microsoft.Practices.Unity;

namespace BugtraqPlugin.DataProvider
{
   /// <summary>
   /// DataProvider for Google Code Bugtracking.
   /// </summary>
   public class GoogleCodeDataProvider : WebDataProvider
   {
      #region Fields

      private const string ISSUE_DATAPATH = "issues/csv";
      private Uri dataRequestUri = null;
      private Regex quotations = new Regex("^(\")?(?<value>.*?)(\")?$", RegexOptions.Singleline | RegexOptions.IgnoreCase);
      
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
               UriBuilder uriBuilder = new UriBuilder(Parameter.BugtrackUri);
               uriBuilder.Path += uriBuilder.Path.EndsWith("/") ? ISSUE_DATAPATH : "/" + ISSUE_DATAPATH;
               dataRequestUri = uriBuilder.Uri;
            }
            return dataRequestUri;
         }
      }

      #endregion

      /// <summary>
      /// Initializes a new instance of the <see cref="GoogleCodeDataProvider"/> class.
      /// </summary>
      /// <param name="parameter">The parameter.</param>
      [InjectionConstructor]
      public GoogleCodeDataProvider([Dependency]PluginParameter parameter)
         : base(parameter)
      {
         //
         // TODO: Add constructor logic here
         //
      }

      #region Methods

      /// <summary>
      /// Handles loaded the data.
      /// </summary>
      /// <param name="data">The data.</param>
      protected override void HandleData(string data)
      {
         using (StringReader reader = new StringReader(data))
         {
            // skip header
            string line = reader.ReadLine();
            //List<string> columnValues = new List<string>();
            string[] columnValues = null;

            // HACK: Fehler bei der Berechnung der Substringlänge bei to
            // TODO: Splitter entfernen
            while (!String.IsNullOrEmpty((line = reader.ReadLine())))
            {
               columnValues = line.Split(new string[] { "\",\"" }, StringSplitOptions.None);
               columnValues[0] = quotations.Replace(columnValues[0], "${value}");
               columnValues[6] = quotations.Replace(columnValues[6], "${value}");

               Issues.Add(new Issue(int.Parse(columnValues[0]), columnValues[6]));
            }
         }
      }

      #endregion
   }
}
