using System.Diagnostics;
using ImmutableObjectGraph.Generation;

namespace SomeBasicFileStoreApp.Core
{
    [GenerateImmutable(DefineWithMethodsPerProperty = true, GenerateBuilder = true)]
    public partial class Customer
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly int id;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly string firstname;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly string lastname;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly int version;
    }
}
