using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.Text.Json;
using OpenAI.Chat;
using cvtool;
// See https://aka.ms/new-console-template for more information

// user inputed job description -> send to open ai with profile -> request return of relevant profile sections -> build cv
// We want open ai to return the indexes of what work experience and projects to include and from each of them what bullets to choose
//
// { work: [
// 	{ index: 0
// 	  bullets: [1, 4, 5]
// 	},  
// ]

// Serialise user education, work experience and projects to send to open ai
Profile ReadUserProfile() {
	using StreamReader reader = new("data/profile.yaml");

	string text = reader.ReadToEnd();
	var deserializer = new DeserializerBuilder()
		.WithNamingConvention(UnderscoredNamingConvention.Instance)
		.Build();

	var profile = deserializer.Deserialize<Profile>(text);

	return profile;
}

void RequestRelevantExperience(Profile user, string job) {
	string jsonEducation = JsonSerializer.Serialize(user.Education);
	string jsonWork = JsonSerializer.Serialize(user.Work);
	string jsonProjects = JsonSerializer.Serialize(user.Projects);

	string request = @"
		You are a cv tailouring agent who is responsbile for selecting the users most relevant experience for a job role
		to place in their tailoured cv. You will be provied information on the users work experience and personal projects. For each category return the index of the relevant section and the index of the bullet points to include.

		Example response 
		{
			summary: 'Short description of reasoning of choices'
			work: [
			{ index: 0,
			  bullets: [1,4,6]
			],
			projects: [
			{ index: 0,
			  bullets: [1]
			},
			{ index: 0,
			  bullets: [3,4]
			}]
		}
		
		User Data:
	";
	
	request = request + jsonWork.ToString();
	request = request + jsonProjects.ToString();
	request = request + $"Job: {job}";

	ChatClient client = new(model: "gpt-5.1", apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
	ChatCompletion completion = client.CompleteChat(request);
	Console.WriteLine($"OPENAI RESPONSE: {completion.Content[0].Text}");
}


Profile user = ReadUserProfile();
string job = "Junior C# Developer at Hospitaltity SaaS startup";
RequestRelevantExperience(user, job);



