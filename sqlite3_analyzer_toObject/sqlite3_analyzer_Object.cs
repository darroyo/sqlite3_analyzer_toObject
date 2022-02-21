using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace sqlite3_analyzer_toObject
{
    public class sqlite3_analyzer_Object
    {
        public sqlite3_analyzer_Database DataBase { get; set; }
        public List<sqlite3_analyzer_Table> Tables { get; set; }

        public sqlite3_analyzer_Object()
        {

        }

        public sqlite3_analyzer_Object(string sqlite3_analyzer_Output)
        {
            DataBase = get_Database(sqlite3_analyzer_Output);
            Tables = get_Tables(sqlite3_analyzer_Output);
        }

        private sqlite3_analyzer_Database get_Database(string sqlite3_analyzer_Output)
        {
            sqlite3_analyzer_Database ret = new sqlite3_analyzer_Database();
            string pattern = @"(Size of the file in bytes)([. ]+)([0-9]+)";

            Regex regex = new Regex(pattern, RegexOptions.Singleline);
            Match match = regex.Match(sqlite3_analyzer_Output);

            if (match.Success && match.Groups.Count == 4)
            {
                long SizeBytes = 0;
                long.TryParse(match.Groups[3].Value, out SizeBytes);

                ret.SizeBytes = SizeBytes;
            }

            return ret;
        }

        private List<sqlite3_analyzer_Table> get_Tables(string sqlite3_analyzer_Output)
        {
            List<sqlite3_analyzer_Table> ret = new List<sqlite3_analyzer_Table>();
            string pattern = @"(Page counts for all tables with their indices)(.+)(Page counts for all tables and indices separately)";

            Regex regex = new Regex(pattern, RegexOptions.Singleline);
            Match match = regex.Match(sqlite3_analyzer_Output);

            if (match.Success && match.Groups.Count == 4)
            {
                string lines = match.Groups[2].Value;

                string pattern2 = @"(\w+)(\.+)( [0-9]+)( )+([0-9]+\.*[0-9]*)(%)";

                Regex regex2 = new Regex(pattern2, RegexOptions.Singleline);

                foreach (Match match2 in regex2.Matches(lines))
                {
                    if (match2.Success && match2.Groups.Count == 7)
                    {
                        string tableName = match2.Groups[1].Value;
                        double tablePercentaje = 0;
                        double.TryParse(match2.Groups[5].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out tablePercentaje);
                        ret.Add(new sqlite3_analyzer_Table { 
                            Name = tableName,
                            Percentaje = tablePercentaje
                        });
                    }
                }
            }

            return ret;
        }

    }    
}
