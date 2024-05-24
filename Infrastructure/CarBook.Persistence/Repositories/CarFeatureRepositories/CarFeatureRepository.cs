using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarFeatureRepositories
{
	public class CarFeatureRepository : ICarFeatureRepository
	{
		private readonly CarBookContext _context;
		public List<CarFeature> GetCarFeatureByCarID(int carID)
		{
			var values = _context.CarFeatures.Where(x => x.CarID == carID).ToList();
			return values;
		}
	}
}
