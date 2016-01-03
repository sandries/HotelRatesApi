namespace HotelRatesApi.Controllers
{
	using System;
	using System.Configuration;
	using System.IO;
	using System.Linq;
	using Newtonsoft.Json.Linq;
	using System.Web.Http;

	public class HotelRatesController : ApiController
	{
		[HttpGet]
		public object Get(int hotelId, string arrivalDate)
		{
			var jsonFile = JArray.Parse(File.ReadAllText(ConfigurationManager.AppSettings["jsonFile"]));

			dynamic result = new JObject();
			var item = jsonFile.OfType<dynamic>().FirstOrDefault(json => json.hotel.hotelID == hotelId);
			if (item != null)
			{
				result.hotel = item.hotel;
				DateTime arrivalDateTime;
				if (DateTime.TryParse(arrivalDate, out arrivalDateTime))
				{
					var rates = new JArray();
					foreach (var hotelRate in item.hotelRates)
					{
						DateTime dateTime;
						if (DateTime.TryParse(Convert.ToString(hotelRate.targetDay), out dateTime) && dateTime.Date.Equals(arrivalDateTime.Date))
						{
							rates.Add(hotelRate);
						}
					}
					result.hotelRates = rates;
				}
			}
		
			return result;
		}
	}
}
