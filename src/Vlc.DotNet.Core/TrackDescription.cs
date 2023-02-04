using System;
using System.Collections.Generic;
/* Unmerged change from project 'Vlc.DotNet.Core (netstandard2.0)'
Before:
using System.Text;
using Vlc.DotNet.Core.Interops;
After:
using System.Text;

using Vlc.DotNet.Core.Interops;
*/

/* Unmerged change from project 'Vlc.DotNet.Core (netstandard1.3)'
Before:
using System.Text;
using Vlc.DotNet.Core.Interops;
After:
using System.Text;

using Vlc.DotNet.Core.Interops;
*/

/* Unmerged change from project 'Vlc.DotNet.Core (net7.0)'
Before:
using System.Text;
using Vlc.DotNet.Core.Interops;
After:
using System.Text;

using Vlc.DotNet.Core.Interops;
*/


using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed class TrackDescription
    {
        public int ID { get; private set; }
        public string Name { get; private set; }

        internal TrackDescription(int id, string name)
        {
            ID = id;
            Name = name;
        }

        internal static List<TrackDescription> GetSubTrackDescription(IntPtr moduleRef)
        {
            var result = new List<TrackDescription>();
            if (moduleRef != IntPtr.Zero)
            {
                var module = MarshalHelper.PtrToStructure<TrackDescriptionStructure>(moduleRef);
                var name = Utf8InteropStringConverter.Utf8InteropToString(module.Name);
                result.Add(new TrackDescription(module.Id, name));
                var data = GetSubTrackDescription(module.NextTrackDescription);
                result.AddRange(data);
            }
            return result;
        }

    }
}
