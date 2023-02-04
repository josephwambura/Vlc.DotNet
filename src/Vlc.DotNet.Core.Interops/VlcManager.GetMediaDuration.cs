using System;
/* Unmerged change from project 'Vlc.DotNet.Core.Interops (netstandard2.0)'
Before:
using System.Text;
using Vlc.DotNet.Core.Interops.Signatures;
After:
using System.Text;

using Vlc.DotNet.Core.Interops.Signatures;
*/

/* Unmerged change from project 'Vlc.DotNet.Core.Interops (netstandard1.3)'
Before:
using System.Text;
using Vlc.DotNet.Core.Interops.Signatures;
After:
using System.Text;

using Vlc.DotNet.Core.Interops.Signatures;
*/

/* Unmerged change from project 'Vlc.DotNet.Core.Interops (net7.0)'
Before:
using System.Text;
using Vlc.DotNet.Core.Interops.Signatures;
After:
using System.Text;

using Vlc.DotNet.Core.Interops.Signatures;
*/


using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public long GetMediaDuration(VlcMediaInstance mediaInstance)
        {
            if (mediaInstance == IntPtr.Zero)
                throw new ArgumentException("Media instance is not initialized.");
            return myLibraryLoader.GetInteropDelegate<GetMediaDuration>().Invoke(mediaInstance);
        }
    }
}
