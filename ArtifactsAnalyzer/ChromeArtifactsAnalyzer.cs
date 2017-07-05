using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ArtifactsAnalyzer
{
    public class ChromeArtifactsAnalyzer : IChromeArtifactsAnalyzer
    { 
        

        public List<Tuple<string, string>> readCookies(string path)
        {
            //Ovo je samo hardkodiran path, trebao bi ga primati kao parametar
            path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Google\Chrome\User Data\Default\Cookies";
            List<Tuple<string, string>> list = new List<Tuple<string,string>>();
            if (System.IO.File.Exists(path))
            {
                var connectionString = "Data Source=" + path + ";pooling=false";


                using (var conn = new System.Data.SQLite.SQLiteConnection(connectionString))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT name,encrypted_value FROM cookies";

                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var encryptedData = (byte[])reader[1];
                                var decodedData = System.Security.Cryptography.ProtectedData.Unprotect(encryptedData, null, System.Security.Cryptography.DataProtectionScope.CurrentUser);
                                var plainText = Encoding.ASCII.GetString(decodedData);
                                

                                Debug.WriteLine(reader.GetString(0) + " - " + plainText);

                                list.Add(Tuple.Create(reader.GetString(0), plainText));
                            }
                        }
                        cmd.Dispose();
                        conn.Close();

                        return list;
                    }
                }

            }
            else
            {
                return null;
            }

        }

        public List<Tuple<string, string>> readHostCookies(string path, string host)
        {
            //Ovo je samo hardkodiran path, trebao bi ga primati kao parametar
            path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Google\Chrome\User Data\Default\Cookies";
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            if (System.IO.File.Exists(path) && host != null && host != "")
            {
                var connectionString = "Data Source=" + path + ";pooling=false";


                using (var conn = new System.Data.SQLite.SQLiteConnection(connectionString))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        var prm = cmd.CreateParameter();
                        prm.ParameterName = "hostName";
                        prm.Value = host;
                        cmd.Parameters.Add(prm);

                        cmd.CommandText = "SELECT name,encrypted_value FROM cookies WHERE host_key = @hostName";

                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var encryptedData = (byte[])reader[1];
                                var decodedData = System.Security.Cryptography.ProtectedData.Unprotect(encryptedData, null, System.Security.Cryptography.DataProtectionScope.CurrentUser);
                                var plainText = Encoding.ASCII.GetString(decodedData);
                                Debug.WriteLine(reader.GetString(0) + " - " + plainText);

                                list.Add(Tuple.Create(reader.GetString(0), plainText));
                            }
                        }
                        cmd.Dispose();
                        conn.Close();

                        return list;
                    }
                }

            }
            else
            {
                return null;
            }

        }


        public List<Tuple<string, string>> readCache(string path)
        {

            //TODO napraviti čitanje chrome Cache fajla

            return null;

        }



    }
}
