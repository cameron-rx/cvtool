namespace cvtool.dto;

public class OpenAIDTO {
	public string? Summary { get; set; }
	public List<ChosenSection> Work { get; set; } = [];
	public List<ChosenSection> Projects { get; set; } = [];
}

public class ChosenSection {
	public int Index { get; set; }
	public int[] Bullets { get; set; } = [];
}
