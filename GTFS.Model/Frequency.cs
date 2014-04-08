using System;
using System.ComponentModel.DataAnnotations;

namespace GTFS.Model
{
    /// <summary>
    /// This table is intended to represent schedules that don't have a fixed list of stop times. When trips are defined in <see cref="GTFS.Model.Feed.Frequencies"/>, the trip planner ignores the absolute values of the <see cref="GTFS.Model.Frequency.arrival_time"/> and <see cref="GTFS.Model.Frequency.departure_time"/> fields for those trips in <see cref="GTFS.Model.Feed.StopTimes"/>. Instead, the stop_times table defines the sequence of stops and the time difference between each stop.
    /// </summary>
    public class Frequency
    {
        /// <summary>
        /// The trip_id contains an ID that identifies a trip on which the specified frequency of service applies. Trip IDs are referenced from <see cref=" GTFS.Model.Feed.Trips"/>.
        /// </summary>
        [Required]
        public string trip_id { get; set; }

        /// <summary>
        /// The start_time field specifies the time at which service begins with the specified frequency. The time is measured from "noon minus 12h" (effectively midnight, except for days on which daylight savings time changes occur) at the beginning of the service date. For times occurring after midnight, enter the time as a value greater than 24:00:00 in HH:MM:SS local time for the day on which the trip schedule begins. E.g. 25:35:00.
        /// </summary>
        [Required]
        public string start_time { get; set; }

        /// <summary>
        /// The end_time field indicates the time at which service changes to a different frequency (or ceases) at the first stop in the trip. The time is measured from "noon minus 12h" (effectively midnight, except for days on which daylight savings time changes occur) at the beginning of the service date. For times occurring after midnight, enter the time as a value greater than 24:00:00 in HH:MM:SS local time for the day on which the trip schedule begins. E.g. 25:35:00.
        /// </summary>
        [Required]
        public string end_time { get; set; }

        /// <summary>
        /// The headway_secs field indicates the time between departures from the same stop (headway) for this trip type, during the time interval specified by start_time and end_time. The headway value must be entered in seconds.
        /// </summary>
        /// <example>
        /// Periods in which headways are defined (the rows in frequencies.txt) shouldn't overlap for the same trip, since it's hard to determine what should be inferred from two overlapping headways. However, a headway period may begin at the exact same time that another one ends, for instance:
        /// <code>
        /// A, 05:00:00, 07:00:00, 600
        /// B, 07:00:00, 12:00:00, 1200
        /// </code>
        /// </example>
        [Required]
        public uint headway_secs { get; set; }

        /// <summary>
        /// The exact_times field determines if frequency-based trips should be exactly scheduled based on the specified headway information. 
        /// </summary>
        /// <example>
        /// Valid values for this field are:
        /// <list type="bullet">
        /// <item><term>0 or (empty)</term><description>Frequency-based trips are not exactly scheduled. This is the default behavior.</description></item>
        /// <item><term>1</term><description>Frequency-based trips are exactly scheduled. For a frequencies.txt row, trips are scheduled starting with<c>trip_start_time = start_time + x * headway_secs</c> for all <c>x</c> in <c>(0, 1, 2, ...)</c></description> where <c>trip_start_time &lt; end_time.</c></item>
        /// </list>
        /// The value of exact_times must be the same for all frequencies.txt rows with the same trip_id. If exact_times is 1 and a frequencies.txt row has a start_time equal to end_time, no trip must be scheduled. When exact_times is 1, care must be taken to choose an end_time value that is greater than the last desired trip start time but less than the last desired trip start time + headway_secs.
        /// </example>
        public ushort exact_times { get; set; }
    }
}
