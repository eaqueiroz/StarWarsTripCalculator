#region File Header
// ***********************************************************************
// Assembly         : ApiWrapper.Test
// Author           : Eduardo Queiroz
// Created          : 13/02/2020
//
// ***********************************************************************
// <copyright file="FakeWebResponse.cs" company="EQueiroz">
//     Copyright ©  2020
// </copyright>
// <summary>Fixed response for fake webRequest </summary>
// ***********************************************************************
#endregion

using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;

namespace ApiWrapper.Test.Factory
{
    [ExcludeFromCodeCoverage]
    class FakeWebResponse : WebResponse
    {
        Stream responseStream;

        #region Public Methods
        /// <summary>
        /// Initializes a new instance of <see cref="FakeWebResponse"/>
        /// with the response stream to return.
        /// </summary>
        public FakeWebResponse(Stream responseStream)
        {
            this.responseStream = responseStream;
        }

        /// <summary>See
        /// <see cref="WebResponse.GetResponseStream"/>.
        /// </summary>
        public override Stream GetResponseStream()
        {
            return responseStream;
        }
        #endregion
    }
}
