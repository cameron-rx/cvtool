using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
// See https://aka.ms/new-console-template for more information

//DONE: Function to read user data from user data yaml
//TODO: Function to create new folder for job application and place text file there
//TODO: Function to read job application description from folder 
//TODO: Function to send request to open ai
//TODO: Function to generate pdf template
//TODO: Function to add relevant information into cv from open ai
//TODO: Function to write pdf to disk in correct file

try
{
	using StreamReader reader = new("data/profile.yaml");

	string text = reader.ReadToEnd();
	var deserializer = new DeserializerBuilder()
		.WithNamingConvention(UnderscoredNamingConvention.Instance)
		.Build();

	var profile = deserializer.Deserialize<cvtool.Profile>(text);
	Console.WriteLine(profile.Name);
}
catch (IOException e)
{
	Console.WriteLine("File could not be read");
	Console.WriteLine(e.Message);
}

