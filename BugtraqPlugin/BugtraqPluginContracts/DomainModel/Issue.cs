//////////////////////////////////////////////////////////////////////////////////
//
// Project            : Tortoise Bugtraq Plugin
// Module:            : BugtraqPluginContracts
// Description        : Data container for issue data.
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
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BugtraqPlugin.Contracts.DomainModel
{
   /// <summary>
   /// Issue data container.
   /// </summary>
   public class Issue
   {
      /// <summary>
      /// Gets the issue id.
      /// </summary>
      public int Id { get; private set; }

      /// <summary>
      /// Gets the summary of the issue.
      /// </summary>
      public string Summary { get; private set; }

      /// <summary>
      /// Initializes a new instance of the <see cref="Issue"/> class.
      /// </summary>
      /// <param name="id">The id.</param>
      /// <param name="summary">The summary.</param>
      public Issue(int id, string summary)
      {
         this.Id = id;
         this.Summary = summary;
      }
   }
}
