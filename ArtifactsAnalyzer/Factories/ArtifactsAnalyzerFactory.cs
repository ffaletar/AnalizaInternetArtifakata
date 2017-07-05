using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtifactsAnalyzer.Factories
{
    public class ArtifactsAnalyzerFactory
    {

        public static T Create<T>()
        {
            if (typeof(T) == typeof(IChromeArtifactsAnalyzer))
            {
                return (T)(IChromeArtifactsAnalyzer)new ChromeArtifactsAnalyzer();
            }
            else if (typeof(T) == typeof(IFirefoxArtifactsAnalyzer))
            {
                return (T)(IFirefoxArtifactsAnalyzer)new FirefoxArtifactsAnalyzer();
            }
            else if (typeof(T) == typeof(IInternetExplorerArtifactsAnalyzer))
            {
                return (T)(IInternetExplorerArtifactsAnalyzer)new InternetExplorerArtifactsAnalyzer();
            }
            else
            {
                return default(T);
            }
        }

    }
}
