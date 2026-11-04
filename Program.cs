using cvtool;
using cvtool.DTO;
using cvtool.User;

// See https://aka.ms/new-console-template for more information

// user inputed job description -> send to open ai with profile -> request return of relevant profile sections -> build cv
// We want open ai to return the indexes of what work experience and projects to include and from each of them what bullets to choose
//
// { work: [
// 	{ index: 0
// 	  bullets: [1, 4, 5]
// 	},  
// ]

string job = "Bar Manager at local pub";
Profile user = Profile.ReadConfig("data/profile.yaml");
user.ChooseSections(job);



