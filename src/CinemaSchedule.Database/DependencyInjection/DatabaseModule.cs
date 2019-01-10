using Autofac;
using CinemaSchedule.Common.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Reflection;
using Module = Autofac.Module;

namespace CinemaSchedule.Database.DependencyInjection
{
	public class DatabaseModule : Module
	{
		private const String _defaultDbConnectionName = "MongoDbConnection";
		private readonly IConfiguration _configuration;
		private readonly Assembly _currentAssembly;


		public DatabaseModule(IConfiguration configuration)
		{
			_currentAssembly = Assembly.GetExecutingAssembly();
			_configuration = configuration;
		}


		// COMPONENT REGISTRATION /////////////////////////////////////////////////////////////////
		protected override void Load(ContainerBuilder builder)
		{
			RegisterContext(builder);
			RegisterRepositories(builder);
			builder.RegisterLocalConfiguration(_configuration);
		}
		public void RegisterContext(ContainerBuilder builder)
		{
			builder.RegisterInstance(new MongoClient(_configuration.GetConnectionString(_defaultDbConnectionName)))
				.AsImplementedInterfaces()
				.SingleInstance();

			builder.RegisterType<DataContext>()
				.AsSelf()
				.AsImplementedInterfaces();
		}
		public void RegisterRepositories(ContainerBuilder builder)
		{
			builder
				.RegisterAssemblyTypes(_currentAssembly)
				.Where(t => t.Name.EndsWith("Repository"))
				.AsSelf()
				.AsImplementedInterfaces();

			builder
				.RegisterType<RepositoryBundle>()
				.AsSelf()
				.AsImplementedInterfaces();
		}
	}
}