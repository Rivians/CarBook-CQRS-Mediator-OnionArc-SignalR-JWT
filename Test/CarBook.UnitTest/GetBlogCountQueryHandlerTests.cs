using CarBook.Application.Features.Mediator.Handlers.BlogHandlers;
using CarBook.Application.Features.Mediator.Handlers.StatisticHandlers;
using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories.StatisticRepositories;
using Moq;

namespace CarBook.UnitTest
{
    public class GetBlogCountQueryHandlerTests
    {
		private GetBlogCountQueryHandler _handler;
		private IStatisticsRepository _repository;


		[SetUp]
		public void Setup()
		{
			_repository = new StatisticRepository(new CarBookContext());
			_handler = new GetBlogCountQueryHandler(_repository);
		}


		[Test]
		public async Task Handle_ShouldReturnCorrectBlogCount()
		{
			// arrange >> hazýrlýklarýn yapýldýgý kýsým
			int expectedBlogCounts = 4;

			// action >> iþlemlerin yapýldýgý kýsým 
			var query = new GetBlogCountQuery();
			var result = await _handler.Handle(query, CancellationToken.None);

			// assert >> son kýsýmda ise assert classýný kullanarak kontrol/test kýsmýný gerçekleþitiriyoruz
			Assert.AreEqual(expectedBlogCounts, result.BlogCount);

		}
	}
}