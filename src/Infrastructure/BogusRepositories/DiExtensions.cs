using Ku12;
using Microsoft.Extensions.DependencyInjection;

namespace BogusRepositories
{
	public static class DiExtensions
	{
		public static IServiceCollection AddBogusRepositories(
			this IServiceCollection services)
		{
			services.AddSingleton<IPersonsRepository, PersonsRepository>();

			return services;
		}
	}
}
