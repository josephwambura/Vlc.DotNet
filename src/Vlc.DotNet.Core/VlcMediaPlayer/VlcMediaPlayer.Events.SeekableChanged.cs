using System;
/* Unmerged change from project 'Vlc.DotNet.Core (netstandard2.0)'
Before:
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops;
After:
using System.Runtime.InteropServices;

using Vlc.DotNet.Core.Interops;
*/

/* Unmerged change from project 'Vlc.DotNet.Core (netstandard1.3)'
Before:
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops;
After:
using System.Runtime.InteropServices;

using Vlc.DotNet.Core.Interops;
*/

/* Unmerged change from project 'Vlc.DotNet.Core (net7.0)'
Before:
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops;
After:
using System.Runtime.InteropServices;

using Vlc.DotNet.Core.Interops;
*/


using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerSeekableChangedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerSeekableChangedEventArgs> SeekableChanged;

        private void OnMediaPlayerSeekableChangedInternal(IntPtr ptr)
        {
            var args = MarshalHelper.PtrToStructure<VlcEventArg>(ptr);
            OnMediaPlayerSeekableChanged(args.eventArgsUnion.MediaPlayerSeekableChanged.NewSeekable);
        }

        public void OnMediaPlayerSeekableChanged(int newSeekable)
        {
            SeekableChanged?.Invoke(this, new VlcMediaPlayerSeekableChangedEventArgs(newSeekable));
        }
    }
}