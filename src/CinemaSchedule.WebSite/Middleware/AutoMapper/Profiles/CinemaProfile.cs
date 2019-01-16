using AutoMapper;
using CinemaSchedule.Contracts.Models;
using CinemaSchedule.Database.Models.Storage;
using CinemaSchedule.WebSite.Services.Models;

namespace CinemaSchedule.WebSite.Middleware.AutoMapper.Profiles
{
	public class CinemaProfile : Profile
	{
		public CinemaProfile()
		{
			CreateMap<CinemaDb, CinemaDto>();
			CreateMap<CinemaDto, CinemaAm>()
				.ForMember(p => p.Id, opt => opt.MapFrom(p => p.Id.ToString()));

			CreateMap<MovieDb, MovieDto>();
			CreateMap<MovieDto, MovieAm>()
				.ForMember(p => p.Id, opt => opt.MapFrom(p => p.Id.ToString()));
		}
	}
}