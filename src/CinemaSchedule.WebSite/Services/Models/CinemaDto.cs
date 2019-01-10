using MongoDB.Bson;
using System;

namespace CinemaSchedule.WebSite.Services.Models
{
	public class CinemaDto
	{
		public ObjectId Id { get; set; }
		public String Name { get; set; }
		public String City { get; set; }
		public String Country { get; set; }
	}
}