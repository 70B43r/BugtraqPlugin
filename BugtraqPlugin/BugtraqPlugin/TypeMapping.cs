//////////////////////////////////////////////////////////////////////////////////
//
// Project            : BugtraqPlugin
// Module:            : Main Module
// Description        : Description of mapped type
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

namespace BugtraqPlugin
{
   /// <summary>
   /// Description of mapped types.
   /// </summary>
   internal struct TypeMapping
   {
      /// <summary>
      /// The registration name.
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// Type mapped from.
      /// </summary>
      public Type From { get; set; }

      /// <summary>
      /// Type mapped to.
      /// </summary>
      public Type To { get; set; }
   }
}
