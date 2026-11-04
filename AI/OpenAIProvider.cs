namespace cvtool.AI;
using OpenAI.Chat;
using System.Text.Json;
using cvtool.User;

public static class OpenAIProvider {
	public static OpenAIDTO GetRelevantSections(string job, List<Job> work, List<Project> projects)
	{
		string jsonWork = JsonSerializer.Serialize(work);
		string jsonProjects = JsonSerializer.Serialize(projects);

		string request = @"
			You are a cv tailouring agent who is responsbile for selecting the users most relevant experience for a job role
			to place in their tailoured cv. You will be provied information on the users work experience and personal projects. For each category return the index of the relevant section and the index of the bullet points to include.

			Example response 
			{
				Summary: 'Short description of reasoning of choices'
					Work: [
					{ Index: 0,
						Bullets: [1,4,6]
					],
					Projects: [
					{ Index: 0,
						Bullets: [1]
					},
					{ Index: 0,
						Bullets: [3,4]
					}]
					}

				User Data:
					";

		request = request + jsonWork.ToString();
		request = request + jsonProjects.ToString();
		request = request + $"Job: {job}";

		ChatClient client = new(model: "gpt-5.1", apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
		ChatCompletion completion = client.CompleteChat(request);


		OpenAIDTO? jsonResponse = JsonSerializer.Deserialize<OpenAIDTO>(completion.Content[0].Text);

		if (jsonResponse != null)
		{
			return jsonResponse;
		} 
		else 
		{
			return new OpenAIDTO();
		}
	}
}
