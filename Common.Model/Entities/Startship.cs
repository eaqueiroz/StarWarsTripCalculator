using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;


namespace Common.Model
{
    [ExcludeFromCodeCoverage]
    public class Startship: ISwEntity
    {
        public string GetEntityPath()
        {
            return @"starships/";
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>The model.</value>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer.
        /// </summary>
        /// <value>The manufacturer.</value>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the cost in credits.
        /// </summary>
        /// <value>The cost in credits.</value>
        [JsonPropertyName("cost_in_credits")]
        public string CostInCredits { get; set; }

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>The length.</value>
        [JsonPropertyName("Length")]
        public string Length { get; set; }

        /// <summary>
        /// Gets or sets the max atmospheric speed.
        /// </summary>
        /// <value>The maximum atmospheric speed.</value>
        [JsonPropertyName("max_atmosphering_speed")]
        public string MaxAtmospheringSpeed { get; set; }

        /// <summary>
        /// Gets or sets the Crew count as string.
        /// </summary>
        /// <value>The crew.</value>        
        public string Crew { get; set; }

        /// <summary>
        /// Gets or sets the passengers count as string.
        /// </summary>
        /// <value>The passengers.</value>
        public string Passengers { get; set; }

        /// <summary>
        /// Gets or sets the cargo capacity.
        /// </summary>
        /// <value>The cargo capacity.</value>
        [JsonPropertyName("cargo_capacity")]
        public string CargoCapacity { get; set; }

        /// <summary>
        /// Gets or sets the consumables period.
        /// </summary>
        /// <value>The consumables.</value>
        public string Consumables { get; set; }


        /// <summary>
        /// Gets or sets the hyper drive rating.
        /// </summary>
        /// <value>The hyper drive rating.</value>
        [JsonPropertyName("hyperdrive_rating")]
        public string HyperdriveRating { get; set; }

        /// <summary>
        /// Gets or sets the mega lights.
        /// </summary>
        /// <value>The mega lights.</value>
        [JsonPropertyName("MGLT")]
        public string MegaLights { get; set; }

        /// <summary>
        /// Gets or sets the starship class.
        /// </summary>
        /// <value>The starship class.</value>
        [JsonPropertyName("starship_class")]
        public string StarshipClass { get; set; }


        /// <summary>
        /// Gets or sets the pilots URLs.
        /// </summary>
        /// <value>The pilots.</value>
        public ICollection<string> Pilots { get; set; }


        /// <summary>
        /// Gets or sets the films URLs.
        /// </summary>
        /// <value>The films.</value>
        public ICollection<string> Films { get; set; }

        public int? ConsumablesInDays()
        {
            foreach (var name in Enum.GetNames(typeof(ConsumablesInDays)))
            {
                if (this.Consumables.Contains(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    Match m = Regex.Match(this.Consumables, "\\d+");
                    if (int.TryParse(m.Value, out var inDays))
                    {
                        var multiplier = (int)Enum.Parse(typeof(ConsumablesInDays), name);
                        return inDays*multiplier;
                    }
                }
            }

            return null;

        }
    }
}
