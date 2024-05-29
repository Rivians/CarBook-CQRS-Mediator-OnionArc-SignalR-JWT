using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand>
	{
		private readonly IRepository<Review> _repository;
		public UpdateReviewHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.CarID);

			value.ReviewDate = request.ReviewDate;
			value.CustomerName = request.CustomerName;
			value.CustomerImage = request.CustomerImage;
			value.CarID = request.CarID;
			value.RaytingValue = request.RaytingValue;
			value.Comment = request.Comment;
			
			await _repository.UpdateAsync(value);
		}
	}
}
