using System;
using System.Collections.Generic;

namespace heist{

    class Team{

        public string Name {get; set;}

        public List<TeamMember> listOfMembers {get; set;} = new List<TeamMember>();

        public Team(string name){
            Name = name;
        }

        public void printTeamDetails(Team team){
            Console.WriteLine($"\n{team.Name} ({team.listOfMembers.Count} members)\n -------------- \n");
            team.listOfMembers.ForEach(member => 
            Console.WriteLine($"\n Member Name: {member.Name} \n -Skill Level:{member.SkillLevel} \n -Courage Factor:{member.CourageFactor} \n"));
        }
    }
}