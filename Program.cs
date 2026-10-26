using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
// See https://aka.ms/new-console-template for more information

//TODO: Function to read experiences from experiences folder
//TODO: Function to read user data from user data yaml
//TODO: Function to create new folder for job application and place text file there
//TODO: Function to read job application description from folder 
//TODO: Function to send request to open ai
//TODO: Function to generate pdf template
//TODO: Function to add relevant information into cv from open ai
//TODO: Function to write pdf to disk in correct file



var yml = @"
name: 'Cameron Robinson'
phone: '07340 006306'
email: 'camjr246@yahoo.co.uk'
github: 'https://github.com/cameron-rx'

education:
  - school: 'University of Sheffield'
    level: 'BSc'
    subject: 
      - name: 'Computer Science'
        grade: '2:2'
  - school: 'Brunts Sixth Form'
    level: 'A Level'
    subject: 
      - name: 'Maths'
        grade: 'A*'
      - name: 'Computer Science'
        grade: 'A*'
      - name: 'Physics'
        grade: 'A'

work:
  - job_title: 'Team Leaders'
    employer: 'Revolution Sheffield'
    time_period: 'Aug 2021 - Jan 2026'
    bullets: 
      - 'Lead team of ......'
      - ''
    skills:
      - 'Teamwork'
      - 'Leadership'

projects:
  - name: 'StockSpeech'
    link: 'https://stockspeech.crwebstudio.co.uk/'
    bullets:
      - 'Voice powered stock counting SvelteKit web app...'
      - ''
    skills: 
      - 'SvelteKit'
      - 'Deepgram STT'
      - 'Cloudflare Workers'
";

var deserializer = new DeserializerBuilder()
	.WithNamingConvention(UnderscoredNamingConvention.Instance)
	.Build();

var profile = deserializer.Deserialize<cvtool.Profile>(yml);

Console.WriteLine(profile.Name);
