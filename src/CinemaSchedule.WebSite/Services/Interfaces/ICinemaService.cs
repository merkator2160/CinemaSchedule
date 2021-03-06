﻿using CinemaSchedule.WebSite.Services.Models;
using CinemaSchedule.WebSite.Services.Models.ScheduleViewer;
using System;
using System.Threading.Tasks;

namespace CinemaSchedule.WebSite.Services.Interfaces
{
	public interface ICinemaService
	{
		Task<CinemaDto[]> GetAllCinemasAsync();
		Task<CinemaDto> GetCinemaAsync(String id);
		Task<MovieDto[]> GetAllMoviesAsync();
		Task<MovieDto> GetMovieAsync(String id);
		Task<MovieDto[]> GetMoviesByCinemaIdAsync(String cinemaId);
		ScheduleEditorDateDto[] CreateDatesForScheduleEditor(DateTime currentDate, Int32 datesAmount);
		Task<SessionDto[]> GetSessionsAsync(GetSessionsRequestDto request);
		Task RemoveObsoleteSessionsAsync(DateTime currentDate);
		Task DeleteSessionAsync(String id);
		Task<SessionWithCinemaAndMovieDto[]> GetAllSessionsWithCinemasAndMovies();
		Task<CinemaWithMovieDto[]> CreateSchedule();
	}
}