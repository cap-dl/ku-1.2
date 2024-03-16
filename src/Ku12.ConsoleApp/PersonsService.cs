using Ku12.Models;

namespace Ku12.ConsoleApp
{
	internal class PersonsService
	{
		private readonly IPersonsRepository repo;

		public PersonsService(
			IPersonsRepository personsRepository)
		{
			repo = personsRepository;
		}


		public IEnumerable<Person> GetAdults()
		{
			return repo.GetAdults();
		}


		public IEnumerable<Person> GetChildren()
		{
			return repo.GetChildren();
		}
	}
}
