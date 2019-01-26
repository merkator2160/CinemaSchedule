using AutoMapper;
using CinemaSchedule.Contracts.Models;
using CinemaSchedule.Database.Models.Storage;
using CinemaSchedule.WebSite.Services.Models;

namespace CinemaSchedule.WebSite.Middleware.AutoMapper.Profiles
{
	public class DirectMappingProfile : Profile
	{
		public DirectMappingProfile()
		{
			CreateMap<CinemaDb, CinemaDto>()
				.ForMember(p => p.Id, opt => opt.MapFrom(p => p.Id.ToString()));
			CreateMap<CinemaDto, CinemaAm>();

			CreateMap<MovieDb, MovieDto>()
				.ForMember(p => p.Id, opt => opt.MapFrom(p => p.Id.ToString()));
			CreateMap<MovieDto, MovieAm>();

			CreateMap<ScheduleEditorDateDto, ScheduleEditorDateAm>();

			CreateMap<GetSessionsRequestAm, GetSessionsRequestDto>();

			CreateMap<SessionDb, SessionDto>()
				.ForMember(p => p.Id, opt => opt.MapFrom(p => p.Id.ToString()))
				.ForMember(p => p.CinemaId, opt => opt.MapFrom(p => p.CinemaId.ToString()))
				.ForMember(p => p.MovieId, opt => opt.MapFrom(p => p.MovieId.ToString()));
			CreateMap<SessionDto, SessionAm>();
		}
	}
}