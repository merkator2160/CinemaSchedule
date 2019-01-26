using AutoMapper;
using CinemaSchedule.Database.Interfaces;
using CinemaSchedule.Database.Models.Filters;
using CinemaSchedule.WebSite.Services.Interfaces;
using CinemaSchedule.WebSite.Services.Models;
using CinemaSchedule.WebSite.Services.Models.Exceptions;
using CinemaSchedule.WebSite.Services.Models.ScheduleViewer;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaSchedule.WebSite.Services
{
	internal sealed class CinemaService : ICinemaService
	{
		private readonly IMapper _mapper;
		private readonly IRepositoryBundle _repositoryBundle;


		public CinemaService(IRepositoryBundle repositoryBundle, IMapper mapper)
		{
			_mapper = mapper;
			_repositoryBundle = repositoryBundle;
		}


		// ICinemaService /////////////////////////////////////////////////////////////////
		public async Task<CinemaDto[]> GetAllCinemasAsync()
		{
			return _mapper.Map<CinemaDto[]>(await _repositoryBundle.Cinemas.GetAllAsync());
		}
		public async Task<CinemaDto> GetCinemaAsync(String id)
		{
			var cinemaDb = await _repositoryBundle.Cinemas.GetAsync(id);
			if(cinemaDb == null)
				throw new RequestedObjectNotFoundException($"Cinema with id = {id} not found!");

			return _mapper.Map<CinemaDto>(cinemaDb);
		}
		public async Task<MovieDto[]> GetAllMoviesAsync()
		{
			return _mapper.Map<MovieDto[]>(await _repositoryBundle.Movies.GetAllAsync());
		}
		public async Task<MovieDto> GetMovieAsync(String id)
		{
			var movieDb = await _repositoryBundle.Movies.GetAsync(id);
			if(movieDb == null)
				throw new RequestedObjectNotFoundException($"Movie with id = {id} not found!");

			return _mapper.Map<MovieDto>(movieDb);
		}
		public async Task<MovieDto[]> GetMoviesByCinemaIdAsync(String cinemaId)
		{
			return _mapper.Map<MovieDto[]>(await _repositoryBundle.Movies.GetByCinemaId(cinemaId));
		}
		public ScheduleEditorDateDto[] CreateDatesForScheduleEditor(DateTime currentDate, Int32 datesAmount)
		{
			currentDate = currentDate.AddDays(1);   // Schedule can be edited only for the next day
			var dateList = new List<ScheduleEditorDateDto>(datesAmount);

			for(var i = 0; i < datesAmount; i++)
			{
				dateList.Add(new ScheduleEditorDateDto()
				{
					Id = i,
					Date = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day)
				});
				currentDate = currentDate.AddDays(1);
			}

			return dateList.ToArray();
		}
		public async Task<SessionDto[]> GetSessionsAsync(GetSessionsRequestDto request)
		{
			return _mapper.Map<SessionDto[]>(await _repositoryBundle.Sessions.GetSessionsAsync(new GetSessionsFilterDb()
			{
				CinemaId = new ObjectId(request.CinemaId),
				MovieId = new ObjectId(request.MovieId),
				From = new DateTime(request.Date.Year, request.Date.Month, request.Date.Day - 1),
				To = new DateTime(request.Date.Year, request.Date.Month, request.Date.Day)
			}));
		}
		public async Task RemoveObsoleteSessionsAsync(DateTime currentDate)
		{
			var to = currentDate.AddDays(-1);   // Schedule obsoletes to the next day after showing
			var obsoleteSessions = await _repositoryBundle.Sessions.GetSessionsOlderThanAsync(to);
			await _repositoryBundle.Sessions.RemoveRangeAsync(obsoleteSessions);
		}
		public async Task DeleteSessionAsync(String id)
		{
			var session = await _repositoryBundle.Sessions.GetAsync(id);
			if(session == null)
				throw new RequestedObjectNotFoundException($"Session with id: {id} was not found!");

			await _repositoryBundle.Sessions.DeleteAsync(id);
		}
		public async Task<SessionWithCinemaAndMovieDto[]> GetAllSessionsWithCinemasAndMovies()
		{
			var sessionsDb = await _repositoryBundle.Sessions.GetAllAsync();
			var responseSessionList = new List<SessionWithCinemaAndMovieDto>(sessionsDb.Length);

			foreach(var x in sessionsDb)
			{
				var cinema = await _repositoryBundle.Cinemas.GetAsync(x.CinemaId);
				var movie = await _repositoryBundle.Movies.GetAsync(x.MovieId);

				responseSessionList.Add(new SessionWithCinemaAndMovieDto()
				{
					Id = x.Id.ToString(),
					StartDate = x.StartDate,
					Cinema = _mapper.Map<CinemaDto>(cinema),
					Movie = _mapper.Map<MovieDto>(movie)
				});
			}

			return responseSessionList.ToArray();
		}
		public async Task<CinemaWithMovieDto[]> CreateSchedule()
		{
			var cinemasDb = await _repositoryBundle.Cinemas.GetAllAsync();
			var responseCinemaList = new List<CinemaWithMovieDto>();

			foreach(var cinemaDb in cinemasDb)
			{
				var sessionsExistsForCinema = await _repositoryBundle.Cinemas.CheckSessionExistenceAsync(cinemaDb.Id);
				if(!sessionsExistsForCinema)
					continue;

				var cinemaMoviesDb = await _repositoryBundle.Movies.GetByCinemaId(cinemaDb.Id);
				var moviesList = new List<MovieWithSessionDto>();

				foreach(var movieDb in cinemaMoviesDb)
				{
					var sessionsExistsForMovie = await _repositoryBundle.Movies.CheckSessionExistenceAsync(movieDb.Id);
					if(!sessionsExistsForMovie)
						continue;

					var movieDto = _mapper.Map<MovieWithSessionDto>(movieDb);
					movieDto.Sessions = _mapper.Map<CleanSessionDto[]>(await _repositoryBundle.Sessions.GetSessionsAsync(cinemaDb.Id, movieDb.Id));

					moviesList.Add(movieDto);
				}

				var cinemaDto = _mapper.Map<CinemaWithMovieDto>(cinemaDb);
				cinemaDto.Movies = moviesList.ToArray();

				responseCinemaList.Add(cinemaDto);
			}

			return responseCinemaList.ToArray();
		}
	}
}