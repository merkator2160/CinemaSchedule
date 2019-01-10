using CinemaSchedule.Services.Models;
using System;
using System.Collections.Generic;

namespace CinemaSchedule.Services.Interfaces
{
	public interface IFilmService
	{
		IReadOnlyCollection<FilmDto> GetAll();
		FilmDto Get(Int32 id);
		IReadOnlyCollection<FilmDto> GetByCinema(Int32 cinemaId);
	}
}