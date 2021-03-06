﻿using System;
using System.Runtime.Serialization;

namespace CinemaSchedule.Common.Exceptions
{
	public class BusinessLogicValidationException : ApplicationException
	{
		public BusinessLogicValidationException()
		{

		}
		public BusinessLogicValidationException(String message) : base(message)
		{

		}
		public BusinessLogicValidationException(String message, Exception ex) : base(message)
		{

		}
		protected BusinessLogicValidationException(SerializationInfo info, StreamingContext contex) : base(info, contex)
		{

		}
	}
}