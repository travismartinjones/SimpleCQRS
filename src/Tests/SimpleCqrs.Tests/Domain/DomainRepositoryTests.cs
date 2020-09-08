using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SimpleCqrs.Domain;
using SimpleCqrs.Eventing;

namespace SimpleCqrs.Core.Tests.Domain
{
    [TestClass]
    public class DomainRepositoryTests
    {
        private AutoMoqer mocker;

        [TestInitialize]
        public void SetupMocksForAllTests()
        {
            mocker = new AutoMoqer();
        }

        [TestMethod]
        public async Task EventsAreRetrievedFromTheEventStoreAndAppliedToTheAggregateRootWhenGetByIdIsCalled()
        {
            var repository = CreateDomainRepository();
            var aggregateRootId = new Guid();
            var domainEvents = new List<MyTestEvent> {new MyTestEvent(), new MyTestEvent(), new MyTestEvent()};

            mocker.GetMock<IEventStore>()
                .Setup(eventStore => eventStore.GetEvents(aggregateRootId, 0))
                .Returns(async () => domainEvents);

            var aggregateRoot = await repository.GetById<MyTestAggregateRoot>(aggregateRootId).ConfigureAwait(false);

            Assert.AreEqual(3, aggregateRoot.MyTestEventHandleCount);
        }

        //[TestMethod]
        //public async Task UncommittedEventsArePublishedToTheEventBusWhenSaved()
        //{
        //    var repository = CreateDomainRepository();
        //    var aggregateRoot = new MyTestAggregateRoot();
        //    var domainEvents = new List<DomainEvent> {new MyTestEvent(), new MyTestEvent(), new MyTestEvent()};

        //    aggregateRoot.Apply(domainEvents[0]);
        //    aggregateRoot.Apply(domainEvents[1]);
        //    aggregateRoot.Apply(domainEvents[2]);

        //    await repository.Save(aggregateRoot).ConfigureAwait(false);

        //    mocker.GetMock<IEventBus>()
        //        .Verify(async eventBus => await eventBus.PublishEvents(It.IsAny<IEnumerable<DomainEvent>>()), Times.Once());
        //}

        [TestMethod]
        public async Task UncommittedEventsShouldBeCommited()
        {
            var repository = CreateDomainRepository();
            var aggregateRoot = new MyTestAggregateRoot();

            aggregateRoot.Apply(new MyTestEvent());
            aggregateRoot.Apply(new MyTestEvent());

            await repository.Save(aggregateRoot).ConfigureAwait(false);

            Assert.AreEqual(0, aggregateRoot.UncommittedEvents.Count);
        }

		[TestMethod]
		public async Task GettingExistingByIdThrowsExceptionWhenNotFound()
		{
			var eventStore = new Mock<IEventStore>().Object;
			var snapshotStore = new Mock<ISnapshotStore>().Object;
			var eventBus = new Mock<IEventBus>().Object;
            var durableEventService = new Mock<IDurableEventService>().Object;
			var repository = new DomainRepository(eventStore, snapshotStore, eventBus, durableEventService);
			var aggregateRootId = Guid.NewGuid();

			var exception = await CustomAsserts.ThrowsAsync<AggregateRootNotFoundException>(
                repository.GetExistingById<MyTestAggregateRoot>(aggregateRootId)
            ).ConfigureAwait(false);

			Assert.AreEqual(aggregateRootId, exception.AggregateRootId);
			Assert.AreEqual(typeof(MyTestAggregateRoot), exception.Type);
		}

		[TestMethod]
		public void GettingExistingByIdReturnsAggregateWhenFound()
		{
			var aggregateRootId = Guid.NewGuid();

			var eventStore = new Mock<IEventStore>();
			eventStore.Setup(x => x.GetEvents(aggregateRootId, It.IsAny<int>())).Returns(async () => new[] { new MyTestEvent() });
			var snapshotStore = new Mock<ISnapshotStore>().Object;
			var eventBus = new Mock<IEventBus>().Object;
            var durableEventService = new Mock<IDurableEventService>().Object;
			var repository = new DomainRepository(eventStore.Object, snapshotStore, eventBus, durableEventService);

			var fetchedAggregateRoot = repository.GetExistingById<MyTestAggregateRoot>(aggregateRootId);

			Assert.IsNotNull(fetchedAggregateRoot);
		}

        private DomainRepository CreateDomainRepository()
        {
            return mocker.Resolve<DomainRepository>();
        }

        public class MyTestAggregateRoot : AggregateRoot
        {
            public int MyTestEventHandleCount { get; set; }
            public List<int> EventIds { get; set; }

            public MyTestAggregateRoot()
            {
                EventIds = new List<int>();
            }

        	private void OnMyTest(MyTestEvent myTestEvent)
            {
                MyTestEventHandleCount++;
                EventIds.Add(myTestEvent.Sequence);
            }
        }

        public class MyTestEvent : DomainEvent
        {
        }
    }
}