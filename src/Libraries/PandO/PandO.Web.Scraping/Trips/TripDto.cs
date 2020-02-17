using System;
using System.Collections.Generic;
using System.Text;
using CruiseScanner.PandO.Web.Scraping.Ports;
using CruiseScanner.PandO.Web.Scraping.Ships;

namespace CruiseScanner.PandO.Web.Scraping.Trips
{
    internal class TripDto
    {
        public ShipDto Ship { get; set; }
        public PortDto Departure { get; set; }
        public PortDto Arrival { get; set; }

        public TripDto(ShipDto ship, PortDto departure, PortDto arrival)
        {
            Ship = ship;
            Departure = departure;
            Arrival = arrival;
        }
    }
}
