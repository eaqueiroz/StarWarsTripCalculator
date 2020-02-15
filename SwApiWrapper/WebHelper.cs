#region File Header
// ***********************************************************************
// Assembly         : ApiWrapper
// Author           : Eduardo Queiroz
// Created          : 13/02/2020
//
// ***********************************************************************
// <copyright file="WebHelper.cs" company="EQueiroz">
//     Copyright ©  2020
// </copyright>
// <summary>Wrapper for the Star Wars web API</summary>
// ***********************************************************************
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Common.Model;
using Flurl;
using Microsoft.Extensions.Logging;

namespace SwApiWrapper
{
    public class WebHelper<T> : IWebHelper<T> where T : ISwEntity
    {
        #region Attributes
        private readonly ILogger _logger;
        #endregion

        #region Ctr
        public WebHelper(ILogger logger)
        {
            this._logger = logger;
        }
        #endregion

        #region Constants
        const string BASE_API_URL = "http://swapi.co/api/";
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the SerializerOptions.
        /// </summary>
        /// <value>Json Serializer Options</value>
        public JsonSerializerOptions SerializerOptions
        {
            get
            {
                return new JsonSerializerOptions
                {
                    AllowTrailingCommas = true,
                    IgnoreNullValues = true,
                    PropertyNameCaseInsensitive = true
                };
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Make a request to a specific URL
        /// </summary>
        /// <param name="uri">Url Address</param>
        /// <returns>Response in Json format</returns>
        public async Task<string> Request(string uri)
        {
            try
            {
                var webRequest = WebRequest.Create(uri);
                var response = webRequest.GetResponse();
                string json = string.Empty;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    json = reader.ReadToEnd();
                }

                return json;
            }
            catch (WebException ex)
            {
                _logger.LogError($"Error Making a Request. ", DateTime.UtcNow);
                return null;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Return all the Starships in the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAll()
        {
            var list = new List<T>();
            var queryResult = new QueryResult<T>()
            {
                Next = GetEntityPath()
            };

            while (!string.IsNullOrWhiteSpace(queryResult?.Next))
            {
                string json = await Request(queryResult.Next);
                queryResult = JsonSerializer.Deserialize<QueryResult<T>>(json, SerializerOptions);

                if (queryResult == null)
                {
                    _logger.LogError($"Error Requesting Starships Database", DateTime.UtcNow);
                }

                list.AddRange(queryResult.Results);
            }

            return list;
        }

        /// <summary>
        /// Get a specific starship by Id
        /// </summary>
        /// <param name="starshipId">Id of Starship</param>
        /// <returns>Starship Data</returns>
        public async Task<T> GetbyId(int starshipId)
        {
            string url = Url.Combine(GetEntityPath(), starshipId.ToString());
            string json = await Request(url);
            var result = JsonSerializer.Deserialize<T>(json, SerializerOptions);

            if (result == null)
            {
                _logger.LogError($"Error Getting Information for Starship: {starshipId}", DateTime.UtcNow);
            }

            return result;
        }

        /// <summary>
        /// Returns the full path of the current Entity
        /// </summary>
        /// <returns></returns>
        public string GetEntityPath()
        {
            var instance = (T)Activator.CreateInstance(typeof(T), new object[] { });
            return Url.Combine(BASE_API_URL, instance.GetEntityPath());
        }
        #endregion
    }
}
