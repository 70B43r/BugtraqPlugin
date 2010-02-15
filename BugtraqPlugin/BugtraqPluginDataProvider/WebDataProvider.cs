//////////////////////////////////////////////////////////////////////////////////
//
// Project            : Tortoise Bugtraq Plugin
// Module:            : BugtraqPluginDataProvider
// Description        : Data providerfor web based access.
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
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using BugtraqPlugin.Contracts;
using BugtraqPlugin.Contracts.DomainModel;
using BugtraqPlugin.Contracts.DomainModel.Parameter;
using Microsoft.Practices.Unity;

namespace BugtraqPlugin.DataProvider
{
   /// <summary>
   /// Base class for web bases DataProviders.
   /// </summary>
   public abstract class WebDataProvider : IDataProvider, IDisposable
   {
      #region Fields

      private IssueCollection issues = null;

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the parameter.
      /// </summary>
      /// <value>The parameter.</value>
      public PluginParameter Parameter { get; private set; }

      /// <summary>
      /// Gets or sets the issues.
      /// </summary>
      public IssueCollection Issues
      {
         get
         {
            if (issues == null)
            {
               issues = new IssueCollection();
               Load();
            }

            return issues;
         }
      }

      /// <summary>
      /// Gets the data request URI.
      /// </summary>
      protected abstract Uri DataRequestUri { get; }

      #endregion

      #region Constructors

      /// <summary>
      /// Initializes a new instance of the <see cref="DataProvider"/> class.
      /// </summary>
      private WebDataProvider()
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="DataProvider"/> class.
      /// </summary>
      /// <param name="parameter">The parameter.</param>
      [InjectionConstructor]
      protected WebDataProvider([Dependency]PluginParameter parameter)
         : this()
      {
         this.Parameter = parameter;
      }

      #endregion

      #region Methods

      /// <summary>
      /// Handles loaded the data.
      /// </summary>
      /// <param name="data">The data.</param>
      protected abstract void HandleData(string data);

      /// <summary>
      /// Loads the data.
      /// </summary>
      public void Load()
      {
         bool isSecureConnection = DataRequestUri.Scheme == Uri.UriSchemeHttps;

         using (WebClient webClient = new WebClient())
         {
            webClient.Credentials = GetCredentials();

            if (isSecureConnection)
               ServicePointManager.ServerCertificateValidationCallback += CertificateValidationCallback;

            try
            {
               HandleData(webClient.DownloadString(DataRequestUri));
            }
            finally
            {
               ServicePointManager.ServerCertificateValidationCallback -= CertificateValidationCallback;
            }
         }
      }

      /// <summary>
      /// Validation callback for server certificates.
      /// </summary>
      /// <param name="sender">The sender.</param>
      /// <param name="certificate">The certificate.</param>
      /// <param name="chain">The chain.</param>
      /// <param name="sslPolicyErrors">The SSL policy errors.</param>
      /// <returns></returns>
      protected virtual bool CertificateValidationCallback(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
      {
         X509Certificate2 certificate2 = certificate as X509Certificate2;

         if (certificate2 == null)
            certificate2 = new X509Certificate2(certificate);

         return certificate2.Verify();
      }

      /// <summary>
      /// Gets the use credentials.
      /// </summary>
      /// <returns>The user credentials based on parameters.</returns>
      private ICredentials GetCredentials()
      {
         if (Parameter.UseCurrentUser.HasValue)
         {
            if (Parameter.UseCurrentUser.Value)
            {
               return CredentialCache.DefaultCredentials;
            }
            else
            {
               // HACK: Fehler bei der trennung von Domain und Namen - ZU viele ) in der Regex?
               // search for domain user signs
               Regex domainUser = new Regex(@"^((?<domain>.+)\(?<user>.+))|((?<user>.+)@(?<domain>.+))$", 
                  RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);
               Match match = domainUser.Match(Parameter.UserName);
               if (match.Success)
               {
                  return new NetworkCredential(match.Groups["user"].Value, Parameter.Password, match.Groups["domain"].Value);
               }
               else
               {
                  return new NetworkCredential(Parameter.UserName, Parameter.Password);
               }
            }
         }

         return null;
      }

      #endregion

      #region IDisposable Member

      /// <summary>
      /// Releases unmanaged resources and performs other cleanup operations before the
      /// <see cref="DataProvider"/> is reclaimed by garbage collection.
      /// </summary>
      ~WebDataProvider()
      {
         Dispose(false);
      }

      /// <summary>
      /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
      /// </summary>
      public void Dispose()
      {
         Dispose(true);
      }

      /// <summary>
      /// Releases unmanaged and - optionally - managed resources
      /// </summary>
      /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
      protected virtual void Dispose(bool disposing)
      {
         if (disposing)
         { 
            // release managed
         }

         // release unmanaged
      }

      #endregion
   }
}
