using TMPro;
using UnityEngine;
using UnityEngine.UI;
using GetOut.Monetization;
using GetOut.Sound;

namespace GetOut
{
    public class MainMenuPanel : MonoBehaviour
    {
        public static MainMenuPanel Instance;

        public MenuPanel m_MenuPanel;
        public SettingsPannel m_SettingPanel;
        public PrivacyPolicy m_privacyPolicy;

        private void Awake()
        {
            Instance = this;
        }

        private void OnEnable()
        {
            DataHandler.Instance.gameState = GameState.Menu;
            m_MenuPanel.gameObject.SetActive(true);
            m_SettingPanel.gameObject.SetActive(false);

            if (MonetizationEvents.HasConcentSet())
            {
                m_privacyPolicy.gameObject.SetActive(false);
            }
            else
            {
                m_privacyPolicy.gameObject.SetActive(true);
            }

            SoundEvents.OnPlayLoopSound?.Invoke("BGMUSIC");
        }
    }
}