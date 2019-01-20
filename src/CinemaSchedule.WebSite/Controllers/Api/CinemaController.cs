using AutoMapper;
using CinemaSchedule.Contracts.Models;
using CinemaSchedule.WebSite.Services.Interfaces;
using CinemaSchedule.WebSite.Services.Models;
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

		/// <summary>
		/// Creates dates for schedule editor
		/// </summary>
		[HttpGet]
		[ProducesResponseType(typeof(ScheduleEditorDateAm[]), 200)]
		[ProducesResponseType(401)]
		[ProducesResponseType(typeof(String), 500)]
		public IActionResult CreateDatesForEditor()
		{
			return Ok(_mapper.Map<ScheduleEditorDateAm[]>(_cinemaService.CreateDatesForScheduleEditor()));
		}

		[HttpGet]
		[ProducesResponseType(typeof(SessionAm[]), 200)]
		[ProducesResponseType(401)]
		[ProducesResponseType(typeof(String), 500)]
		public async Task<IActionResult> GetSessions([FromQuery] GetSessionsRequestAm request)
		{
			if(!ModelState.IsValid)
				return BadRequest("Please provide valid request!");

			var requestDto = _mapper.Map<GetSessionsRequestDto>(request);

			return Ok(_mapper.Map<SessionAm[]>(await _cinemaService.GetSessionsAsync(requestDto)));
		}
	}
}