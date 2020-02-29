using ImmutableObjectGraph.Generation;
using System;
using System.Collections.Immutable;
using System.Diagnostics;

namespace SomeBasicFileStoreApp.Core
{
    [GenerateImmutable(DefineWithMethodsPerProperty = true, GenerateBuilder = true)]
    public partial class Order
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly int id;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly int customer;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly DateTime orderDate;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly ImmutableList<Product> products;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        readonly int version;
    }
}
