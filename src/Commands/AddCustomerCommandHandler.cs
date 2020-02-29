using System;
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
}
