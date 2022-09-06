using SomeBasicFileStoreApp.Core;
using SomeBasicFileStoreApp.Core.Commands;

namespace Commands
{
    public class AddProductCommandHandler: ICommandHandler<AddProductCommand>
    {
        private readonly IRepository repository;

        public AddProductCommandHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(AddProductCommand command)
        {
            repository.Save(new Product(command.Id, command.Cost, command.Name, command.Version));
        }
    }
}
