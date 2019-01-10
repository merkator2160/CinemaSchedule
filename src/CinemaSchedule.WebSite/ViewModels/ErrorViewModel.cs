using System;

namespace CinemaSchedule.WebSite.ViewModels
{
	public class ErrorViewModel
	{
		public String RequestId { get; set; }

		public Boolean ShowRequestId => !string.IsNullOrEmpty(RequestId);
	}
}