#region File Header
// ***********************************************************************
// Assembly         : ApiWrapper.Test
// Author           : Eduardo Queiroz
// Created          : 13/02/2020
//
// ***********************************************************************
// <copyright file="FakeWebRequest.cs" company="EQueiroz">
//     Copyright ©  2020
// </copyright>
// <summary>Fake webRequest for unit Testing</summary>
// ***********************************************************************
#endregion

using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;

namespace ApiWrapper.Test.Factory
{
    [ExcludeFromCodeCoverage]
    public class FakeWebRequest : WebRequest
    {
        #region Attributes
        MemoryStream requestStream = new MemoryStream();
        MemoryStream responseStream;
        #endregion

        #region Properties
        public override string Method { get; set; }
        public override string ContentType { get; set; }
        public override long ContentLength { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Initializes a new instance of <see cref="FakeWebRequest"/>
        /// with the response to return.
        /// </summary>
        public FakeWebRequest(string response)
        {
            responseStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(response));
        }

        /// <summary>
        /// Returns the request contents as a string.
        /// </summary>
        public string ContentAsString()
        {
            return System.Text.Encoding.UTF8.GetString(requestStream.ToArray());
        }

        /// <summary>
        /// See <see cref="WebRequest.GetRequestStream"/>.
        /// </summary>
        public override Stream GetRequestStream()
        {
            return requestStream;
        }

        /// <summary>
        /// See <see cref="WebRequest.GetResponse"/>.
        /// </summary>
        public override WebResponse GetResponse()
        {
            return new FakeWebResponse(responseStream);
        }
        #endregion
    }
}
