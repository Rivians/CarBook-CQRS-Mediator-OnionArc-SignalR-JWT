﻿using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarFeatureInterfaces
{
	public interface ICarFeatureRepository
	{
		List<CarFeature> GetCarFeatureByCarID(int carId);
		void ChangeCarFeatureAvailableToFalse(int id);
		void ChangeCarFeatureAvailableToTrue(int id);
	}
}