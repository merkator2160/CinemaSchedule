using AutoMapper;
using CinemaSchedule.Contracts.Models;
using CinemaSchedule.Database.Models.Filters;
using CinemaSchedule.Database.Models.Storage;
using CinemaSchedule.WebSite.Services.Models;
using MongoDB.Bson;

namespace CinemaSchedule.WebSite.Middleware.AutoMapper.Profiles
{
	public class CinemaProfile : Profile
	{
		public CinemaProfile()
		{
			CreateMap<CinemaDb, CinemaDto>()
				.ForMember(p => p.Id, opt => opt.MapFrom(p => p.Id.ToString()));
			CreateMap<CinemaDto, CinemaAm>();

			CreateMap<MovieDb, MovieDto>()
				.ForMember(p => p.Id, opt => opt.MapFrom(p => p.Id.ToString()));
			CreateMap<MovieDto, MovieAm>();

			CreateMap<ScheduleEditorDateDto, ScheduleEditorDateAm>();

			CreateMap<GetSessionsRequestAm, GetSessionsRequestDto>();
			CreateMap<GetSessionsRequestDto, GetSessionsFilterDb>()
				.ForMember(p => p.CinemaId, opt => opt.MapFrom(p => new ObjectId(p.CinemaId)))
				.ForMember(p => p.MovieId, opt => opt.MapFrom(p => new ObjectId(p.MovieId)));

			CreateMap<SessionDb, SessionDto>()
				.ForMember(p => p.Id, opt => opt.MapFrom(p => p.Id.ToString()))
				.ForMember(p => p.CinemaId, opt => opt.MapFrom(p => p.CinemaId.ToString()))
				.ForMember(p => p.MovieId, opt => opt.MapFrom(p => p.MovieId.ToString()));
			CreateMap<SessionDto, SessionAm>();
		}
	}
}