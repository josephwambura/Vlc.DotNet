﻿using System;
/* Unmerged change from project 'Vlc.DotNet.Core.Interops (netstandard2.0)'
Before:
using System.IO;
using Vlc.DotNet.Core.Interops.Signatures;
After:
using System.IO;

using Vlc.DotNet.Core.Interops.Signatures;
*/

/* Unmerged change from project 'Vlc.DotNet.Core.Interops (netstandard1.3)'
Before:
using System.IO;
using Vlc.DotNet.Core.Interops.Signatures;
After:
using System.IO;

using Vlc.DotNet.Core.Interops.Signatures;
*/

/* Unmerged change from project 'Vlc.DotNet.Core.Interops (net7.0)'
Before:
using System.IO;
using Vlc.DotNet.Core.Interops.Signatures;
After:
using System.IO;

using Vlc.DotNet.Core.Interops.Signatures;
*/


using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public bool TakeSnapshot(VlcMediaPlayerInstance mediaPlayerInstance, uint outputNumber, string filePath, uint width, uint height)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));
            using (var filePathHandle = Utf8InteropStringConverter.ToUtf8StringHandle(filePath))
            {
                return myLibraryLoader.GetInteropDelegate<TakeSnapshot>().Invoke(mediaPlayerInstance, outputNumber, filePathHandle, width, height) == 0;
            }
        }
    }
}
