using CinemaSchedule.Database.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;

#if DEBUG
namespace CinemaSchedule.WebSite.Controllers.Api
{
	[Route("api/[controller]/[action]")]
	public class DebugController : Controller
	{
		private readonly IRepositoryBundle _repositoryBundle;
		private readonly IHostingEnvironment _env;


		public DebugController(IRepositoryBundle repositoryBundle, IHostingEnvironment env)
		{
			_repositoryBundle = repositoryBundle;
			_env = env;
		}


		// ACTIONS ////////////////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Return current environment name
		/// </summary>
		[HttpGet]
		[ProducesResponseType(200)]
		[ProducesResponseType(typeof(String), 500)]
		public IActionResult GetEnvironmentName()
		{
			return Ok(_env.EnvironmentName);
		}

		/// <summary>
		/// Gets information about available repositories
		/// </summary>
		[HttpGet]
		[ProducesResponseType(typeof(String), 200)]
		[ProducesResponseType(typeof(String), 500)]
		public IActionResult GetAvailableRepositories()
		{
			try
			{
				return Ok(_repositoryBundle);
			}
			catch(ApplicationException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		/// <summary>
		/// Creates unhandled exception
		/// </summary>
		[HttpGet]
		[ProducesResponseType(typeof(String), 200)]
		[ProducesResponseType(typeof(String), 500)]
		public IActionResult CreateUnhandledException()
		{
			throw new Exception("Exception message!");
		}
	}
}
#endif