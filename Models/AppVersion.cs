using System.Collections.Generic;

namespace SimpleDataExamples.Models
{
    public class AppVersion
    {
        public AppVersion()
        {
            this.HotelAppVersions = new List<HotelAppVersion>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string VersionDetails { get; set; }

        public string DefaultValues { get; set; }
        public ICollection<HotelAppVersion> HotelAppVersions { get; set; }
    }
}