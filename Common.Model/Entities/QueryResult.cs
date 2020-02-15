#region File Header
// ***********************************************************************
// Assembly         : ApiWrapper
// Author           : Eduardo Queiroz
// Created          : 13/02/2020
//
// ***********************************************************************
// <copyright file="QueryResult.cs" company="EQueiroz">
//     Copyright ©  2020
// </copyright>
// <summary>Entity that receives the list of starships</summary>
// ***********************************************************************
#endregion
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Common.Model
{
    [ExcludeFromCodeCoverage]
    public class QueryResult<T>
    {
        /// <summary>
        /// Gets or sets the Results
        /// </summary>
        /// <value>All the Starships</value>
        public ICollection<T> Results { get; set; }

        /// <summary>
        /// Gets or sets the Count
        /// </summary>
        /// <value>Total Starships in Database</value>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the Next
        /// </summary>
        /// <value>Url for the next page on the API</value>
        public string Next { get; set; }

        /// <summary>
        /// Gets or sets the Previous
        /// </summary>
        /// <value>Url for the previous page on the API</value>
        public string Previous { get; set; }

    }
}
