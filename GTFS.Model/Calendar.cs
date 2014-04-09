using System;
using System.ComponentModel.DataAnnotations;

namespace GTFS.Model
{
    /// <summary>
    /// Dates for service IDs using a weekly schedule. Specify when service starts and ends, as well as days of the week where service is available.
    /// </summary>
    public class Calendar
    {
        /// <summary>
        /// The service_id contains an ID that uniquely identifies a set of dates when service is available for one or more routes. Each service_id value can appear at most once in a calendar.txt file. This value is dataset unique. It is referenced by the trips.txt file.
        /// </summary>
        [Key, Required]
        public string service_id { get; set; }

        /// <summary>
        /// A binary value that indicates whether the service is valid. A value of 1 indicates that service is available for all Mondays in the date range. A value of 0 indicates that service is not available on Mondays in the date range 
        /// </summary>
        public ushort monday { get; set; }

        /// <summary>
        /// A binary value that indicates whether the service is valid. A value of 1 indicates that service is available for all Tuesdays in the date range. A value of 0 indicates that service is not available on Tuesdays in the date range 
        /// </summary>
        public ushort tuesday { get; set; }

        /// <summary>
        /// A binary value that indicates whether the service is valid. A value of 1 indicates that service is available for all Wednesdays in the date range. A value of 0 indicates that service is not available on Wednesdays in the date range 
        /// </summary>
        public ushort wednesday { get; set; }

        /// <summary>
        /// A binary value that indicates whether the service is valid. A value of 1 indicates that service is available for all Thursdays in the date range. A value of 0 indicates that service is not available on Thursdays in the date range 
        /// </summary>
        public ushort thursday { get; set; }

        /// <summary>
        /// A binary value that indicates whether the service is valid. A value of 1 indicates that service is available for all Fridays in the date range. A value of 0 indicates that service is not available on Fridays in the date range 
        /// </summary>
        public ushort friday { get; set; }

        /// <summary>
        /// A binary value that indicates whether the service is valid. A value of 1 indicates that service is available for all Saturdays in the date range. A value of 0 indicates that service is not available on Saturdays in the date range 
        /// </summary>
        public ushort saturday { get; set; }

        /// <summary>
        /// A binary value that indicates whether the service is valid. A value of 1 indicates that service is available for all Sundays in the date range. A value of 0 indicates that service is not available on Sundays in the date range 
        /// </summary>
        public ushort sunday { get; set; }

        /// <summary>
        /// The start_date field contains the start date for the service.<para>The start_date field's value should be in YYYYMMDD format.</para>
        /// </summary>
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "YYYYMMDD")]
        public DateTime start_date { get; set; }

        /// <summary>
        /// The end_date field contains the start date for the service.<para>The end_date field's value should be in YYYYMMDD format.</para>
        /// </summary>
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "YYYYMMDD")]
        public DateTime end_date { get; set; }
    }
}
