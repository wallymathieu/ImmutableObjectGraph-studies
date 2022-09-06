using NUnit.Framework;
using System.IO;
using System.Linq;
using SomeBasicFileStoreApp.Core.Infrastructure.ProtoBuf;
using System.Collections.Generic;
using WallyMathieu.Collections;

namespace SomeBasicFileStoreApp.Tests.ProtoBuf
{
    [TestFixture]
    public class PersistingEventsTests
    {
        private List<string> dbs = new List<string>();
        [TearDown]
        public void TearDown()
        {
            foreach (var db in dbs)
            {
                File.WriteAllText(db, string.Empty);
            }
        }
        private string AddDb(string db)
        {
            dbs.Add(db);
            return db;
        }
        [Test]
        public void Read_items_persisted_in_separate_batches()
        {
            var commands = new GetCommands().Get().ToArray();
            var _persist = new AppendToFile(AddDb("Proto_CustomerDataTests_1.db"));
            var batches = commands.BatchesOf(3).ToArray();
            // in order for the test to be valid
            Assert.That(batches.Length, Is.GreaterThan(2));
            foreach (var batch in batches)
            {
                _persist.Batch(batch);
            }
            Assert.That(_persist.ReadAll().Count(), Is.EqualTo(commands.Length));
        }

        [Test]
        public void Read_items_persisted_in_single_batch()
        {
            var commands = new GetCommands().Get().ToArray();
            var _persist = new AppendToFile(AddDb("Proto_CustomerDataTests_2.db"));
            _persist.Batch(commands);
            Assert.That(_persist.ReadAll().Count(), Is.EqualTo(commands.Length));
        }
    }
}