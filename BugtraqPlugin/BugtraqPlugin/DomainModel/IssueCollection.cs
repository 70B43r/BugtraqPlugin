//////////////////////////////////////////////////////////////////////////////////
//
// Project            : Tortoise Bugtraq Plugin
// Module:            : BugtraqPlugin
// Description        : Collection of issues.
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

using System.Collections.Generic;

namespace BugtraqPlugin.DomainModel
{
   /// <summary>
   /// Issue collection.
   /// </summary>
   public class IssueCollection : List<Issue>
   {
      #region Constructors

      /// <summary>
      /// Initializes a new instance of the <see cref="IssueCollection"/> class.
      /// </summary>
      public IssueCollection()
         : base()
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="IssueCollection"/> class.
      /// </summary>
      /// <param name="issues">The issues.</param>
      public IssueCollection(IEnumerable<Issue> issues)
         : base(issues)
      { }

      #endregion
   }
}
