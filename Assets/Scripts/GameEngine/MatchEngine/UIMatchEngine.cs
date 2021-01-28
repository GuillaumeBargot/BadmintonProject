using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameEngine
{
    public partial class MatchEngine
    {

        [SerializeField]
        AdvantageBar advantageBar;

        [SerializeField]
        MessageSystem messageSystem;

        [SerializeField]
        PlaystylePopup playstylePopupPrefab;

        [SerializeField]
        TextMeshProUGUI p1PlaystyleText;

        [SerializeField]
        TextMeshProUGUI cpuPlaystyleText;

        [SerializeField]
        MatchUIEventReader uiEventReader;


        private void Start()
        {
            uiEventReader.playstyleChangedEvent += OnPlaystyleChanged;
            uiEventReader.advantageUpdatedEvent += UpdateAdvantageUI;
            uiEventReader.advantageResetEvent += ResetAdvantageUI;
            uiEventReader.critEvent += CritMessage;

            //Kick the event for good mesure:
            uiEventReader.OnPlaystyleChanged(0);
            uiEventReader.OnPlaystyleChanged(1);
        }

        private void OnDestroy()
        {
            uiEventReader.playstyleChangedEvent -= OnPlaystyleChanged;
            uiEventReader.advantageUpdatedEvent -= UpdateAdvantageUI;
            uiEventReader.advantageResetEvent -= ResetAdvantageUI;
            uiEventReader.critEvent -= CritMessage;
        }

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

        public void Pause()
        {
            if (!isPaused)
            {
                isPaused = true;
                uiEventReader.OnPaused(true);
            }
        }

        private void Play()
        {
            isPaused = false;
            uiEventReader.OnPaused(false);
        }

        private void UpdateAdvantageUI(Advantage advantage)
        {
            advantageBar.UpdateAdvantage(advantage);
        }

        private void ResetAdvantageUI()
        {
            advantageBar.Reset();
        }

        private void CritMessage(int playerShooting)
        {
            messageSystem.CritMessage(playerShooting);
        }

        private void RefreshScoreRecap()
        {
            score.LogScore();
            uiEventReader.OnScoreChanged(score.GetScoreRecap());
            //scoreDisplay.SetScoreRecap(score.GetScoreRecap());
        }

        public void OnPlaystyleClick()
        {
            PopupSystem.Instance.InstantiatePopup<PlaystylePopup>(playstylePopupPrefab);
        }

        private void OnPlaystyleChanged(int player)
        {
            Playstyle playstyle = GetPlayer(player).GetCurrentPlaystyle();
            if (player == 0)
            {
                ChangeP1PlaystyleText(playstyle);
            }
            else
            {
                ChangeCPUPlaystyleText(playstyle);
            }
        }

        private void ChangeP1PlaystyleText(Playstyle playstyle)
        {
            p1PlaystyleText.SetText(playstyle.id);
        }

        private void ChangeCPUPlaystyleText(Playstyle playstyle)
        {
            cpuPlaystyleText.SetText(playstyle.id);
        }
    }
}
