using Commands;
using System;

namespace SomeBasicFileStoreApp.Core.Commands
{
    public class RepositoryCommandHandler:ICommandHandler<Command>
    {
        private readonly IRepository repository;
        private readonly AddCustomerCommandHandler addCustomerCommandHandler;
        private readonly AddOrderCommandHandler addOrderCommandHandler;
        private readonly AddProductCommandHandler addProductCommandHandler;
        private readonly AddProductToOrderCommandHandler addProductToOrderCommandHandler;

        public RepositoryCommandHandler(IRepository repository)
        {
            this.repository = repository;
            addCustomerCommandHandler = new AddCustomerCommandHandler(repository);
            addOrderCommandHandler = new AddOrderCommandHandler(repository);
            addProductCommandHandler = new AddProductCommandHandler(repository);
            addProductToOrderCommandHandler = new AddProductToOrderCommandHandler(repository);
        }

        public void Handle(Command command)
        {
            switch (command)
            {
                case AddCustomerCommand ac:
                    addCustomerCommandHandler.Handle(ac);
                    break;
                case AddOrderCommand ao:
                    addOrderCommandHandler.Handle(ao);
                    break;
                case AddProductCommand ap:
                    addProductCommandHandler.Handle(ap);
                    break;
                case AddProductToOrder apo:
                    addProductToOrderCommandHandler.Handle(apo);
                    break;
                default:
                    throw new Exception($"Unknown command {command.GetType().Name}");
            }
        }
    }
}

