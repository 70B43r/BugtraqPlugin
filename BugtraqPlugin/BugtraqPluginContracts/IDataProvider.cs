//////////////////////////////////////////////////////////////////////////////////
//
// Project            : BugtraqPlugin
// Module:            : BugtraqPluginContracts
// Description        : Interface for DataProvider.
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
using BugtraqPlugin.Contracts.DomainModel;

namespace BugtraqPlugin.Contracts
{
   /// <summary>
   /// Interface for DataProvider.
   /// </summary>
   public interface IDataProvider : IDisposable
   {
      /// <summary>
      /// Gets the issues.
      /// </summary>
      ReadOnlyIssueCollection Issues { get; }

      /// <summary>
      /// Loads the data.
      /// </summary>
      void Load();
   }
}
