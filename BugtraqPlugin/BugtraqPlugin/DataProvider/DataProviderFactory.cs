//////////////////////////////////////////////////////////////////////////////////
//
// Project            : Tortoise Bugtraq Plugin
// Module:            : BugtraqPlugin
// Description        : Data provider factory class.
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


using BugtraqPlugin.DomainModel.Parameter;

namespace BugtraqPlugin.DataProvider
{
   /// <summary>
   /// Data provider factory class.
   /// </summary>
   public abstract class DataProviderFactory
   {
      #region Constructors

      /// <summary>
      /// Initializes a new instance of the <see cref="DataProviderFactory"/> class.
      /// </summary>
      protected DataProviderFactory()
      { }

      #endregion

      #region Methods

      /// <summary>
      /// Gets a data provider.
      /// </summary>
      /// <param name="parameter">The parameter.</param>
      /// <returns></returns>
      public static DataProvider GetProvider(PluginParameter parameter)
      {
         return new RedmineDataProvider(parameter);
      }

      #endregion
   }
}
