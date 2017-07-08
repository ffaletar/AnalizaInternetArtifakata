using ArtifactsAnalyzer.Data;
using System;
using System.Collections.Generic;

namespace ArtifactsAnalyzer
{
    public interface IChromeArtifactsAnalyzer
    {
        List<Tuple<string, string>> readCache(string path);
        List<Tuple<string, string>> readCookies(string path);
        List<HistoryItem> readFile();
        List<Tuple<string, string>> readHostCookies(string path, string host);
    }
}