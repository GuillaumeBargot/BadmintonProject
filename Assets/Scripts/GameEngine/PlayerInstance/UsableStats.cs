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
            int STRENGTH = 20 * playerStats.strength;
            int INTELLIGENCE = 10 * playerStats.intelligence;
            int DEXTERITY = 5 * playerStats.dexterity;
            int ENDURANCE = 25 * playerStats.endurance;
            
            //calculate the modifier lists that are needed here
            longATK = STRENGTH + INTELLIGENCE + DEXTERITY + ENDURANCE;
        }

        private void CalculateLongDEF(PlayerStats playerStats,ModifierList modifierList){
            int STRENGTH = 15 * playerStats.strength;
            int REFLEXES = 10 * playerStats.reflexes;
            int INTELLIGENCE = 10 * playerStats.intelligence;
            int ENDURANCE = 25 * playerStats.endurance;
            
            //calculate the modifier lists that are needed here
            longDEF = STRENGTH + REFLEXES + INTELLIGENCE + ENDURANCE;
        }

        private void CalculateRushATK(PlayerStats playerStats,ModifierList modifierList){
            int REFLEXES = 20 * playerStats.reflexes;
            int SPEED = 10 * playerStats.speed;
            int DEXTERITY = 20 * playerStats.dexterity;
            int INTELLIGENCE = 10 * playerStats.intelligence;
            
            //calculate the modifier lists that are needed here
            rushATK = REFLEXES + SPEED + DEXTERITY + INTELLIGENCE;
        }

        private void CalculateRushDEF(PlayerStats playerStats,ModifierList modifierList){
            int REFLEXES = 20 * playerStats.reflexes;
            int DEXTERITY = 15 * playerStats.dexterity;
            int SPEED = 15 * playerStats.speed;
            int INTELLIGENCE = 10 * playerStats.intelligence;
            
            //calculate the modifier lists that are needed here
            rushDEF = REFLEXES + DEXTERITY + SPEED + INTELLIGENCE;
        }

        private void CalculateSmashATK(PlayerStats playerStats,ModifierList modifierList){
            int STRENGTH = 30 * playerStats.strength;
            int SPEED = 10 * playerStats.speed;
            int DEXTERITY = 10 * playerStats.dexterity;
            int ENDURANCE = 10 * playerStats.endurance;
            
            //calculate the modifier lists that are needed here
            smashATK = STRENGTH + SPEED + DEXTERITY + ENDURANCE;
        }

        private void CalculateSmashDEF(PlayerStats playerStats,ModifierList modifierList){
            int REFLEXES = 25 * playerStats.reflexes;
            int SPEED = 15 * playerStats.speed;
            int DEXTERITY = 10 * playerStats.dexterity;
            int INTELLIGENCE = 10 * playerStats.intelligence;
            
            //calculate the modifier lists that are needed here
            smashDEF = REFLEXES + SPEED + DEXTERITY + INTELLIGENCE;
        }

        private void CalculateShortATK(PlayerStats playerStats,ModifierList modifierList){
            int DEXTERITY = 15 * playerStats.dexterity;
            int INTELLIGENCE = 25 * playerStats.intelligence;
            int SPEED = 15 * playerStats.speed;
            int REFLEXES = 5 * playerStats.reflexes;
            
            //calculate the modifier lists that are needed here
            longATK = DEXTERITY + INTELLIGENCE + SPEED + REFLEXES;
        }

        private void CalculateShortDEF(PlayerStats playerStats,ModifierList modifierList){
            int SPEED = 20 * playerStats.speed;
            int REFLEXES = 10 * playerStats.reflexes;
            int DEXTERITY = 15 * playerStats.dexterity;
            int ENDURANCE = 15 * playerStats.endurance;
            
            //calculate the modifier lists that are needed here
            longATK = SPEED + REFLEXES + DEXTERITY + ENDURANCE;
        }
    }
}
