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
        private EventCallback myOnMediaPlayerAudioDeviceInternalEventCallback;
        public event EventHandler<VlcMediaPlayerAudioDeviceEventArgs> AudioDevice;

        private void OnMediaPlayerAudioDeviceInternal(IntPtr ptr)
        {
            var args = MarshalHelper.PtrToStructure<VlcEventArg>(ptr);
            OnMediaPlayerAudioDevice(Utf8InteropStringConverter.Utf8InteropToString(args.eventArgsUnion.MediaPlayerAudioDevice.pszDevice));
        }

        public void OnMediaPlayerAudioDevice(string audioDevice)
        {
            AudioDevice?.Invoke(this, new VlcMediaPlayerAudioDeviceEventArgs(audioDevice));
        }
    }
}