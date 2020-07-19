using System;

namespace heist{

    class TeamMember{

        public string Name {get; set;}

        public ushort SkillLevel {get; set;}

        public double CourageFactor {get; set;}

        public TeamMember (string name, ushort skill, double courage){
            Name = name;
            SkillLevel = skill;
            CourageFactor = courage;
        }

        public void PrintMemberDetails(TeamMember teamMember){
            Console.WriteLine($"\n{teamMember.Name}\n -------------- \n Skill Level: {teamMember.SkillLevel} \n Courage Factor: {teamMember.CourageFactor} ");
        }
    }
}