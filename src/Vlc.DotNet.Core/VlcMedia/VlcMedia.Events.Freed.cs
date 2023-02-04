using System;
/* Unmerged change from project 'Vlc.DotNet.Core (netstandard2.0)'
Before:
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;
After:
using System.Runtime.InteropServices;

using Vlc.DotNet.Core.Interops.Signatures;
*/

/* Unmerged change from project 'Vlc.DotNet.Core (netstandard1.3)'
Before:
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;
After:
using System.Runtime.InteropServices;

using Vlc.DotNet.Core.Interops.Signatures;
*/

/* Unmerged change from project 'Vlc.DotNet.Core (net7.0)'
Before:
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;
After:
using System.Runtime.InteropServices;

using Vlc.DotNet.Core.Interops.Signatures;
*/


using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public partial class VlcMedia
    {
        private EventCallback myOnMediaFreedInternalEventCallback;
        public event EventHandler<VlcMediaFreedEventArgs> Freed;

        private void OnMediaFreedInternal(IntPtr ptr)
        {
            OnMediaFreed();
        }

        public void OnMediaFreed()
        {
            Freed?.Invoke(this, new VlcMediaFreedEventArgs());
        }
    }
}