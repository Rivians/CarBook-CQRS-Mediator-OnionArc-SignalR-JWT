using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarFeatureDtos
{
	public class CreateCarFeatureByCarIdDto
	{
        public int CarID { get; set; }
        public int FeatureID { get; set; }
        public string FeatureName { get; set; }
    }
}
