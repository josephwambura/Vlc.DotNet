﻿using System;
using System.Collections.Generic;
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
        public IEnumerable<AudioOutputDevice> GetAudioOutputDeviceList(string outputName)
        {
            using (var outputNameHandle = Utf8InteropStringConverter.ToUtf8StringHandle(outputName))
            {
                var deviceList = myLibraryLoader.GetInteropDelegate<GetAudioOutputDeviceList>().Invoke(this.myVlcInstance, outputNameHandle);
                try
                {
                    var result = new List<AudioOutputDevice>();
                    var currentPointer = deviceList;
                    while (currentPointer != IntPtr.Zero)
                    {
                        var current = MarshalHelper.PtrToStructure<LibvlcAudioOutputDeviceT>(currentPointer);
                        result.Add(new AudioOutputDevice
                        {
                            DeviceIdentifier = Utf8InteropStringConverter.Utf8InteropToString(current.DeviceIdentifier),
                            Description = Utf8InteropStringConverter.Utf8InteropToString(current.Description)
                        });
                        currentPointer = current.Next;
                    }

                    return result;
                }
                finally
                {
                    myLibraryLoader.GetInteropDelegate<ReleaseAudioOutputDeviceList>().Invoke(deviceList);
                }
            }
        }
    }
}
