using System;

namespace CinemaSchedule.Services.Models.Exceptions
{
	public class RequestedObjectNotFoundException : BusinessException
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