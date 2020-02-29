using System.Collections.Immutable;
using SomeBasicFileStoreApp.Core;
using SomeBasicFileStoreApp.Core.Commands;

namespace Commands
{
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
}
