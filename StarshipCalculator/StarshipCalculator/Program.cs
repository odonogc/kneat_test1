using System;
using System.Collections.Generic;
using System.Text;


namespace StarshipCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                long distance;
                if (args.Length > 0)

                    distance = long.Parse(args[0]);
                else
                    throw new ArgumentException("Please specify a distance");

                List<Starship> starships = GetStarships();

                Console.WriteLine(GetResponse(distance, starships));

                Console.Read();
            }
            catch (Exception e)
            {

                Console.Write(e.Message);
            }

        }

        internal static List<Starship> GetStarships()
        {
            var response = new List<Starship>();


            var shipList = new SharpTrooper.Core.SharpTrooperCore().GetAllStarships();


            if (shipList?.count > 0)

                foreach (var v in shipList.results)
                {
                    decimal mglt;
                    if (Decimal.TryParse(v.MGLT, out mglt))
                        response.Add(new Starship() {ShipName = v.name, FuelRange = mglt});
                }

            return response;

        }

        internal static string GetResponse(long distance, List<Starship> starships)
        {
            var response = new StringBuilder();

            if (starships == null || starships.Count == 0)

                response.Append("No Star Ships listed");
            else
            {
                
                foreach (var v in starships)
                {
                    if (v.FuelRange > 0)
                        v.FuelStops = GetFuelStops(v.FuelRange, distance);
                    

                    response.Append(v.ShipName);
                    response.Append(" ");
                    response.Append(v.FuelStops);
                    response.Append(Environment.NewLine);
                }
                response.Append(Environment.NewLine);
                response.Append("Press the enter key to close...");
            }

            return response.ToString();

        }

        internal static int GetFuelStops(decimal fuelRange, long distance)
        {
            if (fuelRange == 0 || distance == 0)
                return 0;

            var result = (int) Math.Floor(distance / fuelRange);
            if (distance % (int) fuelRange == 0) //don't count refuelling at destination
                result--;

            return result;

        }
    }
}
