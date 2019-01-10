using AutoMapper;
using CinemaSchedule.Contracts.Models;
using CinemaSchedule.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CinemaSchedule.WebSite.Controllers.Api
{
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
		/// [Auth] Retrieves all cinemas
		/// </summary>
		[HttpGet]
		[ProducesResponseType(typeof(CinemaAm[]), 200)]
		[ProducesResponseType(401)]
		[ProducesResponseType(typeof(String), 500)]
		public async Task<IActionResult> GetAllCinemas()
		{
			return Ok(_mapper.Map<CinemaAm[]>(await _cinemaService.GetAllAsync()));
		}
	}
}