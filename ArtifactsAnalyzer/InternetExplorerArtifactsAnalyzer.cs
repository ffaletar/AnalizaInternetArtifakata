using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using UrlHistoryLibrary;


namespace ArtifactsAnalyzer
{

    public class InternetExplorerArtifactsAnalyzer : IInternetExplorerArtifactsAnalyzer
    {

        public List<Tuple<string, string>> readFile()
        {
            List<Tuple<string, string>> lista = new List<Tuple<string, string>>();

            // Glavni objekt u koji se sprema povijest
            UrlHistoryWrapperClass urlhistory = new UrlHistoryWrapperClass();

            // Enumerator
            UrlHistoryWrapperClass.STATURLEnumerator enumerator = urlhistory.GetEnumerator();

            while (enumerator.MoveNext())
            {

                // Dohvaca url i naziv stranice            
                if (enumerator.Current.Title != null && enumerator.Current.URL != null)
                {

                    string url = enumerator.Current.URL.Replace('\'', ' ');
                    string title = enumerator.Current.Title.Replace('\'', ' ');

                    lista.Add(new Tuple<string, string>(url, title));

                }

            }

            return lista;
        }

        public List<Tuple<string, string>> readCache(string path)
        {
            //TODO napraviti učitavanje iz explorer cookie fajla

            return null;
        }

    }
    
}
