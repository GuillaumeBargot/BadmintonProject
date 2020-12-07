using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{
    public static class ShotMaker
    {

        private static readonly float ADVANTAGE_CRIT = 10;
        private static readonly float DISADVANTAGE_FAIL = 10;

        private static readonly float DEFENDED_CRIT = -5;
        public static Shot CreateShot(int playerShooting, Shot previousShot, Advantage advantage){
            PlayerMatchInstance player = MatchEngine.Instance.GetPlayer(playerShooting);
            ShotType type = GenerateShotTypeProbabilities(previousShot.type,player).Calculate();
            ShotCoord from = previousShot.to;
            ShotCoord to = CalculateShotCoord(GenerateShotCoordProbabilities(type,player));
            ShotResultProbabilities shotResultProbabilities = GenerateShotResultProbabilities(to,playerShooting, type, advantage);
            float shotTime = ShotTime.GetTimeForType(type);
            return new Shot(playerShooting, type, from, to, shotResultProbabilities, false, shotTime);
        }

        public static Serve CreateServe(int playerShooting, Score score){
            PlayerMatchInstance player = MatchEngine.Instance.GetPlayer(playerShooting);
            int points = GetPlayerServingPoints(playerShooting,score);
            ShotCoord from = GetFromForServing(points);
            ShotCoord to = GetToForServing(points);
            ShotType type = ShotType.LONG;
            ShotResultProbabilities shotResultProbabilities = GenerateShotResultProbabilities(playerShooting, type);
            float shotTime = ShotTime.GetTimeForType(type);
            return new Serve(playerShooting, type, from, to, shotResultProbabilities, shotTime);
        }

        //------------------------------------------------------------------------------------------------------------------
        //                                                  SERVE
        //------------------------------------------------------------------------------------------------------------------

        private static int GetPlayerServingPoints(int playerServing, Score score){
            return (playerServing==0)?(score.GetCurrentSetScore().Item1):(score.GetCurrentSetScore().Item2);
        }

        private static ShotCoord GetFromForServing(int points){
            return (points%2==0)?new ShotCoord((2,1)):new ShotCoord((0,1));
        }

        private static ShotCoord GetToForServing(int points){
            return (points%2==0)?new ShotCoord((2,2)):new ShotCoord((0,2));
        }

        public static (ShotCoord, ShotCoord) GetPlayerIntialPositions(int playerServing, Score score){
            int points = GetPlayerServingPoints(playerServing, score);
            return (GetFromForServing(points), GetToForServing(points));
        }


        //------------------------------------------------------------------------------------------------------------------
        //                                                  SHOT RESULTS
        //------------------------------------------------------------------------------------------------------------------

        private static ShotResultProbabilities GenerateShotResultProbabilities(int playerShooting, ShotType type){
            return ShotResultProbabilities.GetShotTypeResultProbabilities(type);
        }

        private static ShotResultProbabilities GenerateShotResultProbabilities(ShotCoord to, int playerShooting, ShotType type, Advantage advantage){
            ShotResultProbabilities typeProbabilities = ShotResultProbabilities.GetShotTypeResultProbabilities(type);
            

            ShotResultProbabilities resultingProbabilities = ShotResultAdvantageModification(typeProbabilities, playerShooting, advantage);
            ShotResultProbabilities afterAttackProbabilities = ShotResultAttackModification(typeProbabilities, MatchEngine.Instance.GetPlayer(playerShooting), type);
            ShotResultProbabilities afterDefenseProbabilities = ShotResultDefenseModification(resultingProbabilities,MatchEngine.Instance.GetOtherPlayer(playerShooting), type);
            
            return afterDefenseProbabilities;
        }

        private static ShotResultProbabilities ShotResultAdvantageModification(ShotResultProbabilities probabilities, int playerShooting, Advantage advantage){
            ShotResultProbabilities result = probabilities;
            if(advantage.Player == playerShooting){
                result.AddCrit(ADVANTAGE_CRIT*advantage.Amount);
            }else{
                result.AddFail(DISADVANTAGE_FAIL*advantage.Amount);
            }
            return result;
        }

        private static ShotResultProbabilities ShotResultAttackModification(ShotResultProbabilities probabilities, PlayerMatchInstance playerAttacking, ShotType type){
            ShotResultProbabilities result = probabilities;
            switch(type){
                case ShotType.LONG:
                    result.AddCrit(playerAttacking.GetModifierList().GetModifier(ModifierName.ADDED_CRIT_ON_LONG));
                break;
                case ShotType.SMASH:
                    Debug.Log("ATTACKING SMASH UPGRADE before: " + result.Crit);
                    result.AddCrit(playerAttacking.GetModifierList().GetModifier(ModifierName.ADDED_CRIT_ON_SMASH));
                    Debug.Log("ATTACKING SMASH UPGRADE before: " + result.Crit);
                break;
                case ShotType.RUSH:
                    result.AddCrit(playerAttacking.GetModifierList().GetModifier(ModifierName.ADDED_CRIT_ON_RUSH));
                break;
                case ShotType.SHORT:
                    result.AddCrit(playerAttacking.GetModifierList().GetModifier(ModifierName.ADDED_CRIT_ON_SHORT));
                break;
            }
            return result;
        }

        private static ShotResultProbabilities ShotResultDefenseModification(ShotResultProbabilities probabilities, PlayerMatchInstance playerDefending, ShotType type){
            ShotResultProbabilities result = probabilities;
            /*if(defensiveStrategy.IsDefended(to)){
                result.AddCrit(DEFENDED_CRIT);
            }*/
            return result;
        }

        //------------------------------------------------------------------------------------------------------------------
        //                                                  SHOT COORDS
        //------------------------------------------------------------------------------------------------------------------

        public static ShotCoordProbabilities GenerateShotCoordProbabilities(ShotType type, PlayerMatchInstance player)
        {
            ShotCoordProbabilities shotTypeTendencies = GetCoordTendencies(type);
            
            ShotCoordProbabilities playerTendencies = player.ShotCoordTendencies();
          
            ShotCoordProbabilities resultingTendencies = ShotCoordProbabilities.Multiply(shotTypeTendencies, playerTendencies);
            return  resultingTendencies;
        }

        private static ShotCoord CalculateShotCoord(ShotCoordProbabilities tendencies){
            return tendencies.Calculate();
        }

        public static ShotCoordProbabilities GetCoordTendencies(ShotType type){
            return ShotCoordProbabilities.GetShotTypeCoordProbabilities(type);
        }

        //------------------------------------------------------------------------------------------------------------------
        //                                                  SHOT TYPES
        //------------------------------------------------------------------------------------------------------------------

        public static ShotTypeProbabilities GenerateShotTypeProbabilities(ShotType previousType, PlayerMatchInstance player){
            return ShotTypeProbabilities.GetShotTypeProbabilitiesFollowing(previousType);
        }
        
    }
}
