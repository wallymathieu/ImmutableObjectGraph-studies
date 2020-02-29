using System.Collections.Generic;
using SomeBasicFileStoreApp.Core;
using SomeBasicFileStoreApp.Core.Commands;

namespace Commands
{
    public class AddProductToOrderCommandHandler : ICommandHandler<AddProductToOrder>
    {
        private readonly IRepository repository;

        public AddProductToOrderCommandHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(AddProductToOrder command)
        {
            var order = repository.GetOrder(command.OrderId);
            var products = new List<Product>(order.Products) { repository.GetProduct(command.ProductId) };
            repository.Save(order.With(products: products));
        }
    }
}
