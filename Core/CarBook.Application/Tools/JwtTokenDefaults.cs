using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Tools
{
	public class JwtTokenDefaults
	{
		public const string ValidAudience = "https://localhost";
		public const string ValidIssuer = "https://localhost";
		public const string Key = "carbookcarbook01/*-semi-h_1ds.xcs788$s11";
		public const int Expire = 3; // token'ın yasam süresinin 3 dakika oldugunu belirttik
	}
}
