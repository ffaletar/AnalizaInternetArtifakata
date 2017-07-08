using System;
using System.Collections.Generic;

namespace ArtifactsAnalyzer
{
    public interface IInternetExplorerArtifactsAnalyzer
    {
        List<Tuple<string, string>> readCache(string path);
        List<Tuple<string, string>> readFile();
    }
}