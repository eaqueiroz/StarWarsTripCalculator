#region File Header
// ***********************************************************************
// Assembly         : ConsoleUIHandler
// Author           : Eduardo Queiroz
// Created          : 14/02/2020
//
// ***********************************************************************
// <copyright file="StarWarsConsoleUI.cs" company="EQueiroz">
//     Copyright ©  2020
// </copyright>
// <summary>Handles the console application UI</summary>
// ***********************************************************************
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using Common.Model;
using Microsoft.Extensions.Logging;
using StarWars.BusinessLogic;
using SwApiWrapper;

namespace ConsoleUIHandler
{
    public class StarWarsConsoleUI
    {
        #region Attributes
        private readonly ILogger _logger;
        #endregion

        #region Ctor
        public StarWarsConsoleUI(ILogger<StarWarsConsoleUI> logger)
        {
            this._logger = logger;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Prints Welcome Text
        /// </summary>
        public void PrintWelcome()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                    `````````````````````````````  ```````````       ````````````````               ");
            Console.WriteLine("                 :ymMMMMMMMMMMMMMMMMMMMMMMMMMMMM/ `mMMMMMMMMMMo      yMMMMMMMMMMMMMMNho.            ");
            Console.WriteLine("                sMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM/ oMMMMMMMMMMMN-     yMMMMMMMMMMMMMMMMMN/           ");
            Console.WriteLine("               .MMMMMMMMNNNNNNNNNMMMMMMMNNNNNNNN/.NMMMMMMNMMMMMd     yMMMMMMMoooosNMMMMMN`          ");
            Console.WriteLine("                dMMMMMMMd/`      yMMMMMM`        hMMMMMMooMMMMMM+    yMMMMMMN/:::/mMMMMMm`          ");
            Console.WriteLine("                .yNMMMMMMMd-     yMMMMMM`       /MMMMMMm``dMMMMMN.   yMMMMMMMMMMMMMMMMMm:           ");
            Console.WriteLine("    ..............+mMMMMMMMN`    yMMMMMM`      `NMMMMMMmhhmMMMMMMh   yMMMMMMMMMMMMMMMmo-........    ");
            Console.WriteLine("   `MNNNNNNNNNNNNNNMMMMMMMMM-    yMMMMMM`      yMMMMMMMMMMMMMMMMMM/  yMMMMMMMhMMMMMMMMMMMMMMMMMM`   ");
            Console.WriteLine("   `MMMMMMMMMMMMMMMMMMMMMMMy     yMMMMMM`     :MMMMMMNddddddNMMMMMN. yMMMMMMN :hMMMMMMMMMMMMMMMM`   ");
            Console.WriteLine("   `NNNNNNNNNNNNNNNNNNNNmh/`     yNNNNNN`    `dNNNNNN-      /NNNNNNs yNNNNNNm   :ymNNNNNNNNNNNNN`   ");
            Console.WriteLine("    +++++++/--:+++++++/.``-------.--/+++------+------ `------/+++++/-:-------    `-/++++++++++++    ");
            Console.WriteLine("    yNNNNNNm. yNNNNNNNm. sNNNNNNy  .mNNNNNNNNNN+      +NNNNNNNNNNNNNNmds:      :ydNNNNNNNNNNNNNN`   ");
            Console.WriteLine("    .NMMMMMMy:MMMMMMMMMy-MMMMMMN.  yMMMMMMMMMMMN.     +MMMMMMMMMMMMMMMMMNs    oNMMMMMMMMMMMMMMMM`   ");
            Console.WriteLine("     +MMMMMMMmMMMMMMMMMMmMMMMMM+  :MMMMMMNMMMMMMy     +MMMMMMMs+++omMMMMMM-  `NMMMMMMMNddddddddd`   ");
            Console.WriteLine("      hMMMMMMMMMMMMMMMMMMMMMMMh  `mMMMMMM/sMMMMMM/    +MMMMMMMo////dMMMMMM.   yMMMMMMMNs.```````    ");
            Console.WriteLine("      -NMMMMMMMMMMMMMMMMMMMMMN-  sMMMMMMy `mMMMMMm`   +MMMMMMMMMMMMMMMMMm/    `oNMMMMMMMm/          ");
            Console.WriteLine("       oMMMMMMMMMMmMMMMMMMMMMo  -NMMMMMMmhhNMMMMMMs   +MMMMMMMMMMMMMMMNs:-------/dMMMMMMMM:         ");
            Console.WriteLine("        dMMMMMMMMm.dMMMMMMMMm`  dMMMMMMMMMMMMMMMMMM:  +MMMMMMMhNMMMMMMMNNNNNNNNNNMMMMMMMMM+         ");
            Console.WriteLine("        -MMMMMMMM: -MMMMMMMM:  +MMMMMMmhhhhhhNMMMMMm` +MMMMMMM..yNMMMMMMMMMMMMMMMMMMMMMMMd`         ");
            Console.WriteLine("         sMMMMMMy   sMMMMMMy  .NMMMMMN.      +MMMMMMs +MMMMMMM.  .sdNMMMMMMMMMMMMMMMMMNh/`          ");
            Console.WriteLine("          ``````     ``````    ```````        ``````` ````````      ```````````````````             ");
            Console.WriteLine("");
            Console.WriteLine("Welcome to Start Wars Trip Calculator");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("");

        }

        /// <summary>
        /// Initializes a new instance of <see cref="FakeWebRequest"/>
        /// with the response to return.
        /// </summary>
        public async void Run()
        {
            //Instantiate the Api Wrapper for the desired Entity
            var helper = new WebHelper<Startship>(_logger);

            //Request all the Starships
            var ships = await helper.GetAll();

            //Print UI Welcome
            PrintWelcome();

            //ask User to input the distance
            var distance = PrintInputDistance();

            //do the math
            var stops = TripCalculator.CalculateTripStops(ships.ToArray(), distance);

            //Print the data in a formated table
            PrintStopsTable(stops);

            //print thank you and good bye
            PrintThankYouGoodBye();
        }

        /// <summary>
        /// Prompts the user to input a valid distance
        /// </summary>
        public void PrintStopsTable(List<KeyValuePair<string, string>> stops)
        {
            Console.WriteLine("");
            Console.WriteLine("Starship                      | Stops     ");
            Console.WriteLine("__________________________________________________________");

            foreach (var stop in stops)
            {
                Console.WriteLine($"{stop.Key.PadRight(30)}| {stop.Value.PadRight(10)}");
            }

        }

        /// <summary>
        /// Prints Thank you
        /// Prints Good
        /// and wit for the user press any key to exit 
        /// </summary>
        public  void PrintThankYouGoodBye()
        {
            Console.WriteLine("__________________________________________________________\r\n");
            Console.WriteLine("Have a safe journey!");
            Console.WriteLine("(Press any key to exit the program)");
            Console.ReadLine();
        }

        /// <summary>
        /// Prompts the user to input a valid distance
        /// </summary>
        public int PrintInputDistance()
        {
            int distance = 0;
            while (distance == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("In order to calculate your trip, please provide the desired distance in MegaLights between 1 and 2147483647:");
                distance = TripCalculator.ParseDistance(Console.ReadLine());
            }

            return distance;
        }
        #endregion

    }
}
