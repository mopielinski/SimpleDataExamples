namespace SimpleDataTest.Models
{
    public class HotelAppVersion
    {
        public int Id { get; set; }
        public int AppVersionId { get; set; }

        public int HotelId { get; set; }

        public string PriceSources { get; set; }

        public string LengthOfStay { get; set; }

        public string Occupancy { get; set; }

        public string AutomaticDailyReports { get; set; }

        public string AutomaticWeeklyReports { get; set; }

        public string ReportSubscribers { get; set; }
        public virtual AppVersion AppVersion { get; set; }
    }
}