using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseScanner.PandO.Web.Scraping.Ships
{
    internal class ShipDto
    {
        public string Name { get; set; }

        public ShipDto(string name)
        {
            Name = name;
        }
    }
}
