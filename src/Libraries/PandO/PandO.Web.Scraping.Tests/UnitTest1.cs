using System;
using System.Linq;
using System.Threading.Tasks;
using CruiseScanner.PandO.Web.Scraping.Site;
using Xunit;

namespace PandO.Web.Scraping.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task PAndOSearch()
        {
            var service = new SiteService();
            var trips = await service.PAndOSearch(10);
            Assert.NotNull(trips);
            Assert.Equal(10, trips.Count());

        }

        [Fact]
        public async Task CunardSearch()
        {
            var service = new SiteService();
            var trips = await service.CunardSearch(10);
            Assert.NotNull(trips);
            Assert.Equal(10, trips.Count());
        }
    }
}
