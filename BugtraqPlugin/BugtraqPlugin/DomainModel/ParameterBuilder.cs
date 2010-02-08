//////////////////////////////////////////////////////////////////////////////////
//
// Project            : Tortoise Bugtraq Plugin
// Module:            : BugtraqPlugin
// Description        : Helper for building parameter string.
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

namespace BugtraqPlugin.DomainModel.Parameter
{
   /// <summary>
   /// Helper class to build parameter string.
   /// </summary>
   internal class ParameterBuilder : IEnumerable<KeyValuePair<string, string>>
   {
      #region constant fields

      private const char PARAMETERSPLITCHAR = ';';
      private const char PARAMETERVALUESPLITCHAR = '=';

      #endregion

      #region Fields

      private char[] parameterSplitter = new char[] { PARAMETERSPLITCHAR };

      private Dictionary<string, string> parameters;

      #endregion

      #region Constructors

      /// <summary>
      /// Initializes a new instance of the <see cref="ParameterBuilder"/> class.
      /// </summary>
      public ParameterBuilder()
      {
         this.parameters = new Dictionary<string, string>();
      }

      #endregion

      #region Methods

      /// <summary>
      /// Determines whether the specified parameter is present.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <returns>
      /// 	<c>true</c> if the specified parameter is present; otherwise, <c>false</c>.
      /// </returns>
      public bool HasParameter(string parameterName)
      {
         return this.parameters.ContainsKey(parameterName);
      }

      /// <summary>
      /// Sets the parameter.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <param name="parameterValue">The parameter value.</param>
      public void SetParameter(string parameterName, string parameterValue)
      {
         this.parameters[parameterName] = parameterValue;
      }

      /// <summary>
      /// Gets the parameter value.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      /// <returns>The value of the parameter.</returns>
      public string GetParameter(string parameterName)
      {
         string parameterValue = null;
         parameters.TryGetValue(parameterName, out parameterValue);

         return parameterValue;
      }

      /// <summary>
      /// Removes the parameter.
      /// </summary>
      /// <param name="parameterName">Name of the parameter.</param>
      public void RemoveParameter(string parameterName)
      {
         if (this.parameters.ContainsKey(parameterName))
            this.parameters.Remove(parameterName);
      }

      #endregion

      #region IEnumerable<KeyValuePair<string,string>> Member

      /// <summary>
      /// Returns an enumerator that iterates through the collection.
      /// </summary>
      /// <returns>
      /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
      /// </returns>
      public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
      {
         return parameters.GetEnumerator();
      }

      /// <summary>
      /// Returns an enumerator that iterates through a collection.
      /// </summary>
      /// <returns>
      /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
      /// </returns>
      System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
      {
         return parameters.GetEnumerator();
      }

      #endregion

      #region Methods

      /// <summary>
      /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
      /// </summary>
      /// <returns>
      /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
      /// </returns>
      public override string ToString()
      {
         return String.Join(
            Char.ToString(PARAMETERSPLITCHAR),
            parameters
               .Where(parameter => !String.IsNullOrEmpty(parameter.Value))
               .Select(parameter => String.Format("{0}{2}{1}", parameter.Key, parameter.Value, PARAMETERVALUESPLITCHAR))
               .ToArray());
      }

      /// <summary>
      /// Parses the specified parameter string.
      /// </summary>
      /// <param name="parameterString">The parameter string.</param>
      public void Parse(string parameterString)
      {
         string[] parameterArray = parameterString.Split(parameterSplitter, StringSplitOptions.RemoveEmptyEntries);

         foreach (string paramValue in parameterArray)
         {
            int equalOpIdx = paramValue.IndexOf('=');
            if (equalOpIdx != -1)
            {
               if (equalOpIdx != paramValue.Length)
                  this.SetParameter(paramValue.Substring(0, equalOpIdx), paramValue.Substring(equalOpIdx + 1));
               else
                  this.SetParameter(paramValue.Substring(0, equalOpIdx), null);
            }
         }
      }

      #endregion
   }
}
