using System;

namespace CinemaSchedule.Services.Models.Exceptions
{
	public class BusinessException : Exception
	{
		public BusinessException()
		{

		}
		public BusinessException(String message) : base(message)
		{

		}
		public BusinessException(String message, Exception innerException) : base(message)
		{

		}
	}
}