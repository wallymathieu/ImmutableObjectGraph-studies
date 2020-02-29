using System;
using System.Collections.Immutable;
using SomeBasicFileStoreApp.Core;
using SomeBasicFileStoreApp.Core.Commands;

namespace Commands
{
    public class AddCustomerCommandHandler : ICommandHandler<AddCustomerCommand>
    {
        private readonly IRepository repository;

        public AddCustomerCommandHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(AddCustomerCommand command)
        {
            repository.Save(Customer.Create(command.Id, command.Firstname, command.Lastname, command.Version));
        }
    }
    public class AddOrderCommandHandler : ICommandHandler<AddOrderCommand>
    {
        private readonly IRepository repository;

        public AddOrderCommandHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(AddOrderCommand command)
        {
            repository.Save(Order.Create(command.Id, command.Customer, command.OrderDate, ImmutableList<Product>.Empty, command.Version));
        }
    }
    public class AddProductCommandHandler: ICommandHandler<AddProductCommand>
    {
        private readonly IRepository repository;

        public AddProductCommandHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(AddProductCommand command)
        {
            repository.Save(Product.Create(command.Id, command.Cost, command.Name, command.Version));
        }
    }
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
            var products = order.Products.Add(repository.GetProduct(command.ProductId));
            repository.Save(order.With(products: products));
        }
    }
}
