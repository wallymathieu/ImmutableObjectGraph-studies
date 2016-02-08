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

        public override void Handle(IRepository _repository)
        {
            var command = this;
            var order = _repository.GetOrder(command.OrderId);
            var products = order.Products.Add(_repository.GetProduct(command.ProductId));
            _repository.Save(order.With(products:products));
        }
    }
}
