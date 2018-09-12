

namespace StarshipCalculator
{
    /// <summary>
    /// This class represents a model of starship in the system
    /// </summary>
public    class Starship

    {
        public Starship()
        {

        }

        public Starship(string shipName, decimal fuelRange)
        {
            ShipName = shipName;
            FuelRange = fuelRange;

        }


        /// <summary>
        /// The name of the model of Starship
        /// </summary>
        public string ShipName { get; set; }
       

        /// <summary>
        /// The range in MGLT for a full load of fuel
        /// </summary>
        public decimal FuelRange { get; set; }


        /// <summary>
        /// The numberof fuel stops requried to complete a journey
        /// </summary>
        public int FuelStops { get; set; }
        
    }

}
