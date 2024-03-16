using BogusRepositories;
using Dumpify;
using Ku12.ConsoleApp;
using Microsoft.Extensions.DependencyInjection;

/* prepare services */
var sc = new ServiceCollection();
sc.AddScoped<PersonsService>();
sc.AddBogusRepositories();
var sp = sc.BuildServiceProvider();
/*==================*/

var svcPersons = sp.GetRequiredService<PersonsService>();


Console.WriteLine("Adults:");
foreach (var p in svcPersons.GetAdults())
{
	p.Dump();
};

Console.WriteLine("Children:");
foreach (var p in svcPersons.GetChildren())
{
	p.Dump();
}
