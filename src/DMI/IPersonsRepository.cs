using Ku12.Models;

namespace Ku12
{
	public interface IPersonsRepository
	{
		/// <summary>
		/// Returns persons who are more than 18 or more years old.
		/// </summary>
		IEnumerable<Person> GetAdults();


		/// <summary>
		/// Returns persons who are less than 18 years old.
		/// </summary>
		IEnumerable<Person> GetChildren();
	}
}
