namespace cvtool;

public class Profile {
	public string? Name { get; set; }
	public string? Phone { get; set; }
	public string? Email { get; set; }
	public string? Github { get; set; }

	public List<Qualifications> Education { get; set;} = [];
	public List<Job> Work { get; set;} = [];
	public List<Project> Projects { get; set;} = [];

}

public class Qualifications {
	public string? School { get; set; }
	public string? Level { get; set; }
	public List<Subject> Subject { get; set; } = [];
}

public class Subject {
	public string? Name { get; set; }
	public string? Grade { get; set; }
}

public class Job {
	public string? JobTitle { get; set; }
	public string? Employer { get; set; }
	public string? TimePeriod { get; set; }
	public List<string> Bullets { get; set; } = [];
	public List<string> Skills { get; set; } = [];
}

public class Project {
	public string? Name { get; set; }
	public string? Link { get; set; }
	public List<string> Bullets { get; set; } = [];
	public List<string> Skills { get; set; } = [];
}
