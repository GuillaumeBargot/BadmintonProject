using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{
    public partial class MatchEngine : MonoBehaviour
    {
        private static MatchEngine instance;
        public static MatchEngine Instance
        {
            get
            {
                return instance;
            }
        }
        PlayerMatchInstance player;

        PlayerMatchInstance cpu;

        Score score;

        [SerializeField]
        Field field;

        private bool isPaused = true;

        public PointHistory pointHistory;

        void Awake()
        {
            // if the singleton hasn't been initialized yet
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
            }

            instance = this;

            player = new PlayerMatchInstance("JeanPlayer");
            cpu = new PlayerMatchInstance("EdouardCPU");
            pointHistory = new PointHistory();
            StartGame();
            

        }





        private int OtherPlayer(int player)
        {
            return player == 0 ? 1 : 0;
        }



        public PlayerMatchInstance GetPlayer(int playerID)
        {
            return (playerID == 0) ? player : cpu;
        }

        public PlayerMatchInstance GetOtherPlayer(int playerID){
            return (playerID == 0) ? cpu : player;
        }

        private void FieldShot(int playerShooting, ShotCoord from, ShotCoord to, ShotType type, float shotTime){
            field.DoAShot(from.Index, to.Index, playerShooting, type, shotTime);
        }

        private void PositionTwoPlayersBeforeServe(int playerServing, (ShotCoord,ShotCoord) positions){
            field.PositionPlayers(playerServing, positions);
        }

    }
}
