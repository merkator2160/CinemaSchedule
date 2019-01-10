using CinemaSchedule.Services.Models;
using System;
using System.Collections.Generic;

namespace CinemaSchedule.Services.Interfaces
{
	public interface ICinemaService
	{
		IReadOnlyCollection<CinemaDto> GetAll();
		CinemaDto Get(Int32 id);
	}
}