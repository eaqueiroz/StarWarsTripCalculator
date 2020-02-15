#region File Header
// ***********************************************************************
// Assembly         : StarWars.BusinessLogic
// Author           : Eduardo Queiroz
// Created          : 14/02/2020
//
// ***********************************************************************
// <copyright file="TripCalculator.cs" company="EQueiroz">
//     Copyright ©  2020
// </copyright>
// <summary>Handles the console application UI</summary>
// ***********************************************************************
#endregion
using System.Collections.Generic;
using Common.Model;

namespace StarWars.BusinessLogic
{
    public class TripCalculator
    {
        /// <summary>
        /// Calculate how many stops are necessary to complete the journey
        /// based on the amount of consumables and the speed of the ship
        /// </summary>
        public static List<KeyValuePair<string, string>> CalculateTripStops(Startship[] ships, double distance)
        {
            var list = new List<KeyValuePair<string, string>>();

            foreach (var ship in ships)
            {
                string stopsForResupply = @"N/A";

                if (int.TryParse(ship.MaxAtmospheringSpeed, out var speed) && ship.ConsumablesInDays().HasValue)
                {
                    //Distance that the ship can travel in a day
                    var distancePerDay = speed * 24.0;
                    //how long would take to complete the journey
                    var journeyInDays = distance / distancePerDay;
                    //number to stops for resupply
                    var stops = journeyInDays / (double)ship.ConsumablesInDays();
                    //assuming that the ship departed with full stock of consumables, round down the stops
                    stopsForResupply = ((int)stops).ToString();
                }

                list.Add(new KeyValuePair<string, string>(ship.Name, stopsForResupply));
            }

            return list;
        }

        /// <summary>
        /// Convert a string in a valid Distance
        /// </summary>
        /// <param name="distance"></param>
        /// <returns>distance integer</returns>
        public static int ParseDistance(string distance)
        {
            return int.TryParse(distance, out var dist) && dist > 0 ? dist : 0;
        }
    }
}
