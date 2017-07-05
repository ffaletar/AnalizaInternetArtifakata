using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtifactsAnalyzer
{
    public class InternetExplorerArtifactsAnalyzer : IInternetExplorerArtifactsAnalyzer
    {

        public List<Tuple<string, string>> readFile(string path)
        {
            //TODO napraviti učitavanje iz explorera cookie fajla

            return null;
        }

        public List<Tuple<string, string>> readCache(string path)
        {
            //TODO napraviti učitavanje iz explorer cookie fajla

            return null;
        }

    }
}
