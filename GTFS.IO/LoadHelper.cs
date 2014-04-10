using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using System.IO.Compression;

using GTFS.Model;

namespace GTFS.IO
{
    public class LoadHelper
    {
        public Feed LoadZip(string filename)
        {
            using (ZipArchive za = ZipFile.OpenRead(filename))
            {
                return LoadZip(za);
            }
        }

        public static Feed LoadZip(ZipArchive archive)
        {

            Dictionary<string, Type> mapping = new Dictionary<string, Type>()
            {
                {"agency.txt"    ,      typeof(Agency)},
                {"stops.txt"    ,       typeof(Stop)},
                {"routes.txt"    ,      typeof(Route)},
                {"trips.txt"    ,       typeof(Trip)},
                {"stop_times.txt"    ,  typeof(StopTime)},
                {"calendar.txt"    ,    typeof(Calendar)},
                {"calendar_dates.txt",  typeof(CalendarDate)},
                {"fare_attributes.txt", typeof(FareAttribute)},
                {"fare_rules.txt"    ,  typeof(FareRule)},
                {"shapes.txt"    ,      typeof(Shape)},
                {"frequencies.txt"    , typeof(Frequency)},
                {"transfers.txt"    ,   typeof(Transfer)},
                {"feed_info.txt"    ,   typeof(FeedInfo)}
            };
            Feed feed = new Feed();
            Parallel.ForEach(mapping, map =>
                {
                    LoadFiles(archive, feed, map);
                });
            return feed;
        }

        private static void LoadFiles(ZipArchive archive, Feed feed, KeyValuePair<string, Type> map)
        {
            ZipArchiveEntry entry = archive.GetEntry(map.Key);
            using (Stream stream = entry.Open())
            {
                using (TextReader tr = new StreamReader(stream))
                {
                    LoadCsvFile(feed, map, tr);
                }
            }
            
        }

        private static void LoadCsvFile(Feed feed, KeyValuePair<string, Type> map, TextReader tr)
        {
            using (CsvReader reader = new CsvReader(tr))
            {
                SetFeed(feed, reader.GetRecords(map.Value).ToList(), map.Value);
            }
        }

        private static void SetFeed(Feed feed, IEnumerable<object> enumerable, Type mappedType)
        {
            switch (mappedType.Name)
            {
                case "Agency":
                    feed.Agency.AddRange((IEnumerable<Agency>)enumerable);
                    break;
                case "Stop":
                    feed.Stops.AddRange((IEnumerable<Stop>)enumerable);
                    break;
                case "Route":
                    feed.Routes.AddRange((IEnumerable<Route>)enumerable);
                    break;
                case "Trip":
                    feed.Trips.AddRange((IEnumerable<Trip>)enumerable);
                    break;
                case "StopTime":
                    feed.StopTimes.AddRange((IEnumerable<StopTime>)enumerable);
                    break;
                case "Calendar":
                    feed.Calendar.AddRange((IEnumerable<Calendar>)enumerable);
                    break;
                case "CalendarDate":
                    feed.CalendarDates.AddRange((IEnumerable<CalendarDate>)enumerable);
                    break;
                case "FareAttribute":
                    feed.FareAttributes.AddRange((IEnumerable<FareAttribute>)enumerable);
                    break;
                case "FareRule":
                    feed.FareRules.AddRange((IEnumerable<FareRule>)enumerable);
                    break;
                case "Shape":
                    feed.Shapes.AddRange((IEnumerable<Shape>)enumerable);
                    break;
                case "Frequency":
                    feed.Frequencies.AddRange((IEnumerable<Frequency>)enumerable);
                    break;
                case "Transfer":
                    feed.Transfers.AddRange((IEnumerable<Transfer>)enumerable);
                    break;
                case "FeedInfo":
                    feed.FeedInfo.AddRange((IEnumerable<FeedInfo>)enumerable);
                    break;
            }
        }
    }
}
