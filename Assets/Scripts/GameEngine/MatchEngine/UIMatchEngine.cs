using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameEngine
{
    public partial class MatchEngine
    {

        [SerializeField]
        ScoreDisplay scoreDisplay;

        [SerializeField]
        PlayButton playButton;

        [SerializeField]
        AdvantageBar advantageBar;

        [SerializeField]
        MessageSystem messageSystem;

        
        public void PlayOrPause()
        {
            if (isPaused)
            {
                Play();
            }
            else
            {
                Pause();
            }
        }

        private void Pause()
        {
            isPaused = true;
            playButton.OnStatePaused();
        }

        private void Play()
        {
            isPaused = false;
            playButton.OnStatePlaying();
        }

        private void UpdateAdvantageUI(Advantage advantage){
            advantageBar.UpdateAdvantage(advantage);
        }

        private void ResetAdvantageUI(){
            advantageBar.Reset();
        }

        private void CritMessage(int playerShooting){
            messageSystem.CritMessage(playerShooting);
        }
    }
}
