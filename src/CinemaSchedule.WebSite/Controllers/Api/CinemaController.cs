using AutoMapper;
using CinemaSchedule.Contracts.Models;
using CinemaSchedule.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CinemaSchedule.WebSite.Controllers.Api
{
	[Route("api/[controller]/[action]")]
	public class CinemaController : Controller
	{
		private readonly ICinemaService _cinemaService;
		private readonly IMapper _mapper;


		public CinemaController(ICinemaService cinemaService, IMapper mapper)
		{
			_cinemaService = cinemaService;
			_mapper = mapper;
		}


		// ACTIONS ////////////////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Retrieves all cinemas
		/// </summary>
		[HttpGet]
		[ProducesResponseType(typeof(CinemaAm[]), 200)]
		[ProducesResponseType(401)]
		[ProducesResponseType(typeof(String), 500)]
		public async Task<IActionResult> GetAllCinemas()
		{
			return Ok(_mapper.Map<CinemaAm[]>(await _cinemaService.GetAllCinemasAsync()));
		}

		/// <summary>
		/// Retrieves all movies
		/// </summary>
		[HttpGet]
		[ProducesResponseType(typeof(MovieAm[]), 200)]
		[ProducesResponseType(401)]
		[ProducesResponseType(typeof(String), 500)]
		public async Task<IActionResult> GetAllMovies()
		{
			return Ok(_mapper.Map<MovieAm[]>(await _cinemaService.GetAllMoviesAsync()));
		}

		/// <summary>
		/// Retrieves all cinema related movies by the cinema id
		/// </summary>
		[HttpGet]
		[ProducesResponseType(typeof(MovieAm[]), 200)]
		[ProducesResponseType(401)]
		[ProducesResponseType(typeof(String), 500)]
		public async Task<IActionResult> GetMoviesByCinemaId([FromQuery] String cinemaId)
		{
			return Ok(_mapper.Map<MovieAm[]>(await _cinemaService.GetMoviesByCinemaIdAsync(cinemaId)));
		}
	}
}