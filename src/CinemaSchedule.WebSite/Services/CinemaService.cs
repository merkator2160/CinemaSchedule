using AutoMapper;
using CinemaSchedule.Database.Interfaces;
using CinemaSchedule.WebSite.Services.Interfaces;
using CinemaSchedule.WebSite.Services.Models;
using CinemaSchedule.WebSite.Services.Models.Exceptions;
using System;
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
		public async Task<CinemaDto[]> GetAllAsync()
		{
			return _mapper.Map<CinemaDto[]>(await _repositoryBundle.Cinemas.GetAllAsync());
		}
		public async Task<CinemaDto> GetAsync(String id)
		{
			var cinemaDb = await _repositoryBundle.Cinemas.GetAsync(id);
			if(cinemaDb == null)
				throw new RequestedObjectNotFoundException($"Cinema with id = {id} not found!");

			return _mapper.Map<CinemaDto>(cinemaDb);
		}
	}
}