using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CruiseScanner.PandO.Web.Scraping.Trips;
using Newtonsoft.Json;

namespace CruiseScanner.PandO.Web.Scraping.Site
{
    internal class SiteService
    {
        public async Task<IEnumerable<TripDto>> PAndOSearch(int maxResults)
        {
            var http = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://www.pocruises.com/search/po_en_GB/cruisesearch?" +
                                                                 "&fq=(soldOut:(false)%20AND%20price_GBP_anonymous:[1%20TO%20*])" +
                                                                 "&start=0" +
                                                                 "&sort=departDate%20asc,price_GBP_anonymous%20asc" +
                                                                 "&group.sort=departDate%20asc,price_GBP_anonymous%20asc" +
                                                                 $"&rows={maxResults}" +
                                                                 "&fq=departDate:[NOW/DAY%2B2DAY%20TO%20*]" +
                                                                 "&facet.query={!ex=priceTag}price_GBP_anonymous:[1%20TO%20500]" +
                                                                 "&facet.query={!ex=priceTag}price_GBP_anonymous:[501%20TO%201000]" +
                                                                 "&facet.query={!ex=priceTag}price_GBP_anonymous:[1001%20TO%201500]" +
                                                                 "&facet.query={!ex=priceTag}price_GBP_anonymous:[1501%20TO%202000]" +
                                                                 "&facet.query={!ex=priceTag}price_GBP_anonymous:[2001%20TO%203500]" +
                                                                 "&facet.query={!ex=priceTag}price_GBP_anonymous:[3501%20TO%205000]" +
                                                                 "&facet.query={!ex=priceTag}price_GBP_anonymous:[5000%20TO%2010000]" +
                                                                 "&facet.query={!ex=priceTag}price_GBP_anonymous:[10000%20TO%20*]" +
                                                                 "&facet.field={!ex=airportsTag}airportNames_GBP_anonymous" +
                                                                 "&facet.field=flightPackage_GBP_anonymous" +
                                                                 "&facet.range={!ex=departTag}departDate" +
                                                                 "&f.departDate.facet.range.start=NOW/YEAR" +
                                                                 "&f.departDate.facet.range.gap=%2B1MONTH" +
                                                                 "&f.departDate.facet.range.end=NOW/YEAR%2B4YEAR");
            var response = await http.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SearchResponseModel>(json);
            return result.ToTripDtos();
        }

        public async Task<IEnumerable<TripDto>> CunardSearch(int maxResults)
        {
            var http = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, 
                "https://www.cunard.com/search/cunard_en_GB/cruisesearch?" +
                "&fq=(soldOut:(false)%20AND%20price_GBP_anonymous:[1%20TO%20*])" +
                "&start=0" +
                "&sort=departDate%20asc,price_GBP_anonymous%20asc" +
                "&group.sort=departDate%20asc,price_GBP_anonymous%20asc" +
                $"&rows={maxResults}" +
                "&fq=departDate:[NOW/DAY%2B0DAY%20TO%20*]" +
                "&facet.query={!ex=priceTag}price_GBP_anonymous:[0%20TO%201000]" +
                "&facet.query={!ex=priceTag}price_GBP_anonymous:[1000%20TO%202000]" +
                "&facet.query={!ex=priceTag}price_GBP_anonymous:[2000%20TO%203000]" +
                "&facet.query={!ex=priceTag}price_GBP_anonymous:[3000%20TO%205000]" +
                "&facet.query={!ex=priceTag}price_GBP_anonymous:[5000%20TO%20*]" +
                "&facet.range={!ex=departTag}departDate" +
                "&f.departDate.facet.range.start=NOW/YEAR" +
                "&f.departDate.facet.range.gap=%2B1MONTH" +
                "&f.departDate.facet.range.end=NOW/YEAR%2B4YEAR");
            var response = await http.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SearchResponseModel>(json);
            return result.ToTripDtos();
        }

        public async Task<IEnumerable<TripDto>> RoyalCaribbeanSearch(int maxResults)
        {
            var http = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://www.royalcaribbean.com/ajax/cruises/service/lookup?initialLoad=true" +
                "&loadLinks=true" +
                "&market=gbr" +
                "&country=GBR" +
                "&language=en" +
                "&country=GBR" +
                "&browser=chrome" +
                "&screenWidth=1920" +
                "&browserWidth=1920");
            var response = await http.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SearchResponseModel>(json);
            return result.ToTripDtos();
        }
    }
}
