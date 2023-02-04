
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
        public string GetLastErrorMessage()
        {
            return Utf8InteropStringConverter.Utf8InteropToString(myLibraryLoader.GetInteropDelegate<GetLastErrorMessage>().Invoke());
        }
    }
}
