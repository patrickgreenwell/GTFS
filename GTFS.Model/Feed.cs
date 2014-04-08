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
        public IList<Agency> Agency { get; private set; }

        /// <summary>
        /// Individual locations where vehicles pick up or drop off passengers.
        /// </summary>
        [Required]
        public IList<Stop> Stops { get; private set; }

        /// <summary>
        /// Transit routes. A route is a group of trips that are displayed to riders as a single service.
        /// </summary>
        [Required]
        public IList<Route> Routes { get; private set; }

        /// <summary>
        /// Trips for each route. A trip is a sequence of two or more stops that occurs at a specific time.
        /// </summary>
        [Required]
        public IList<Trip> Trips { get; private set; }

        /// <summary>
        /// Times that a vehicle arrives at and departs from individual stops for each trip.
        /// </summary>
        [Required]
        public IList<StopTime> StopTimes { get; private set; }

        /// <summary>
        /// Dates for service Ids defined in the calendar.  If CalendarDates includes ALL dates of service, this file may be specified instead of Calendar.
        /// </summary>
        [Required]
        public IList<Calendar> Calendar { get; private set; }

        #endregion

        #region Optional Feeds
        /// <summary>
        /// Exceptions for the service IDs defined in the calendar.txt file. If calendar_dates.txt includes ALL dates of service, this file may be specified instead of calendar.txt.
        /// </summary>
        public IList<CalendarDate> CalendarDates { get; private set; }
        
        /// <summary>
        /// Fare information for a transit organization's routes.
        /// </summary>
        public IList<FareAttribute> FareAttributes { get; private set; }
        
        /// <summary>
        /// Rules for applying fare information for a transit organization's routes.
        /// </summary>
        public IList<FareRule> FareRules { get; private set; }
        
        /// <summary>
        /// Rules for drawing lines on a map to represent a transit organization's routes.
        /// </summary>
        public IList<Shape> Shapes { get; private set; }
        
        /// <summary>
        /// Headway (time between trips) for routes with variable frequency of service.
        /// </summary>
        public IList<Frequency> Frequencies { get; private set; }
        
        /// <summary>
        /// Rules for making connections at transfer points between routes.
        /// </summary>
        public IList<Transfer> Transfers { get; private set; }
        
        /// <summary>
        /// Additional information about the feed itself, including publisher, version, and expiration information.
        /// </summary>
        public IList<FeedInfo> FeedInfo { get; private set; }
        #endregion
    }
}
