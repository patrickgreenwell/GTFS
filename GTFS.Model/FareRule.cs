using System.ComponentModel.DataAnnotations;

namespace GTFS.Model
{
    /// <summary>
    /// The fare_rules table allows you to specify how fares in <see cref="GTFS.Model.Feed.FareAttributes"/> apply to an itinerary. Most fare structures use some combination of the following rules:
    /// <list type="bullet">
    /// <item><description>Fare depends on origin or destination stations.</description></item>
    /// <item><description>Fare depends on which zones the itinerary passes through.</description></item>
    /// <item><description>Fare depends on which route the itinerary uses.</description></item>
    /// </list>
    /// For examples that demonstrate how to specify a fare structure with <see cref="GTFS.Model.FareRule"/> and <see cref="GTFS.Model.FareAttribute"/>, see <see cref="!:http://code.google.com/p/googletransitdatafeed/wiki/FareExamples" >FareExamples</see> in the GoogleTransitDataFeed open source project wiki.
    /// </summary>
    public class FareRule
    {
        /// <summary>
        /// The fare_id field contains an ID that uniquely identifies a fare class. This value is referenced from <see cref="GTFS.Model.Feed.FareAttributes"/>.
        /// </summary>
        [Required]
        public string fare_id { get; set; }
        
        /// <summary>
        /// The route_id field associates the fare ID with a route. Route IDs are referenced from <see cref="GTFS.Model.Route"/>. If you have several routes with the same fare attributes, create a row in <see cref="GTFS.Model.Feed.FareRules"/> for each route.
        /// </summary>
        /// <example>
        /// For example, if fare class "b" is valid on route "TSW" and "TSE", the <see cref="GTFS.Model.Feed.FareRules"/> would contain these rows for the fare class
        /// <code>
        /// b,TSW
        /// b,TSE       
        /// </code>
        /// </example>
        public string route_id { get; set; }

        /// <summary>
        /// The origin_id field associates the fare ID with an origin zone ID. Zone IDs are referenced from <see cref="GTFS.Model.Stop"/>. If you have several origin IDs with the same fare attributes, create a row in fare_rules.txt for each origin ID.
        /// </summary>
        /// <example>
        /// For example, if fare class "b" is valid for all travel originating from either zone "2" or zone "8", the fare_rules.txt file would contain these rows for the fare class:
        /// <code >
        /// b, , 2
        /// b, , 8
        /// </code></example>
        public string origin_id { get; set; }

        /// <summary>
        /// The destination_id field associates the fare ID with a destination zone ID. Zone IDs are referenced from the <see cref="GTFS.Model.Stop"/>. If you have several destination IDs with the same fare attributes, create a row in fare_rules.txt for each destination ID.
        /// </summary>
        /// <example>
        /// For example, you could use the origin_ID and destination_ID fields together to specify that fare class "b" is valid for travel between zones 3 and 4, and for travel between zones 3 and 5, the fare_rules.txt file would contain these rows for the fare class:
        /// <code>
        /// b, , 3,4
        /// b, , 3,5</code>
        /// </example>
        public string destination_id { get; set; }

        /// <summary>
        /// The contains_id field associates the fare ID with a zone ID, referenced from <see cref="GTFS.Model.Stop"/>. The fare ID is then associated with itineraries that pass through every contains_id zone.
        /// </summary>
        /// <example>
        /// For example, if fare class "c" is associated with all travel on the GRT route that passes through zones 5, 6, and 7 the fare_rules.txt would contain these rows:
        /// <code>
        /// c,GRT,,,5
        /// c,GRT,,,6
        /// c,GRT,,,7</code>
        /// Because all contains_id zones must be matched for the fare to apply, an itinerary that passes through zones 5 and 6 but not zone 7 would not have fare class "c". see <see cref="!:http://code.google.com/p/googletransitdatafeed/wiki/FareExamples" >FareExamples</see> in the GoogleTransitDataFeed open source project wiki.
        /// </example>
        public string contains_id { get; set; }
    }
}
