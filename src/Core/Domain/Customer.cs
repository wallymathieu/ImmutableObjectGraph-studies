using System.Diagnostics;

namespace SomeBasicFileStoreApp.Core
{
    public record Customer(int Id, string Firstname, string Lastname, int Version)
    {
    }
}
