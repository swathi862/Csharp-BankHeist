using System;

namespace heist{

    public class Bank{
        private int Luck {get; set;}

        public int BankDifficultyLevel;

        public Bank(int bankLevel){
            Luck = new Random().Next(-10, 10);
            BankDifficultyLevel = bankLevel + Luck;
        }
    }
}