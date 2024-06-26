﻿using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WepApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarFeaturesController : ControllerBase
	{
		private readonly IMediator _mediator;
		public CarFeaturesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> CarFeatureListByCarId(int id)
		{
			var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
			return Ok(values);
		}

		[HttpGet("CarFeatureAvailableChangeToFalse")]
		public async Task<IActionResult> CarFeatureAvailableChangeToFalse(int id)
		{
			await _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
			return Ok("Güncelleme Yapıldı");
		}

		[HttpGet("CarFeatureAvailableChangeToTrue")]
		public async Task<IActionResult> CarFeatureAvailableChangeToTrue(int id)
		{
			await _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
			return Ok("Güncelleme Yapıldı");
		}

		[HttpPost]
		public async Task<IActionResult> CreateCarFeatureByCarID(CreateCarFeatureByCarCommand createCarFeatureByCarCommand)
		{
			await _mediator.Send(createCarFeatureByCarCommand);
			return Ok("Ekleme Yapıldı");
		}
	}
}
