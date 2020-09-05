using System.Collections.Generic;
using System.IO;
using Xunit;
using Linq;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace LinqTest
{
    public class GeoDataTests
    {
        static string Data = GeoData.Data;
        public RootObject Root = JsonConvert.DeserializeObject<RootObject>(Data);
        

        [Fact]
        public void Can_read_file()
        {
            // Arrange

            // Act
           
            // Assert
            Assert.NotEmpty(Data);

            Assert.Equal("FeatureCollection",Root.type);
        }
        [Fact]
        public void Output147Neighborhoods()
        {
            Assert.Equal(147, Root.features.Count());
        }

        [Fact]

        public void Output143NotNullNeighborhoods()
        {
            IEnumerable<string> notNull =
                from x in Root.features
                where x.properties.neighborhood.Length > 0
                select x.properties.neighborhood;

            Assert.Equal(143, notNull.Count());
        }
        [Fact]
        public void Output39RemoveDuplicateNeighborhoods()
        {
            IEnumerable<string> nonDuplicates = Root.features
                .Select(x => x.properties.neighborhood)
                .Where(neighborhood => !neighborhood.Equals(""))
                .Distinct();

            Assert.Equal(39, nonDuplicates.Count());
        }

    }
}
