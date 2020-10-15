using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{
    public static class ShotMaker
    {

        private static readonly float ADVANTAGE_CRIT = 10;
        private static readonly float DISADVANTAGE_FAIL = 10;
        public static Shot CreateShot(int playerShooting, Shot previousShot, Advantage advantage){
            PlayerMatchInstance player = MatchEngine.Instance.GetPlayer(playerShooting);
            ShotType type = player.ShotTypeProbabilities().Calculate();
            ShotCoord from = previousShot.to;
            ShotCoord to = CalculateShotCoord(GenerateShotCoordProbabilities(type,player));
            ShotResultProbabilities shotResultProbabilities = GenerateShotResultProbabilities(playerShooting, type, advantage);
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

        private static ShotResultProbabilities GenerateShotResultProbabilities(int playerShooting, ShotType type, Advantage advantage){
            ShotResultProbabilities typeProbabilities = ShotResultProbabilities.GetShotTypeResultProbabilities(type);
            
            if(advantage.Player == playerShooting){
                typeProbabilities.AddCrit(ADVANTAGE_CRIT*advantage.Amount);
            }else{
                typeProbabilities.AddFail(DISADVANTAGE_FAIL*advantage.Amount);
            }
            return typeProbabilities;
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

        //------------------------------------------------------------------------------------------------------------------
        //                                                  SHOT TYPES
        //------------------------------------------------------------------------------------------------------------------

        public static ShotCoordProbabilities GetCoordTendencies(ShotType type){
            return ShotCoordProbabilities.GetShotTypeCoordProbabilities(type);
        }
    }
}
