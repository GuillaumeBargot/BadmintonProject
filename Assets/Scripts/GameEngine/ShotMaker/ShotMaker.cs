using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GameEngine
{
    public static class ShotMaker
    {

        private static readonly float ADVANTAGE_CRIT = 10;
        private static readonly float DISADVANTAGE_FAIL = 10;

        private static readonly float DIFF_CRIT_MODIFIER = 0.5f;
        private static readonly float DIFF_CRIT_MAX = 25;
        private static readonly float DIFF_FAIL_MODIFIER = 1f;
        private static readonly float DIFF_FAIL_MAX = 50;

        private static readonly float DEFENDED_CRIT = -5;
        public static Shot CreateShot(int playerShooting, Shot previousShot, Advantage advantage, ShotType previousShotType){
            PlayerMatchInstance player = MatchEngine.Instance.GetPlayer(playerShooting);
            ShotType type = GenerateShotTypeProbabilities(previousShot.type,player).Calculate();
            ShotCoord from = previousShot.to;
            ShotCoord to = CalculateShotCoord(GenerateShotCoordProbabilities(type,player));
            ShotResultProbabilities shotResultProbabilities = GenerateShotResultProbabilities(to,playerShooting, type, advantage, previousShotType);
            float shotTime = ShotTime.GetTimeForType(type, MatchEngine.Instance.MatchPreferences);
            return new Shot(playerShooting, type, from, to, shotResultProbabilities, false, shotTime);
        }

        public static Serve CreateServe(int playerShooting, Score score){
            PlayerMatchInstance player = MatchEngine.Instance.GetPlayer(playerShooting);
            int points = GetPlayerServingPoints(playerShooting,score);
            ShotCoord from = GetFromForServing(points);
            ShotCoord to = GetToForServing(points);
            ShotType type = ShotType.LONG;
            ShotResultProbabilities shotResultProbabilities = GenerateShotResultProbabilities(playerShooting, type);
            float shotTime = ShotTime.GetTimeForType(type,MatchEngine.Instance.MatchPreferences);
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

        private static ShotResultProbabilities GenerateShotResultProbabilities(ShotCoord to, int playerShooting, ShotType type, Advantage advantage, ShotType previousShotType){
            ShotResultProbabilities probabilities = ShotResultProbabilities.GetShotTypeResultProbabilities(type);
            
            ShotResultAttributesModification(ref probabilities,MatchEngine.Instance.GetPlayer(playerShooting),MatchEngine.Instance.GetOtherPlayer(playerShooting), type, previousShotType);
            ShotResultAdvantageModification(ref probabilities, playerShooting, advantage);
            ShotResultOpposingPlayerModification(ref probabilities, MatchEngine.Instance.GetPlayer(playerShooting), type);
            
            
            
            return probabilities;
        }

        private static void ShotResultAttributesModification(ref ShotResultProbabilities probabilities, PlayerMatchInstance playerShooting, PlayerMatchInstance playerDefending, ShotType shotType, ShotType previousShotType){
            probabilities.AddCrit(GetCritFromAttribute(playerShooting, playerDefending, shotType, previousShotType));
            //You calculate the difference between the atk of the atking player and the def of the defing player
            
        }

        private static int GetCritFromAttribute(PlayerMatchInstance playerShooting, PlayerMatchInstance playerReceiving, ShotType shotType, ShotType previousShotType){
            int atkDiff = GetFinalATKShotDifferential(playerShooting, playerReceiving, shotType, previousShotType);
            if(atkDiff>=0){
                return atkDiff/2;
            }else{
                return atkDiff/4;
            }
        }

        private static int GetFinalATKShotDifferential(PlayerMatchInstance playerShooting, PlayerMatchInstance playerReceiving, ShotType shotType, ShotType previousShotType){
            return GetPureATKShotDifferential(playerShooting, playerReceiving, shotType) + (GetDEFShotDifferential(playerReceiving, playerShooting, previousShotType)/2);
        }

        private static int GetPureATKShotDifferential(PlayerMatchInstance playerShooting, PlayerMatchInstance playerReceiving, ShotType shotType){
            switch(shotType){
                case ShotType.LONG:
                    return playerShooting.GetUsableStats().longATK - playerReceiving.GetUsableStats().longDEF;
                case ShotType.RUSH:
                    return playerShooting.GetUsableStats().rushATK - playerReceiving.GetUsableStats().rushDEF;
                case ShotType.SHORT:
                    return playerShooting.GetUsableStats().shortATK - playerReceiving.GetUsableStats().shortDEF;
                case ShotType.SMASH:
                    return playerShooting.GetUsableStats().smashATK - playerReceiving.GetUsableStats().smashDEF;
            }
            return 0;
        }

        private static int GetDEFShotDifferential(PlayerMatchInstance playerShooting, PlayerMatchInstance playerReceiving, ShotType shotType){
            switch(shotType){
                case ShotType.LONG:
                //if -0, return 0;
                    return Math.Max(playerReceiving.GetUsableStats().longDEF - playerShooting.GetUsableStats().longATK, 0);
                case ShotType.RUSH:
                    return Math.Max(playerReceiving.GetUsableStats().rushDEF - playerShooting.GetUsableStats().rushATK, 0);
                case ShotType.SHORT:
                    return Math.Max(playerReceiving.GetUsableStats().shortDEF - playerShooting.GetUsableStats().shortATK, 0);
                case ShotType.SMASH:
                    return Math.Max(playerReceiving.GetUsableStats().smashDEF - playerShooting.GetUsableStats().smashATK, 0);
            }
            return 0;
        }

        private static void ShotResultAdvantageModification(ref ShotResultProbabilities probabilities, int playerShooting, Advantage advantage){
            if(advantage.Player == playerShooting){
                probabilities.AddCrit(ADVANTAGE_CRIT*advantage.Amount);
            }else{
                probabilities.AddFail(DISADVANTAGE_FAIL*advantage.Amount);
            }
        }
        private static void ShotResultOpposingPlayerModification(ref ShotResultProbabilities probabilities, PlayerMatchInstance playerAttacking, ShotType type){
            // Now it's probably going to be where you put all the effects from the previous attack of the other player such as:
            // "After my smashes, your next attack is worst" or something like that

            //This is where you put the opposing player's defensive traits effect like
            //"The smashes against me are less strong" or something like this.
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
            ShotTypeProbabilities shotTypeProbabilities = ShotTypeProbabilities.GetShotTypeProbabilitiesFollowing(previousType);
            ShotTypePlaystyleModification(ref shotTypeProbabilities, player);
            return shotTypeProbabilities;
        }
        
        public static void ShotTypePlaystyleModification(ref ShotTypeProbabilities shotTypeProbabilities, PlayerMatchInstance shootingPlayer){
            shotTypeProbabilities.MergeWith(shootingPlayer.GetCurrentPlaystyle().shotTypeProbabilities);
        }
    }
}
