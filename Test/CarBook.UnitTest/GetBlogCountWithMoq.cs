using CarBook.Application.Features.Mediator.Handlers.StatisticHandlers;
using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.UnitTest
{
	public class GetBlogCountWithMoq
	{
		private Mock<IStatisticsRepository> _mockRepository;
		private GetBlogCountQueryHandler _handler;

		[SetUp]
		public void Setup()
		{
			_mockRepository = new Mock<IStatisticsRepository>();
			_handler = new GetBlogCountQueryHandler(_mockRepository.Object);
		}

		[Test]
		public async Task Handle_ShouldReturnCorrectBlogCountWithMoq()
		{
			// arrange
			int expectedBlogCount = 4;
			_mockRepository.Setup(repo => repo.GetBlogCount()).Returns(expectedBlogCount);

			var query = new GetBlogCountQuery();

			// action
			var result = await _handler.Handle(query, CancellationToken.None);

			// assert
			Assert.AreEqual(expectedBlogCount, result.BlogCount);
		}
	}
}
