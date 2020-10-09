using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{
    public static class ShotMaker
    {
        public static Shot CreateShot(int playerShooting, Shot previousShot){
            PlayerMatchInstance player = MatchEngine.Instance.GetPlayer(playerShooting);
            ShotType type = player.ShotTypeProbabilities().Calculate();
            ShotCoord from = previousShot.to;
            ShotCoord to = CalculateShotCoord(GenerateShotCoordProbabilities(type,player));
            ShotResultProbabilities shotResultProbabilities = GenerateShotResultProbabilities(type);
            return new Shot(playerShooting, type, from, to, shotResultProbabilities, false);
        }

        public static Serve CreateServe(int playerShooting, Score score){
            int points = GetPlayerServingPoints(playerShooting,score);
            ShotCoord from = GetFromForServing(points);
            ShotCoord to = GetToForServing(points);
            ShotType type = ShotType.LONG;
            ShotResultProbabilities shotResultProbabilities = GenerateShotResultProbabilities(type);
            return new Serve(playerShooting, type, from, to, shotResultProbabilities);
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

        private static ShotResultProbabilities GenerateShotResultProbabilities(ShotType type){
            return ShotResultProbabilities.GetShotTypeResultProbabilities(type);
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
