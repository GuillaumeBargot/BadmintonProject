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
    }
}
