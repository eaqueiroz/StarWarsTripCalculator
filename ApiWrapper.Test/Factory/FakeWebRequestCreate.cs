#region File Header
// ***********************************************************************
// Assembly         : ApiWrapper.Test
// Author           : Eduardo Queiroz
// Created          : 13/02/2020
//
// ***********************************************************************
// <copyright file="FakeWebRequestCreate.cs" company="EQueiroz">
//     Copyright ©  2020
// </copyright>
// <summary>Fixed Request Creation for fake webRequest </summary>
// ***********************************************************************
#endregion

using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace ApiWrapper.Test.Factory
{
    /// <summary>
    /// A web request creator for unit testing
    /// </summary>
    [ExcludeFromCodeCoverage]
    
    class FakeWebRequestCreate : IWebRequestCreate
    {
        #region Attributes
        static WebRequest nextRequest;
        static object lockObject = new object();
        #endregion

        #region Public Methods
        static public WebRequest NextRequest
        {
            get { return nextRequest; }
            set { lock (lockObject) { nextRequest = value; } }
        }

        /// <summary>
        /// See <see cref="IWebRequestCreate.Create"/>
        /// </summary>
        public WebRequest Create(Uri uri)
        {
            return nextRequest;
        }

        /// <summary>
        /// Utility method for creating a TestWebRequest and setting
        /// it to be the next WebRequest to use.
        /// </summary>
        /// <param name="response">The response the TestWebRequest will return.</param>
        public static FakeWebRequest CreateTestRequest(string response)
        {
            var request = new FakeWebRequest(response);
            NextRequest = request;
            return request;
        }
        #endregion
    }
}
