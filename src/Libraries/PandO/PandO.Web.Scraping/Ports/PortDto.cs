using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseScanner.PandO.Web.Scraping.Ports
{
    class PortDto
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public PortDto(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
