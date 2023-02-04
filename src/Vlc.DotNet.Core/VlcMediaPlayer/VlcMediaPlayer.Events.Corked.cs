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
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerCorkedInternalEventCallback;
        public event EventHandler Corked;

        private void OnMediaPlayerCorkedInternal(IntPtr ptr)
        {
            OnMediaPlayerCorked();
        }

        public void OnMediaPlayerCorked()
        {
            Corked?.Invoke(this, new EventArgs());
        }
    }
}