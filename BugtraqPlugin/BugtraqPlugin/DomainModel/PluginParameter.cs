//////////////////////////////////////////////////////////////////////////////////
//
// Project            : Tortoise Bugtraq Plugin
// Module:            : BugtraqPlugin
// Description        : Helper for parameter handling.
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

namespace BugtraqPlugin.DomainModel.Parameter
{
   /// <summary>
   /// Class for parameter handling.
   /// </summary>
   public class PluginParameter
   {
      #region const fields

      private const string PARAMETER_URI = "URI";
      private const string PARAMETER_USECURRENTUSER = "USECURRENTUSER";
      private const string PARAMETER_USERNAME = "USER";
      private const string PARAMETER_PASSWORD = "PASS";

      #endregion

      #region static fields

      private static string[] requiredParameter = new string[] { PARAMETER_URI };

      #endregion

      #region Fields

      private bool? parametersValid;

      private ParameterBuilder parameterBuilder;

      #endregion

      #region Properties

      /// <summary>
      /// Gets a value indicating whether this <see cref="PluginParameter"/> is valid.
      /// </summary>
      /// <value><c>true</c> if valid; otherwise, <c>false</c>.</value>
      private bool Valid
      {
         get
         {
            if (!parametersValid.HasValue)
               parametersValid = Validate();

            return parametersValid.Value;
         }
      }

      /// <summary>
      /// Gets or sets the bugtrack URI.
      /// </summary>
      public Uri BugtrackUri
      {
         get
         {
            Uri uri = null;
            if (parameterBuilder.HasParameter(PARAMETER_URI))
               uri = new Uri(parameterBuilder.GetParameter(PARAMETER_URI));
            return uri;
         }
         set
         {
            if (value == null)
            {
               this.parameterBuilder.RemoveParameter(PARAMETER_URI);
            }
            else
            {
               if (!value.IsWellFormedOriginalString())
                  value = new Uri(Uri.EscapeUriString(value.OriginalString));
               parameterBuilder.SetParameter(PARAMETER_URI, value.ToString());
            }
         }
      }

      /// <summary>
      /// Gets or sets a value indicating to use the use current user.
      /// </summary>
      public bool? UseCurrentUser
      {
         get
         {
            if (parameterBuilder.HasParameter(PARAMETER_USECURRENTUSER))
               return Boolean.Parse(parameterBuilder.GetParameter(PARAMETER_USECURRENTUSER));
            return null;
         }
         set
         {
            if (value.HasValue)
               parameterBuilder.SetParameter(PARAMETER_USECURRENTUSER, value.Value.ToString());
            else
               parameterBuilder.RemoveParameter(PARAMETER_USECURRENTUSER);
         }
      }

      /// <summary>
      /// Gets or sets the name of the user.
      /// </summary>
      public string UserName
      {
         get
         {
            if (parameterBuilder.HasParameter(PARAMETER_USERNAME))
               return parameterBuilder.GetParameter(PARAMETER_USERNAME);
            return null;
         }
         set
         {
            if (String.IsNullOrEmpty(value))
               parameterBuilder.RemoveParameter(PARAMETER_USERNAME);
            else
               parameterBuilder.SetParameter(PARAMETER_USERNAME, value);
         }
      }

      /// <summary>
      /// Gets or sets the password.
      /// </summary>
      public string Password
      {
         get
         {
            if (parameterBuilder.HasParameter(PARAMETER_PASSWORD))
               return parameterBuilder.GetParameter(PARAMETER_PASSWORD);
            return null;
         }
         set
         {
            if (String.IsNullOrEmpty(value))
               parameterBuilder.RemoveParameter(PARAMETER_PASSWORD);
            else
               parameterBuilder.SetParameter(PARAMETER_PASSWORD, value);
         }
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Initializes a new instance of the <see cref="PluginParameter"/> class.
      /// </summary>
      /// <param name="parameterString">The parameter string.</param>
      public PluginParameter(string parameterString)
      {
         parameterBuilder = new ParameterBuilder();
         parameterBuilder.Parse(parameterString);
      }

      #endregion

      #region static Methods

      /// <summary>
      /// Validates the specified parameters.
      /// </summary>
      /// <param name="parameters">The parameter string.</param>
      /// <returns><code>true</code> if parameters are valid, otherwise <code>false</code>.</returns>
      internal static bool Validate(string parameters)
      {
         return new PluginParameter(parameters).Validate();
      }

      #endregion

      #region Methods

      /// <summary>
      /// Validates the current parameters.
      /// </summary>
      /// <returns>
      /// 	<code>true</code> if parameters are valid, otherwise <code>false</code>.
      /// </returns>
      private bool Validate()
      {
         foreach (string parameterName in requiredParameter)
         {
            if (!parameterBuilder.HasParameter(parameterName))
               return false;
         }

         return true;
      }

      /// <summary>
      /// Gets the Parameterstring.
      /// </summary>
      /// <returns>The parameterstring.</returns>
      public string ParameterString()
      {
         return parameterBuilder.ToString();
      }

      #endregion
   }
}