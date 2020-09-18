using DangerTapeAPI.Database.Entities;
using DangerTapeAPI.Database.Repository;
using DangerTapeAPI.Mediators.Queries;
using FluentAssertions;
using MockQueryable.NSubstitute;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DangerTapeAPI.Tests.Cqrs.Queries
{
    [TestFixture]
    public class GetAllModesHandlerTests
    {
        private IRepository<Mode> _repository;
        private GetAllModesHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _repository = Substitute.For<IRepository<Mode>>();
            _handler = new GetAllModesHandler(_repository);
        }

        [TestCaseSource(nameof(TestData))]
        public async Task Handler_RetrievesAllModes(List<Mode> modesInDB)
        {
            var mock = modesInDB.AsQueryable().BuildMock();
            _repository.GetAll().Returns(mock);

            var result = await _handler.Handle(new GetAllModesRequest(), CancellationToken.None);

            _repository.Received(1).GetAll();

            result.Should().BeEquivalentTo(modesInDB);
        }

        protected static IEnumerable<List<Mode>> TestData
        {
            get
            {
                yield return new List<Mode>
                {
                    new Mode
                    {
                        Id = 1,
                        Name = "Mode 1"
                    },
                    new Mode
                    {
                        Id = 2,
                        Name = "Mode 2"
                    },
                    new Mode
                    {
                        Id = 3,
                        Name = "Mode 3"
                    },
                };
            }
        }
    }
}