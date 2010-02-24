//////////////////////////////////////////////////////////////////////////////////
//
// Project            : BugtraqPlugin
// Module:            : BugtraqPluginDataProvider
// Description        : Provider for Google Code Data.
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
using System.IO;
using System.Xml;
using BugtraqPlugin.Contracts.DomainModel;
using BugtraqPlugin.Contracts.DomainModel.Parameter;
using Microsoft.Practices.Unity;

namespace BugtraqPlugin.DataProvider
{
   /// <summary>
   /// Data provider for Google Code.
   /// </summary>
   public class GoogleCodeDataProvider : WebDataProvider
   {
      #region Fields

      /// <summary>
      /// base uri pattern
      /// </summary>
      private const string BASEURI = "http://code.google.com/feeds/issues/p/%PROJECT_NAME%/issues/full";
      private const string DEFAULTQUERY = "can=open";

      private const string DEFAULT_PREFIX_ATOM = "atom";
      private const string NAMESPACEURI_ATOM = "http://www.w3.org/2005/Atom";

      private const string DEFAULT_PREFIX_ISSUES = "issues";
      private const string NAMESPACEURI_ISSUES = "http://schemas.google.com/projecthosting/issues/2009";

      private const string DEFAULT_PREFIX_OPENSEARCH = "openSearch";
      private const string NAMESPACEURI_OPENSEARCH = "http://a9.com/-/spec/opensearch/1.1/";
      
      private const string DEFAULT_PREFIX_GOOGLEDATA = "gd";
      private const string NAMESPACEURI_GOOGLEDATA = "http://schemas.google.com/g/2005";

      private Uri dataRequestUri;

      #endregion

      #region Properties

      /// <summary>
      /// Gets the data request URI.
      /// </summary>
      /// <value></value>
      public override Uri DataRequestUri
      {
         get
         {
            if (dataRequestUri == null)
            {
               Uri projectUri = Parameter.BugtrackUri;
               string projectName = projectUri.Segments[projectUri.Segments.Length - 1];
               projectName = projectName.Replace("/", String.Empty);

               UriBuilder uriBuilder = new UriBuilder(BASEURI.Replace("%PROJECT_NAME%", projectName));
               uriBuilder.Query = DEFAULTQUERY;

               dataRequestUri = uriBuilder.Uri;
            }
            return dataRequestUri;
         }
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Initializes a new instance of the <see cref="GoogleCodeDataProvider"/> class.
      /// </summary>
      /// <param name="parameter">The parameter.</param>
      [InjectionConstructor]
      public GoogleCodeDataProvider([Dependency]PluginParameter parameter)
         : base(parameter)
      {
      }

#if DEBUG

      /// <summary>
      /// Initializes a new instance of the <see cref="GoogleCodeDataProvider"/> class.
      /// Constructor for Test.
      /// </summary>
      /// <param name="parameter">The parameter.</param>
      /// <param name="dataRequestUri">The data request URI.</param>
      internal GoogleCodeDataProvider(PluginParameter parameter, Uri dataRequestUri)
         : this(parameter)
      {
         this.dataRequestUri = dataRequestUri;
      }

#endif

      #endregion

      #region Methods

      /// <summary>
      /// Handles loaded the data.
      /// </summary>
      /// <param name="data">The data.</param>
      protected override IEnumerable<Issue> HandleData(string data)
      {
         return ParseEntriesXmlDoc(data);
      }

      /// <summary>
      /// Parses the entries from XML doc.
      /// </summary>
      /// <param name="data">The data.</param>
      /// <returns>The parsed issues.</returns>
      private static IEnumerable<Issue> ParseEntriesXmlDoc(string data)
      {
         XmlDocument doc = new XmlDocument();
         doc.LoadXml(data);

         XmlNamespaceManager namespaceManager = new XmlNamespaceManager(doc.NameTable);

         string atom = GetPrefix(namespaceManager, NAMESPACEURI_ATOM, DEFAULT_PREFIX_ATOM);
         //string openSearch = GetPrefix(namespaceManager, NAMESPACEURI_OPENSEARCH, DEFAULT_PREFIX_OPENSEARCH);
         //string gd = GetPrefix(namespaceManager, NAMESPACEURI_GOOGLEDATA, DEFAULT_PREFIX_GOOGLEDATA);
         string issues = GetPrefix(namespaceManager, NAMESPACEURI_ISSUES, DEFAULT_PREFIX_ISSUES);

         foreach (XmlNode entry in doc.SelectNodes(String.Format("/{0}:feed/{0}:entry", atom), namespaceManager))
         {
            XmlNode title = entry.SelectSingleNode(String.Format("{0}:title", atom), namespaceManager);
            XmlNode id = entry.SelectSingleNode(String.Format("{0}:id", issues), namespaceManager);

            yield return new Issue(int.Parse(id.FirstChild.Value), title.FirstChild.Value);
         }
      }

      /// <summary>
      /// Gets the prefix.
      /// </summary>
      /// <param name="namespaceManager">The namespace manager.</param>
      /// <param name="uri">The URI.</param>
      /// <param name="default">The @default prefix.</param>
      /// <returns>The prefix to use for namespace uri.</returns>
      private static string GetPrefix(XmlNamespaceManager namespaceManager, string uri, string @default)
      {
         string prefix = namespaceManager.LookupPrefix(uri);
         if (String.IsNullOrEmpty(prefix))
            namespaceManager.AddNamespace(prefix = @default, uri);

         return prefix;
      }

      #endregion
   }
}
