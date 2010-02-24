//////////////////////////////////////////////////////////////////////////////////
//
// Project            : BugtraqPlugin
// Module:            : BugtraqPluginTest
// Description        : Test for Dataproviders.
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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BugtraqPlugin.Contracts;
using BugtraqPlugin.Contracts.DomainModel;
using BugtraqPlugin.Contracts.DomainModel.Parameter;
using BugtraqPlugin.DataProvider;
using NUnit.Framework;

namespace BugtraqPluginTest
{
   /// <summary>
   /// Test for DataProviders.
   /// </summary>
   [TestFixture]
   public class ProviderTestCase : NUnitTestCore
   {
      #region Methods - Testcasedata

      /// <summary>
      /// Gets the data provider test data.
      /// </summary>
      public IEnumerable DataProviderTestData
      {
         get
         {
            #region Google Code

            PluginParameter parameter = new PluginParameter();
            parameter.DataProvider = "Google Code";
            Uri uri = new Uri(Path.Combine(Directory.GetCurrentDirectory(), @"TestData\GoogleDataAPIIssues.xml"));
            parameter.BugtrackUri = uri;

            yield return new TestCaseData(
               new GoogleCodeDataProvider(parameter, uri),
               new Issue[] 
               { 
                  new Issue(1, "Usage of Microkernel/DI-Container"), 
                  new Issue(2, "Support for Google Code"), 
                  new Issue(3, "Language Support") 
               })
               .SetName("GoogleDataProviderv2Test")
               .SetCategory("DataProviderTest")
               .SetDescription("Test data for Google Code Data Provider");

            #endregion

            #region Redmine

            parameter = new PluginParameter();
            parameter.DataProvider = "Redmine";
            uri = new Uri(Path.Combine(Directory.GetCurrentDirectory(), @"TestData\RedmineTestData.csv"));
            parameter.BugtrackUri = uri;

            yield return new TestCaseData(
               new RedmineDataProvider(parameter, uri),
               new Issue[]
               {
                  new Issue(4919,"Changelog parses brackets wrong"),
                  new Issue(4918,"Revisions r3453 and r3454 broke On-the-fly user creation with LDAP"),
                  new Issue(4913,"Projects list expanding and contracting"),
               }
               )
            .SetName("RedmineDataProviderTest")
            .SetCategory("DataProviderTest")
            .SetDescription("Test data for Redmine data provider");

            #endregion
         }
      }

      #endregion

      /// <summary>
      /// Tests the specified data provider.
      /// </summary>
      /// <param name="dataProvider">The data provider.</param>
      /// <param name="excpectedIssues">The excpected issues.</param>
      [TestCaseSource("DataProviderTestData")]
      public void Test(IDataProvider dataProvider, IEnumerable<Issue> excpectedIssues)
      {
         dataProvider.Load();

         CollectionAssert.IsNotEmpty(dataProvider.Issues, "Data not loaded");
         CollectionAssert.AllItemsAreUnique(dataProvider.Issues, "Issues contains some doubled data");
         Assert.AreEqual(excpectedIssues.Count(), dataProvider.Issues.Count, "Issuecount differs");

         CollectionAssert.AreEqual(excpectedIssues.OrderBy(issue => issue.Id), dataProvider.Issues.OrderBy(issue => issue.Id), new IssueByIdComparer(), "Issues are not equal");
      }

      /// <summary>
      /// Compares Issues by Id.
      /// </summary>
      private class IssueByIdComparer : IComparer<Issue>, IComparer
      {
         #region IComparer<Issue> Member

         /// <summary>
         /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
         /// </summary>
         /// <param name="x">The first object to compare.</param>
         /// <param name="y">The second object to compare.</param>
         /// <returns>
         /// Value
         /// Condition
         /// Less than zero
         /// <paramref name="x"/> is less than <paramref name="y"/>.
         /// Zero
         /// <paramref name="x"/> equals <paramref name="y"/>.
         /// Greater than zero
         /// <paramref name="x"/> is greater than <paramref name="y"/>.
         /// </returns>
         public int Compare(Issue x, Issue y)
         {
            if (x == null)
               return -1;
            if (y == null)
               return 1;

            return x.Id - y.Id;
         }

         #endregion

         #region IComparer Member

         /// <summary>
         /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
         /// </summary>
         /// <param name="x">The first object to compare.</param>
         /// <param name="y">The second object to compare.</param>
         /// <returns>
         /// Value
         /// Condition
         /// Less than zero
         /// <paramref name="x"/> is less than <paramref name="y"/>.
         /// Zero
         /// <paramref name="x"/> equals <paramref name="y"/>.
         /// Greater than zero
         /// <paramref name="x"/> is greater than <paramref name="y"/>.
         /// </returns>
         /// <exception cref="T:System.ArgumentException">
         /// Neither <paramref name="x"/> nor <paramref name="y"/> implements the <see cref="T:System.IComparable"/> interface.
         /// -or-
         /// <paramref name="x"/> and <paramref name="y"/> are of different types and neither one can handle comparisons with the other.
         /// </exception>
         public int Compare(object x, object y)
         {
            return this.Compare((Issue)x, (Issue)y);
         }

         #endregion
      }
   }
}
