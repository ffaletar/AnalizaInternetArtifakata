using ArtifactsAnalyzer.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtifactsAnalyzer
{
    public class FirefoxArtifactsAnalyzer : IFirefoxArtifactsAnalyzer
    {
        public List<HistoryItem> URLs { get; set; }
        public List<HistoryItem> readFile()
        {

            string documentsFolder = Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData) + @"\Mozilla\Firefox\Profiles\";

            URLs = new List<HistoryItem>();
            if (Directory.Exists(documentsFolder))
            {
                foreach (string folder in Directory.GetDirectories (documentsFolder))
                {
                    return ExtractUserHistory(folder);
                }
            }

            return null;
        }




        public List<Tuple<string, string>> readCache(string path)
        {
            //TODO napraviti učitavanje iz firefox cookie fajla

            return null;
        }


        List<HistoryItem> ExtractUserHistory(string folder)
        {
            DataTable historyDT = ExtractFromTable("moz_places", folder);
            DataTable visitsDT = ExtractFromTable("moz_historyvisits", folder);


            foreach (DataRow row in historyDT.Rows)
            {
                var entryDate = (from dates in visitsDT.AsEnumerable()
                                 where dates["place_id"].ToString() == row["id"].ToString()
                                 select dates).LastOrDefault();

                if (entryDate != null)
                {
                    string url = row["Url"].ToString();
                    string title = row["title"].ToString();

                    long a = (long)entryDate.ItemArray.GetValue(3);
                    long b = a / 1000;
                    
                    DateTime localTime = new DateTime(b);
                    
                    long beginTicks = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;

                    DateTime dt = new DateTime(beginTicks + b * 10000, DateTimeKind.Utc);


                    HistoryItem historyItem = new HistoryItem()
                    {
                        URL = Convert.ToString(url.Replace('\'', ' ')),
                        Title = Convert.ToString(title.Replace('\'', ' ')),
                        VisitedTime = dt
                    };
                    
                    URLs.Add(historyItem);
                }
            }


            return URLs;
        }



        DataTable ExtractFromTable(string table, string folder)
        {
            SQLiteConnection sql_con;
            SQLiteCommand sql_cmd;
            SQLiteDataAdapter DB;
            DataTable DT = new DataTable();

            string dbPath = folder + "\\places.sqlite";

            
            if (File.Exists(dbPath))
            {
                sql_con = new SQLiteConnection("Data Source=" + dbPath +  ";Version=3;New=False;Compress=True;");
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();
                
                string CommandText = "select * from " + table;
                DB = new SQLiteDataAdapter(CommandText, sql_con);
                DB.Fill(DT);
                sql_con.Close();
            }
            return DT;
        }

    }
}
