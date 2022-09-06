using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Collections.Generic;
namespace SomeBasicFileStoreApp.Core
{
    public record Order(int Id, int Customer, DateTime OrderDate, IEnumerable<Product> Products,  int Version)
    {
    }
}
