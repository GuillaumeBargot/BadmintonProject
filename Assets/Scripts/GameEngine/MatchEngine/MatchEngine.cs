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

        PointHistory pointHistory;

        ScoreManager scoreManager;

        [SerializeField]
        Field field;

        [SerializeField]
        MatchScene scene;

        private bool isPaused = true;

        public PointHistory PointHistory{
            get{
                return SaveData.current.calendar.GetTournament().currentMatch.pointHistory;
            }
        }

        private AIBehavior aIBehavior;

        [SerializeField]
        private MatchPreferences matchPreferences;

        public MatchPreferences MatchPreferences{
            get{
                return matchPreferences;
            }
        }

        void Awake()
        {
            // if the singleton hasn't been initialized yet
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
            }

            instance = this;

            if(SaveData.CurrentMatchExists){
                player = new PlayerMatchInstance(SaveData.current.playerSave);
                cpu = new PlayerMatchInstance(SaveData.current.calendar.GetTournament().currentMatch.cpuPlayer);
            }else{
                player = new PlayerMatchInstance("JeanPlayer");
                cpu = new PlayerMatchInstance("EdouardCPU");
            }

            pointHistory = new PointHistory();
            
            aIBehavior = new EasyAIBehavior(eventReader);
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

        public PlayerMatchInstance GetOtherPlayer(int playerID)
        {
            return (playerID == 0) ? cpu : player;
        }

        public PlayerMatchInstance GetCPU()
        {
            return cpu;
        }

        private void FieldShot(int playerShooting, ShotCoord from, ShotCoord to, ShotType type, float shotTime)
        {
            field.DoAShot(from.Index, to.Index, playerShooting, type, shotTime);
        }

        private void PositionTwoPlayersBeforeServe(int playerServing, (ShotCoord, ShotCoord) positions)
        {
            field.PositionPlayers(playerServing, positions);
        }

        public void OnMatchOver(){
            Pause();
            //Todo create a popup EndMatchPopup with a recap, a space to put all that you've earned and a "Finish" button that takes you back
            //to the tournamenet page / main menu
            EndMatchPopup popup = PopupSystem.Instance.InstantiatePopup<EndMatchPopup>(endMatchPopupPrefab);
            Debug.Log("Player " + scoreManager.WhoWon() + " won!");
            bool won = (scoreManager.WhoWon()==0);
            popup.Init(won,()=>scene.Back());

        }
    }
}
