using ImmutableObjectGraph.CodeGeneration;
using System.Collections.Generic;

namespace SomeBasicFileStoreApp.Core
{
    [GenerateImmutable]
    public partial class Customer
    {
        readonly int id;
        readonly string firstname;

        readonly string lastname;

        readonly int version;
    }
}
