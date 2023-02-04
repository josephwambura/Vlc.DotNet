
/* Unmerged change from project 'Vlc.DotNet.Core (netstandard2.0)'
Before:
using System.Text;
using Vlc.DotNet.Core.Interops;
After:
using System.Text;

using Vlc.DotNet.Core.Interops;
*/

/* Unmerged change from project 'Vlc.DotNet.Core (netstandard1.3)'
Before:
using System.Text;
using Vlc.DotNet.Core.Interops;
After:
using System.Text;

using Vlc.DotNet.Core.Interops;
*/

/* Unmerged change from project 'Vlc.DotNet.Core (net7.0)'
Before:
using System.Text;
using Vlc.DotNet.Core.Interops;
After:
using System.Text;

using Vlc.DotNet.Core.Interops;
*/
namespace Vlc.DotNet.Core
{
    public interface ISubTitlesManagement : IEnumerableManagement<TrackDescription>
    {
        long Delay { get; set; }
    }

}
