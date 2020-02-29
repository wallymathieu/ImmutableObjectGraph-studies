using ProtoBuf;
using System.Collections.Generic;

namespace SomeBasicFileStoreApp.Core.Commands
{
    [ProtoContract]
    public class AddProductToOrder : Command
    {
        [ProtoMember(1)]
        public int OrderId { get; set; }
        [ProtoMember(2)]
        public int ProductId { get; set; }

    }
}
