# cvtool
## Idea
A command line based agentic tool to craft cvs specific to job applications based on the users own documented experience, AI selects from the users own written reference what to include and what to not based on the job description provided. A CV is then generated based on a chosen template. The idea isn't to write the contents of the cv itself but to structure the content from a master reference provided by the user.

## Plan
Do the proof of concept as a local commandline application in c# for job prep
If successful build out as a localfirst web app

## MVP
### Technology
C#
OpenAI Api
Document Generator Library? (QuestPDF)
### Flow
Structured yaml files or something simliar which holds all the content for each 'experience' 
- different experience types 'Personal Project', 'Work Experience' 
- each experience contains a summary detail which is read by llm to see if applicable
- each experience defines skills used
- each experience has details which can be used as bullet points in cv generation

User Context stored in yaml file as well 'Name', 'Contact Details', 'Links'

User enters new job command -> takes name of the job title and company -> creates folder for that job with text file to enter jobposting description -> user enters job posting description into the file -> User enters generate cv command from that job posting-> All experiences are grabbed from local context and appended to llm request with system prompt and job posting -> llm generatesa json response -> json response is inserted into quest pdf template -> generate pdf and place in correct folder?  

addional features -> print initial respones to user and ask if they want to make any changes before generation



## Public Project
Local First PWA
SvelteKit (worked in it before and just works)
### Thoughts on how to implement
- Must be shareable online so that people could use it for themselves
- Probably means creating a small web app which handles this 
- Doesnt have to look crazy just has to work
- Have people enter their own api key to use it 
- Basically creating a full frontend application then which would suggest using an spa framework
- Sits in local storage with option to export to filesystem?
- Easier to write commandline version first to test idea?

