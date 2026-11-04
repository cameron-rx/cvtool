namespace cvtool.User;
using cvtool.AI;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

public class Profile
{
	public string? Name { get; set; }
	public string? Phone { get; set; }
	public string? Email { get; set; }
	public string? Github { get; set; }

	public List<Qualifications> Education { get; set; } = [];
	public List<Job> Work { get; set; } = [];
	public List<Project> Projects { get; set; } = [];

	public static Profile ReadConfig(string path)
	{
		using StreamReader reader = new(path);

		string text = reader.ReadToEnd();
		var deserializer = new DeserializerBuilder()
			.WithNamingConvention(UnderscoredNamingConvention.Instance)
			.Build();

		var profile = deserializer.Deserialize<Profile>(text);

		return profile;
	}

	public void ChooseSections(string jobDescription)
	{
		OpenAIDTO result = OpenAIProvider.GetRelevantSections(jobDescription, this.Work, this.Projects);
		Console.WriteLine($"Summary:\n{result.Summary}\n");

		Console.WriteLine("Work:\n");
		foreach (var chosenWork in result.Work) {

			var work = this.Work[chosenWork.Index];
			Console.WriteLine($"{work.JobTitle}, {work.Employer}\n");

			foreach (var Bullet in chosenWork.Bullets) {
				Console.WriteLine($"- {work.Bullets[Bullet]}\n");
			}

			Console.WriteLine();
		}

		Console.WriteLine("Projects:\n");
		foreach (var chosenProject in result.Projects) {

			var project = this.Projects[chosenProject.Index];
			Console.WriteLine($"{project.Name}\n");

			foreach (var Bullet in chosenProject.Bullets) {
				Console.WriteLine($"- {project.Bullets[Bullet]}\n");
			}
			Console.WriteLine();
		}

		foreach (var ChosenProjects in Projects) {
			foreach (var Bullet in ChosenProjects.Bullets) {
			}
		}
	}
}

public class Qualifications
{
	public string? School { get; set; }
	public string? Level { get; set; }
	public List<Subject> Subject { get; set; } = [];
}

public class Subject
{
	public string? Name { get; set; }
	public string? Grade { get; set; }
}

public class Job
{
	public string? JobTitle { get; set; }
	public string? Employer { get; set; }
	public string? TimePeriod { get; set; }
	public List<string> Bullets { get; set; } = [];
	public List<string> Skills { get; set; } = [];
}

public class Project
{
	public string? Name { get; set; }
	public string? Link { get; set; }
	public List<string> Bullets { get; set; } = [];
	public List<string> Skills { get; set; } = [];
}
