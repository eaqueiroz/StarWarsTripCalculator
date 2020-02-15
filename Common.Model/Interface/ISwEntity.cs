#region File Header
// ***********************************************************************
// Assembly         : ApiWrapper
// Author           : Eduardo Queiroz
// Created          : 13/02/2020
//
// ***********************************************************************
// <copyright file="ISwEntity.cs" company="EQueiroz">
//     Copyright ©  2020
// </copyright>
// <summary>Interface defining SW Entities</summary>
// ***********************************************************************
#endregion

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Model
{
    public interface ISwEntity
    {
        string GetEntityPath();
    }

    public interface IWebHelper<T> where T : ISwEntity
    {
        /// <summary>
        /// Make a request to a specific URL
        /// </summary>
        /// <param name="uri">Url Address</param>
        /// <returns>Response in Json format</returns>
        Task<string> Request(string uri);

        /// <summary>
        /// Return all the Starships in the database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Get a specific starship by Id
        /// </summary>
        /// <param name="starshipId">Id of Starship</param>
        /// <returns>Starship Data</returns>
        Task<T> GetbyId(int starshipId);

        /// <summary>
        /// Returns the full path of the current Entity
        /// </summary>
        /// <returns></returns>
        string GetEntityPath();
    }
}
