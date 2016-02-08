using ImmutableObjectGraph.CodeGeneration;
using System;
using System.Collections.Immutable;

namespace SomeBasicFileStoreApp.Core
{
    [GenerateImmutable]
    public partial class Order
    {
        readonly int id;

        readonly int customer;

        readonly DateTime orderDate;

        readonly ImmutableList<Product> products;

        readonly int version;
    }
}
