using AutoMapper;
using CinemaSchedule.Contracts.Models.ScheduleViewer;
using CinemaSchedule.Database.Models.Storage;
using CinemaSchedule.WebSite.Services.Models.ScheduleViewer;

namespace CinemaSchedule.WebSite.Middleware.AutoMapper.Profiles
{
	public class ScheduleViewerProfile : Profile
	{
		public ScheduleViewerProfile()
		{
			CreateMap<SessionWithCinemaAndMovieDto, SessionWithCinemaAndMovieAm>();

			CreateMap<CinemaDb, CinemaWithMovieDto>()
				.ForMember(p => p.Movies, opt => opt.Ignore());
			CreateMap<MovieDb, MovieWithSessionDto>()
				.ForMember(p => p.Sessions, opt => opt.Ignore());
			CreateMap<SessionDb, CleanSessionDto>();

			CreateMap<CinemaWithMovieDto, CinemaWithMovieAm>();
			CreateMap<MovieWithSessionDto, MovieWithSessionAm>();
			CreateMap<CleanSessionDto, CleanSessionAm>();
		}
	}
}