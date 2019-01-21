using AutoMapper;
using CinemaSchedule.Database.Interfaces;
using CinemaSchedule.Database.Models.Filters;
using CinemaSchedule.WebSite.Services.Interfaces;
using CinemaSchedule.WebSite.Services.Models;
using CinemaSchedule.WebSite.Services.Models.Exceptions;
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
		public ScheduleEditorDateDto[] CreateDatesForScheduleEditor()
		{
			const Int32 scheduleEditorDatesAmount = 30;
			var currentDate = DateTime.UtcNow.AddDays(1);   // Schedule can be edited only for the next day
			var dateList = new List<ScheduleEditorDateDto>(scheduleEditorDatesAmount);

			for(var i = 0; i < scheduleEditorDatesAmount; i++)
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
			var filter = _mapper.Map<GetSessionsFilterDb>(request);

			return _mapper.Map<SessionDto[]>(await _repositoryBundle.Sessions.GetSessionsAsync(filter));
		}
		public async Task RemoveObsoleteSessionsAsync()
		{
			var to = DateTime.UtcNow.AddDays(-1);
			var obsoleteSessions = await _repositoryBundle.Sessions.GetSessionsOlderThanAsync(to);
			await _repositoryBundle.Sessions.RemoveRangeAsync(obsoleteSessions);
		}
	}
}