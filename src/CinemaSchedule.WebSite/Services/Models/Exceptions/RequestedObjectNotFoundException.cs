using System;

namespace CinemaSchedule.WebSite.Services.Models.Exceptions
{
	public class RequestedObjectNotFoundException : ApplicationException
	{
		public RequestedObjectNotFoundException()
		{

		}
		public RequestedObjectNotFoundException(String message) : base(message)
		{

		}
		public RequestedObjectNotFoundException(String message, Exception innerException) : base(message, innerException)
		{

		}
	}
}