using ImmutableObjectGraph.CodeGeneration;

namespace SomeBasicFileStoreApp.Core
{
    [GenerateImmutable]
    public partial class Product
    {
        readonly int id;

        readonly float cost;

        readonly string name;

        readonly int version;
    }
}
