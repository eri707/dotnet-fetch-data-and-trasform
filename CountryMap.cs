using System.Collections.Generic;

namespace dotnet_fetch_data_and_transform
{
    public class CountryMap
    {
        public string Name { get; set; }
        public string CapitalCity { get; set; }
        public int Population { get; set; }
        public string Region { get; set; }
        // need <string> to get only "Code"
        public IEnumerable<string> Currencies { get; set; }
    }
}
