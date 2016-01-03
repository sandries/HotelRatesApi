﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace HotelRatesApi
{
	using System.Net.Http.Headers;

	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services
			config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "HotelRatesApi",
				routeTemplate: "api/{controller}/{hotelId}/{arrivalDate}"
			);

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
