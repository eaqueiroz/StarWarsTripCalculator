#region File Header
// ***********************************************************************
// Assembly         : StarWars.BusinessLogic.Test
// Author           : Eduardo Queiroz
// Created          : 14/02/2020
//
// ***********************************************************************
// <copyright file="TripCalculatorTest.cs" company="EQueiroz">
//     Copyright ©  2020
// </copyright>
// <summary>Unit tests for the business Logic </summary>
// ***********************************************************************
#endregion

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Common.Model;
using Xunit;

namespace StarWars.BusinessLogic.Test
{
    [ExcludeFromCodeCoverage]
    public class TripCalculatorTest
    {
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

        [Fact]
        public void CalculateStops()
        {
            string responseJson = "[{\"name\":\"Executor\",\"model\":\"Executor-class star dreadnought\",\"manufacturer\":\"Kuat Drive Yards, Fondor Shipyards\",\"cost_in_credits\":\"1143350000\",\"length\":\"19000\",\"max_atmosphering_speed\":\"n/a\",\"crew\":\"279144\",\"passengers\":\"38000\",\"cargo_capacity\":\"250000000\",\"consumables\":\"6 years\",\"hyperdrive_rating\":\"2.0\",\"MGLT\":\"40\",\"starship_class\":\"Star dreadnought\",\"pilots\":[],\"films\":[\"https://swapi.co/api/films/2/\",\"https://swapi.co/api/films/3/\"],\"created\":\"2014-12-15T12:31:42.547000Z\",\"edited\":\"2017-04-19T10:56:06.685592Z\",\"url\":\"https://swapi.co/api/starships/15/\"}]";
            var ships = JsonSerializer.Deserialize<Startship[]>(responseJson, SerializerOptions);
            var results = TripCalculator.CalculateTripStops(ships,100000);

            Assert.NotNull(results);
        }

        [Fact]
        public void ParseDistance()
        {
            var result = TripCalculator.ParseDistance("9999");
            Assert.Equal(9999,result);
        }
    }
}
