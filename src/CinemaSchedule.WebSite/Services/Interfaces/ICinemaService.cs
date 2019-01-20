using CinemaSchedule.WebSite.Services.Models;
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
		ScheduleEditorDateDto[] CreateDatesForScheduleEditor();
		Task<SessionDto[]> GetSessionsAsync(GetSessionsRequestDto request);
	}
}