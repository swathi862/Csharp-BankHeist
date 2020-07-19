using System;

namespace heist
{
    class Program
    {
        public static void PrintMainMenu(){
            int successfulRuns = 0;
            int failedRuns = 0;

            Console.WriteLine("Plan Your Heist!\n");

            Console.WriteLine("Enter the bank's security level.");
            ushort bankDifficultyLevel = 0;
            bool bankBool = false;
            while (bankBool == false){
                    try{
                        bankDifficultyLevel= Convert.ToUInt16(Console.ReadLine());
                        if(bankDifficultyLevel >= 0){
                            bankBool = true;
                        }
                    } catch (Exception){
                        Console.WriteLine("Please enter a positive integer(greater than -1).");
                    }
            }

            Console.WriteLine("\nPlease enter your team's name.");
            string teamName= Console.ReadLine();
            Team team = new Team(teamName);
            PrintBuildTeamMenu(team, bankDifficultyLevel, successfulRuns, failedRuns);
        }

        public static void PrintBuildTeamMenu(Team team, int bankDifficultyLevel, int success, int failed){
            Console.WriteLine("\n1. Add a Member");
            Console.WriteLine("2. View My Team");
            Console.WriteLine("3. Heist!");
            Console.WriteLine("4. Exit \n");

            string response = Console.ReadLine();

            if(response == "1"){
                AddTeamMember(team, bankDifficultyLevel, success, failed);
            }
            else if(response == "2"){
                team.printTeamDetails(team);
                PrintBuildTeamMenu(team, bankDifficultyLevel, success, failed);
            }
            else if(response == "3"){
                Heist(team, bankDifficultyLevel, success, failed);
            }
            else if (response == "4"){
                FinalReport(success, failed);
                Console.WriteLine("Thanks for Playing!");
            }
        }

        public static void PrintTeamMenu(Team team, int bankDifficultyLevel, int success, int failed){
            Console.WriteLine("\n1. View My Team");
            Console.WriteLine("2. Heist!");
            Console.WriteLine("3. Exit \n");

            string response = Console.ReadLine();

            if(response == "1"){
                team.printTeamDetails(team);
                PrintBuildTeamMenu(team, bankDifficultyLevel, success, failed);
            }
            else if(response == "2"){
                Heist(team, bankDifficultyLevel, success, failed);
            }
            else if (response == "3"){
                FinalReport(success, failed);
                Console.WriteLine("Thanks for Playing!");
            }
        }

        public static void PrintHeistMenu(Team team, int bankDifficultyLevel, int success, int failed){
            Console.WriteLine("\n1. Try Again! Add another member to your existing team.");
            Console.WriteLine("2. Create a new team.");
            Console.WriteLine("3. Exit\n");

            string response = Console.ReadLine();

            if(response == "1"){
                AddTeamMember(team, bankDifficultyLevel, success, failed);
            }
            else if(response == "2"){
                PrintMainMenu();
            }
            else if(response == "3"){
                FinalReport(success, failed);
                Console.WriteLine("Thanks for Playing!\n");
            }
        }

        public static void AddTeamMember(Team team, int bankDifficultyLevel, int success, int failed){
            Console.WriteLine("\nPlease enter the team member's name.");
            string name= Console.ReadLine();
            if(name == ""){
                team.printTeamDetails(team);
                PrintTeamMenu(team, bankDifficultyLevel, success, failed);
            }
            else{
            Console.WriteLine("Enter their skill level.");
            ushort skillLevel = 0;
            bool skillBool = false;
            while (skillBool == false){
                    try{
                        skillLevel= Convert.ToUInt16(Console.ReadLine());
                        if(skillLevel >= 0){
                            skillBool = true;
                        }
                    } catch (Exception){
                        Console.WriteLine("Please enter a positive integer(greater than -1).");
                    }
            }

            Console.WriteLine("Enter their courage factor (as a decimal between 0.0 - 2.0).");
                
            double courageFactor = 0.0;
            bool courageBool = false;
            while (courageBool == false){
                    try{
                        courageFactor= double.Parse(Console.ReadLine());
                        if(courageFactor > 0.0 && courageFactor <= 2.0){
                            courageBool = true;
                        }
                    } catch (Exception){
                        Console.WriteLine("Please enter a number between 0.0 - 2.0.");
                    }
            }

            TeamMember member = new TeamMember(name, skillLevel, courageFactor);

            team.listOfMembers.Add(member);

            PrintBuildTeamMenu(team, bankDifficultyLevel, success, failed);
            }
        }

        public static void Heist(Team team, int bankDifficultyLevel, int successfulRuns, int failedRuns){
            Console.WriteLine("How many trial runs would you like to run?");
            int trialRuns = Int32.Parse(Console.ReadLine());

            int i = 0;
            while(i <= trialRuns){
                Bank BankToHeist = new Bank(bankDifficultyLevel);
            
                int teamSkillLevel = 0;
                team.listOfMembers.ForEach(member => {
                    int skill = member.SkillLevel;
                    teamSkillLevel += skill;
                });
                Console.WriteLine($"\nResults:\n {team.Name}'s Skill Level: {teamSkillLevel}\n Bank's difficulty level: {BankToHeist.BankDifficultyLevel}");
                if(teamSkillLevel >= BankToHeist.BankDifficultyLevel){
                    Console.WriteLine($"\nCongratulations!!! Your team successfully robbed the bank with a skill level of {teamSkillLevel}");
                    successfulRuns ++;
                }else{
                    Console.WriteLine($"\nBoooo! Game Over! You lost, with a team skill level of {teamSkillLevel}, y'all got caught within the first few seconds. Better luck next time!");
                    failedRuns ++;
                }

                i++;
            }
            PrintHeistMenu(team, bankDifficultyLevel, successfulRuns, failedRuns);
        }

        public static void FinalReport(int success, int failed){
            Console.WriteLine($"\nFinal Report\n -------------------------\n Successful Runs: {success} \n Failed Runs: {failed} \n");
        }

        static void Main(string[] args)
        {
            PrintMainMenu();

        }
    }
}
