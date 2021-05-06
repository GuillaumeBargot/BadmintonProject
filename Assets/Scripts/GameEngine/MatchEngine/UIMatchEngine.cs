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
        EndMatchPopup endMatchPopupPrefab;

        [SerializeField]
        TextMeshProUGUI p1PlaystyleText;

        [SerializeField]
        TextMeshProUGUI cpuPlaystyleText;

        [SerializeField]
        MatchEventReader eventReader;

        [SerializeField]
        TopInformationBar topInformationBar;


        private void Start()
        {
            eventReader.playstyleChangedEvent += OnPlaystyleChanged;
            eventReader.advantageUpdatedEvent += UpdateAdvantageUI;
            eventReader.advantageResetEvent += ResetAdvantageUI;
            eventReader.critEvent += CritMessage;
            eventReader.matchOver += OnMatchOver;

            //Kick the event for good mesure:
            eventReader.OnPlaystyleChanged(0);
            eventReader.OnPlaystyleChanged(1);

            topInformationBar.Init(player,cpu);

            RefreshScoreRecap();
        }

        private void OnDestroy()
        {
            eventReader.playstyleChangedEvent -= OnPlaystyleChanged;
            eventReader.advantageUpdatedEvent -= UpdateAdvantageUI;
            eventReader.advantageResetEvent -= ResetAdvantageUI;
            eventReader.critEvent -= CritMessage;
            eventReader.matchOver -= OnMatchOver;
            aIBehavior.OnDestroy();
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
                eventReader.OnPaused(true);
            }
        }

        private void Play()
        {
            isPaused = false;
            eventReader.OnPaused(false);
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
            scoreManager.LogScore();
            eventReader.OnScoreChanged(scoreManager.Score);
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
