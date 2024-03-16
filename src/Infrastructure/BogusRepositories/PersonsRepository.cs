using Ku12;
using Ku12.Models;

namespace BogusRepositories
{
	/// <summary>
	/// This implementation generates 10 persons using a Bogus faker.
	/// </summary>
	internal class PersonsRepository
		: IPersonsRepository
	{
		List<Person> persons;

		public PersonsRepository()
		{
			var minDate = DateTime.Now.AddYears(-50);
			var maxDate = DateTime.Now.AddYears(-5);

			var f = new Bogus.Faker<Person>()
				.RuleFor(
					x => x.DateOfBirth,
					f => f.Date.Between(minDate, maxDate))
				.RuleFor(
					x => x.FirstName,
					f => f.Person.FirstName)
				.RuleFor(
					x => x.LastName,
					f => f.Person.LastName);

			f.UseSeed(2);

			persons = f.Generate(5);
		}


		IEnumerable<Person> IPersonsRepository.GetChildren()
		{
			return persons
				.Where(x => CalculateAge(x.DateOfBirth.Date) < 18)
				.AsEnumerable();
		}

		IEnumerable<Person> IPersonsRepository.GetAdults()
		{
			return persons
				.Where(x => CalculateAge(x.DateOfBirth.Date) >= 18)
				.AsEnumerable();
		}


		/// <summary>
		/// A pretty dumb function to calculate age.
		/// </summary>
		/// <param name="dateOfBirth"></param>
		/// <returns></returns>
		private int CalculateAge(DateTime dateOfBirth)
		{
			var dt = DateTime.Today;
			var totalDays = (dt - dateOfBirth.Date).TotalDays;
			int age = (int)(totalDays / 365.25);
			return age;
		}
	}
}
