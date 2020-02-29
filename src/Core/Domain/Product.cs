using System.Diagnostics;
using ImmutableObjectGraph.Generation;

namespace SomeBasicFileStoreApp.Core
{
    [GenerateImmutable(DefineWithMethodsPerProperty = true, GenerateBuilder = true)]
    public partial class Product
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly int id;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly float cost;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly string name;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly int version;
    }
}
