using CinemaSchedule.WebSite.Services.Models;
using System;
using System.Threading.Tasks;

namespace CinemaSchedule.WebSite.Services.Interfaces
{
	public interface ICinemaService
	{
		Task<CinemaDto[]> GetAllAsync();
		Task<CinemaDto> GetAsync(String id);
	}
}