//////////////////////////////////////////////////////////////////////////////////
//
// Project            : BugtraqPlugin
// Module:            : BugtraqPluginContracts
// Description        : Readonly Issue Collection.
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

using System.Collections.ObjectModel;

namespace BugtraqPlugin.Contracts.DomainModel
{
   /// <summary>
   /// Readonly Issue Collection.
   /// </summary>
   public class ReadOnlyIssueCollection : ReadOnlyCollection<Issue>
   {
      #region Constructors

      /// <summary>
      /// Initializes a new instance of the <see cref="ReadOnlyIssueCollection"/> class.
      /// </summary>
      /// <param name="issues">The issues.</param>
      public ReadOnlyIssueCollection(IssueCollection issues)
         : base(issues)
      { }

      #endregion
   }
}
