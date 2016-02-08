﻿using ProtoBuf;

namespace SomeBasicFileStoreApp.Core.Commands
{
    [ProtoContract]
    public class AddProductCommand : Command
    {
        [ProtoMember(1)]
        public virtual int Id { get; private set; }
        [ProtoMember(2)]
        public virtual int Version { get; private set; }
        [ProtoMember(3)]
        public virtual float Cost { get; private set; }
        [ProtoMember(4)]
        public virtual string Name { get; private set; }
    
        public override void Handle(IRepository _repository)
        {
            var command = this;
            _repository.Save(Product.Create(command.Id, command.Cost, command.Name, command.Version));
        }
    }
}
