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
        private EventCallback myOnMediaPlayerScrambledChangedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerScrambledChangedEventArgs> ScrambledChanged;

        private void OnMediaPlayerScrambledChangedInternal(IntPtr ptr)
        {
            var args = MarshalHelper.PtrToStructure<VlcEventArg>(ptr);
            OnMediaPlayerScrambledChanged(args.eventArgsUnion.MediaPlayerScrambledChanged.NewScrambled);
        }

        public void OnMediaPlayerScrambledChanged(int newScrambled)
        {
            ScrambledChanged?.Invoke(this, new VlcMediaPlayerScrambledChangedEventArgs(newScrambled));
        }
    }
}