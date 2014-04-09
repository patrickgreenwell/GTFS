using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GTFS.Model
{
    /// <summary>
    /// Specifies the General Transit Feed Format Object containing all Information regarding a specific transit feed.
    /// </summary>
    public class Feed
    {
        #region Required for the Feed

        /// <summary>
        /// One or more transit agencies that provide the data in the feed.
        /// </summary>
        [Required]
        public List<Agency> Agency { get; private set; }

        /// <summary>
        /// Individual locations where vehicles pick up or drop off passengers.
        /// </summary>
        [Required]
        public List<Stop> Stops { get; private set; }

        /// <summary>
        /// Transit routes. A route is a group of trips that are displayed to riders as a single service.
        /// </summary>
        [Required]
        public List<Route> Routes { get; private set; }

        /// <summary>
        /// Trips for each route. A trip is a sequence of two or more stops that occurs at a specific time.
        /// </summary>
        [Required]
        public List<Trip> Trips { get; private set; }

        /// <summary>
        /// Times that a vehicle arrives at and departs from individual stops for each trip.
        /// </summary>
        [Required]
        public List<StopTime> StopTimes { get; private set; }

        /// <summary>
        /// Dates for service Ids defined in the calendar.  If CalendarDates includes ALL dates of service, this file may be specified instead of Calendar.
        /// </summary>
        [Required]
        public List<Calendar> Calendar { get; private set; }

        #endregion

        #region Optional Feeds
        /// <summary>
        /// Exceptions for the service IDs defined in the calendar.txt file. If calendar_dates.txt includes ALL dates of service, this file may be specified instead of calendar.txt.
        /// </summary>
        public List<CalendarDate> CalendarDates { get; private set; }
        
        /// <summary>
        /// Fare information for a transit organization's routes.
        /// </summary>
        public List<FareAttribute> FareAttributes { get; private set; }
        
        /// <summary>
        /// Rules for applying fare information for a transit organization's routes.
        /// </summary>
        public List<FareRule> FareRules { get; private set; }
        
        /// <summary>
        /// Rules for drawing lines on a map to represent a transit organization's routes.
        /// </summary>
        public List<Shape> Shapes { get; private set; }
        
        /// <summary>
        /// Headway (time between trips) for routes with variable frequency of service.
        /// </summary>
        public List<Frequency> Frequencies { get; private set; }
        
        /// <summary>
        /// Rules for making connections at transfer points between routes.
        /// </summary>
        public List<Transfer> Transfers { get; private set; }
        
        /// <summary>
        /// Additional information about the feed itself, including publisher, version, and expiration information.
        /// </summary>
        public List<FeedInfo> FeedInfo { get; private set; }
        #endregion
    }
}
