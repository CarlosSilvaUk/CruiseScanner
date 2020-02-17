using System.Collections.Generic;
using System.Linq;
using CruiseScanner.PandO.Web.Scraping.Ports;
using CruiseScanner.PandO.Web.Scraping.Ships;
using CruiseScanner.PandO.Web.Scraping.Trips;
using Newtonsoft.Json;

namespace CruiseScanner.PandO.Web.Scraping.Site
{
    internal static class SearchResponseModelExtensions
    {
        public static IEnumerable<TripDto> ToTripDtos(this SearchResponseModel model)
        {
            return model.SearchResults.Select(x => x.ToTripDto());
        }

        public static TripDto ToTripDto(this SearchResponseModel.SearchResult model)
        {
            return new TripDto(
                ship: new ShipDto(model.shipName), 
                departure: new PortDto(model.departurePortCode, model.departurePortName), 
                arrival: new PortDto(model.arrivalPortCode, model.arrivalPortName));
        }
    }

    internal class SearchResponseModel
    {
        [JsonProperty("results")]
        public string Results { get; set; }

        [JsonProperty("searchResults")]
        public SearchResult[] SearchResults { get; set; }

        public class SearchResult
        {

            [JsonProperty("itineraryId")]
            public string itineraryId { get; set; }

            [JsonProperty("itineraryImage")]
            public string itineraryImage { get; set; }

            [JsonProperty("itineraryImageAlt")]
            public string itineraryImageAlt { get; set; }

            [JsonProperty("renditions")]
            public object renditions { get; set; }

            [JsonProperty("verticalRenditions")]
            public object verticalRenditions { get; set; }

            [JsonProperty("itineraryPath")]
            public string itineraryPath { get; set; }

            [JsonProperty("cruiseId")]
            public string cruiseId { get; set; }

            [JsonProperty("cruiseCode")]
            public string cruiseCode { get; set; }

            [JsonProperty("tourId")]
            public string tourId { get; set; }

            [JsonProperty("title")]
            public string title { get; set; }

            [JsonProperty("cruiseShortName")]
            public string cruiseShortName { get; set; }

            [JsonProperty("nightTitle")]
            public string nightTitle { get; set; }

            [JsonProperty("serviceCharges")]
            public object serviceCharges { get; set; }

            [JsonProperty("portCharges")]
            public object portCharges { get; set; }

            [JsonProperty("documents")]
            public object documents { get; set; }

            [JsonProperty("portImages")]
            public object portImages { get; set; }

            [JsonProperty("cruiseOfferNames")]
            public object cruiseOfferNames { get; set; }

            [JsonProperty("cruiseThemes")]
            public object cruiseThemes { get; set; }

            [JsonProperty("shipName")]
            public string shipName { get; set; }

            [JsonProperty("departurePortName")]
            public string departurePortName { get; set; }

            [JsonProperty("departurePortCode")]
            public string departurePortCode { get; set; }

            [JsonProperty("shipId")]
            public string shipId { get; set; }

            [JsonProperty("shipVersion")]
            public string shipVersion { get; set; }

            [JsonProperty("visitingCountries")]
            public string visitingCountries { get; set; }

            [JsonProperty("departureDate")]
            public string departureDate { get; set; }

            [JsonProperty("arrivalPortName")]
            public string arrivalPortName { get; set; }

            [JsonProperty("arrivalPortCode")]
            public string arrivalPortCode { get; set; }

            [JsonProperty("cruiseSellingState")]
            public string cruiseSellingState { get; set; }
        }

        [JsonProperty("filterList")]
        public Filter[] filterList { get; set; }

        public class Filter
        {

            [JsonProperty("type")]
            public string type { get; set; }

            [JsonProperty("attributes")]
            public object attributes { get; set; }
        }
    }
}