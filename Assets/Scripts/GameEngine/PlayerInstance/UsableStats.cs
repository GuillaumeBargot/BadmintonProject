using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEngine
{
    public class UsableStats
    {
        //Different stats used to measure efficiency of each shot/defense during the game
        public int longATK;
        public int longDEF;
        public int rushATK;
        public int rushDEF;
        public int smashATK;
        public int smashDEF;
        public int shortATK;
        public int shortDEF;

        public UsableStats(PlayerStats playerStats,ModifierList modifierList){
            CalculateLongATK(playerStats,modifierList);
            CalculateLongDEF(playerStats, modifierList);
            CalculateRushATK(playerStats,modifierList);
            CalculateRushDEF(playerStats, modifierList);
            CalculateSmashATK(playerStats,modifierList);
            CalculateSmashDEF(playerStats, modifierList);
            CalculateShortATK(playerStats,modifierList);
            CalculateShortDEF(playerStats, modifierList);
        }

        private void CalculateLongATK(PlayerStats playerStats,ModifierList modifierList){
            int STRENGTH = 20 * playerStats.Strength;
            int INTELLIGENCE = 10 * playerStats.Intelligence;
            int DEXTERITY = 5 * playerStats.Dexterity;
            int ENDURANCE = 25 * playerStats.Endurance;
            
            //calculate the modifier lists that are needed here
            longATK = STRENGTH + INTELLIGENCE + DEXTERITY + ENDURANCE;
        }

        private void CalculateLongDEF(PlayerStats playerStats,ModifierList modifierList){
            int STRENGTH = 15 * playerStats.Strength;
            int REFLEXES = 10 * playerStats.Reflexes;
            int INTELLIGENCE = 10 * playerStats.Intelligence;
            int ENDURANCE = 25 * playerStats.Endurance;
            
            //calculate the modifier lists that are needed here
            longDEF = STRENGTH + REFLEXES + INTELLIGENCE + ENDURANCE;
        }

        private void CalculateRushATK(PlayerStats playerStats,ModifierList modifierList){
            int REFLEXES = 20 * playerStats.Reflexes;
            int SPEED = 10 * playerStats.Speed;
            int DEXTERITY = 20 * playerStats.Dexterity;
            int INTELLIGENCE = 10 * playerStats.Intelligence;
            
            //calculate the modifier lists that are needed here
            rushATK = REFLEXES + SPEED + DEXTERITY + INTELLIGENCE;
        }

        private void CalculateRushDEF(PlayerStats playerStats,ModifierList modifierList){
            int REFLEXES = 20 * playerStats.Reflexes;
            int DEXTERITY = 15 * playerStats.Dexterity;
            int SPEED = 15 * playerStats.Speed;
            int INTELLIGENCE = 10 * playerStats.Intelligence;
            
            //calculate the modifier lists that are needed here
            rushDEF = REFLEXES + DEXTERITY + SPEED + INTELLIGENCE;
        }

        private void CalculateSmashATK(PlayerStats playerStats,ModifierList modifierList){
            int STRENGTH = 30 * playerStats.Strength;
            int SPEED = 10 * playerStats.Speed;
            int DEXTERITY = 10 * playerStats.Dexterity;
            int ENDURANCE = 10 * playerStats.Endurance;
            
            //calculate the modifier lists that are needed here
            smashATK = STRENGTH + SPEED + DEXTERITY + ENDURANCE;
        }

        private void CalculateSmashDEF(PlayerStats playerStats,ModifierList modifierList){
            int REFLEXES = 25 * playerStats.Reflexes;
            int SPEED = 15 * playerStats.Speed;
            int DEXTERITY = 10 * playerStats.Dexterity;
            int INTELLIGENCE = 10 * playerStats.Intelligence;
            
            //calculate the modifier lists that are needed here
            smashDEF = REFLEXES + SPEED + DEXTERITY + INTELLIGENCE;
        }

        private void CalculateShortATK(PlayerStats playerStats,ModifierList modifierList){
            int DEXTERITY = 15 * playerStats.Dexterity;
            int INTELLIGENCE = 25 * playerStats.Intelligence;
            int SPEED = 15 * playerStats.Speed;
            int REFLEXES = 5 * playerStats.Reflexes;
            
            //calculate the modifier lists that are needed here
            longATK = DEXTERITY + INTELLIGENCE + SPEED + REFLEXES;
        }

        private void CalculateShortDEF(PlayerStats playerStats,ModifierList modifierList){
            int SPEED = 20 * playerStats.Speed;
            int REFLEXES = 10 * playerStats.Reflexes;
            int DEXTERITY = 15 * playerStats.Dexterity;
            int ENDURANCE = 15 * playerStats.Endurance;
            
            //calculate the modifier lists that are needed here
            longATK = SPEED + REFLEXES + DEXTERITY + ENDURANCE;
        }
    }
}
