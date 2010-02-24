//////////////////////////////////////////////////////////////////////////////////
//
// Project            : BugtraqPlugin
// Module:            : BugtraqPluginTest
// Description        : NUnit test base class.
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

using NUnit.Framework;

namespace BugtraqPluginTest
{
   /// <summary>
   /// Base class for NUnit tests.
   /// </summary>
   public abstract class NUnitTestCore
   {
      #region Properties

      #endregion

      #region Methods

      /// <summary>
      /// Called before any test.
      /// </summary>
      [TestFixtureSetUp]
      public virtual void TestFixtureSetUp() { }

      /// <summary>
      /// Called after all tests excecuted.
      /// </summary>
      [TestFixtureTearDown]
      public virtual void TestFixtureTearDown() { }

      /// <summary>
      /// Called before each test.
      /// </summary>
      [SetUp]
      public virtual void SetUp() { }

      /// <summary>
      /// Called after each test.
      /// </summary>
      [TearDown]
      public virtual void TearDown() { }

      #endregion
   }
}