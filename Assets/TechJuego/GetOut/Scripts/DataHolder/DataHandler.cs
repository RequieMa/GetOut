using UnityEngine;
using TechJuego.GetOut.Monetization;
using TechJuego.GetOut.Sound;

namespace TechJuego.GetOut
{
    public class DataHandler : Singleton<DataHandler>
    {
        protected DataHandler()
        {

        }
        private AdManager adManager;
        private GameState GameState;
        public GameState gameState
        {
            get { return GameState; }
            set
            {
                GameState = value;
                if (adManager == null)
                {
                    adManager = Resources.Load("Monetization/AdManager") as AdManager;
                }
                switch (value)
                {
                    case GameState.CreateLevel:
                        GameEvents.OnLoadLevel?.Invoke();
                        break;
                    case GameState.LevelFail:
                        GameEvents.OnLevelFail?.Invoke();
                        break;
                    case GameState.Contine:
                        if (AdsHandler.Instance.IsRewardAdAvailable())
                        {
                            GameEvents.OnShowContinueGame?.Invoke();
                        }
                        else
                        {
                            gameState = GameState.LevelFail;
                        }
                        break;
                }
                foreach (var item in adManager.adsEvents)
                {
                    if (item.gameEvent == value)
                    {
                        item.calls++;
                        if (item.calls % item.everyLevel == 0)
                        {
                            ShowAds(item.AddToCall);
                        }
                    }
                }
            }
        }
        void ShowAds(AdType adType)
        {
            switch (adType)
            {
                case AdType.Interstitial:
                    AdsHandler.Instance.ShowInterstitial();
                    break;
                case AdType.Reward:
                    AdsHandler.Instance.ShowReward();
                    break;
            }
        }
        public int Highscore
        {
            get
            {
                return PlayerPrefs.GetInt("HIGHSCORE", 0);
            }
            set
            {
                PlayerPrefs.SetInt("HIGHSCORE", value);
            }
        }
    }
}