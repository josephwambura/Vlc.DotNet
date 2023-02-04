using System;
/* Unmerged change from project 'Vlc.DotNet.Core.Interops (netstandard2.0)'
Before:
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;
After:
using System.Runtime.InteropServices;

using Vlc.DotNet.Core.Interops.Signatures;
*/

/* Unmerged change from project 'Vlc.DotNet.Core.Interops (netstandard1.3)'
Before:
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;
After:
using System.Runtime.InteropServices;

using Vlc.DotNet.Core.Interops.Signatures;
*/

/* Unmerged change from project 'Vlc.DotNet.Core.Interops (net7.0)'
Before:
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;
After:
using System.Runtime.InteropServices;

using Vlc.DotNet.Core.Interops.Signatures;
*/


using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public string GetMediaMrl(VlcMediaInstance mediaInstance)
        {
            if (mediaInstance == IntPtr.Zero)
                throw new ArgumentException("Media instance is not initialized.");
            var ptr = myLibraryLoader.GetInteropDelegate<GetMediaMrl>().Invoke(mediaInstance);
            return Utf8InteropStringConverter.Utf8InteropToString(ptr);
        }
    }
}
