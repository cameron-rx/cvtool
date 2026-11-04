namespace cvtool.AI;

public class OpenAIDTO {
	public string? Summary { get; set; }
	public List<ChosenSection> Work { get; set; } = [];
	public List<ChosenSection> Projects { get; set; } = [];

	public override string ToString(){
		string ChosenWorkString = "";
		string ChosenProjectsString = "";

		foreach (var ChosenWork in Work) {
			ChosenWorkString += $"Index: {ChosenWork.Index} Bullets: ";
			foreach (var Bullet in ChosenWork.Bullets) {
				ChosenWorkString += $"{Bullet} ";
			}
			ChosenWorkString += "\n";
		}

		foreach (var ChosenProjects in Projects) {
			ChosenProjectsString += $"Index: {ChosenProjects.Index} Bullets: ";
			foreach (var Bullet in ChosenProjects.Bullets) {
				ChosenProjectsString += $"{Bullet} ";
			}
			ChosenProjectsString += "\n";
		}

		return $"Summary:\n{this.Summary}\n\nWork:\n{ChosenWorkString} \nProjects:\n{ChosenProjectsString}";
	}
}

public class ChosenSection {
	public int Index { get; set; }
	public int[] Bullets { get; set; } = [];
}
