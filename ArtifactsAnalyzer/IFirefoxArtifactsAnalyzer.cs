using ArtifactsAnalyzer.Data;
using System;
using System.Collections.Generic;

namespace ArtifactsAnalyzer
{
    public interface IFirefoxArtifactsAnalyzer
    {
        List<Tuple<string, string>> readCache(string path);
        List<HistoryItem> readFile();
    }
}