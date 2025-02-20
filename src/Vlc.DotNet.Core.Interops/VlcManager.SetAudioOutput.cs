﻿
/* Unmerged change from project 'Vlc.DotNet.Core.Interops (netstandard2.0)'
Before:
using System;
using Vlc.DotNet.Core.Interops.Signatures;
After:
using System;

using Vlc.DotNet.Core.Interops.Signatures;
*/

/* Unmerged change from project 'Vlc.DotNet.Core.Interops (netstandard1.3)'
Before:
using System;
using Vlc.DotNet.Core.Interops.Signatures;
After:
using System;

using Vlc.DotNet.Core.Interops.Signatures;
*/

/* Unmerged change from project 'Vlc.DotNet.Core.Interops (net7.0)'
Before:
using System;
using Vlc.DotNet.Core.Interops.Signatures;
After:
using System;

using Vlc.DotNet.Core.Interops.Signatures;
*/
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public int SetAudioOutput(VlcMediaPlayerInstance mediaPlayerInstance, AudioOutputDescriptionStructure output)
        {
            return SetAudioOutput(mediaPlayerInstance, output.Name);
        }

        public int SetAudioOutput(VlcMediaPlayerInstance mediaPlayerInstance, string outputName)
        {
            using (var outputInterop = Utf8InteropStringConverter.ToUtf8StringHandle(outputName))
            {
                return myLibraryLoader.GetInteropDelegate<SetAudioOutput>().Invoke(mediaPlayerInstance, outputInterop);
            }
        }
    }
}
