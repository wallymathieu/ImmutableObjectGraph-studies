using NUnit.Framework;
using SomeBasicFileStoreApp.Core;
using System.Linq;
using SomeBasicFileStoreApp.Core.Commands;
using WallyMathieu.Collections;

namespace SomeBasicFileStoreApp.Tests
{

    [TestFixture]
    public class PersistToDifferentThreadTests
    {
        private Command[][] _batches;
        private Command[] _commandsSent;
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            var container = new ObjectContainer();
            container.Boot();
            _commandsSent = new GetCommands().Get().ToArray();
            var handlers = container.GetAllHandlers();
            foreach (var command in _commandsSent)
            {
                foreach (dynamic handler in handlers.Where(h=>h.CanHandle(command.GetType())))
                {
                    handler.Handle(command);
                }
            }
            container.Dispose();
            _batches = container.BatchesPersisted().ToArray();
        }

        [Test]
        public void Will_send_all_commands_to_the_different_thread()
        {
            Assert.That(_batches.Count(), Is.LessThanOrEqualTo(_commandsSent.Count()));
            Assert.That(_batches.SelectMany(b=>b).Count(), Is.EqualTo(_commandsSent.Count()));
        }

        [Test]
        public void Order()
        {
            _batches.SelectMany(b => b).Pairwise((last, current) =>
                {
                    Assert.That(current.SequenceNumber,
                        Is.GreaterThan(last.SequenceNumber));
                    return 1;
                }).ToArray();
            //Console.WriteLine(string.Join(", ",
            //    _batches.Select(b => "["+string.Join(", ", b.Select(a => a.SequenceNumber)) +"]" )));
        }
    }
}
