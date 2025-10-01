using TMPro;
using UnityEngine;
using UnityEngine.UI;
using GetOut.Utils;
using GetOut.Sound;
using UnityEngine.SceneManagement;

namespace GetOut
{
    public class InGameUi : MonoBehaviour
    {
        [SerializeField] private GameObject m_HUDUI;
        [SerializeField] private Button m_SettingButton;
        [SerializeField] private RateUsPopup m_RateUsPopup;
        [SerializeField] private ContinuePanel m_ContinuePanel;
        [SerializeField] private TextMeshProUGUI m_CurrentScore;
        [SerializeField] private LevelFailPanel m_LevelFailPanel;
        [SerializeField] private InGameSettingsPanel m_InGameSettingsPanel;
        private void Awake()
        {
            m_InGameSettingsPanel.gameObject.SetActive(false);
            m_LevelFailPanel.gameObject.SetActive(false);
            m_ContinuePanel.gameObject.SetActive(false);
            m_RateUsPopup.gameObject.SetActive(false);
            m_HUDUI.gameObject.SetActive(true);
        }
        private void OnEnable()
        {
            GameEvents.OnLevelFail += GameEvents_OnLevelFail;
            GameEvents.OnShowRateUs += GameEvents_OnShowRateUs;
            GameEvents.OnLevelUpdate += GameEvents_OnLevelUpdate;
            GameEvents.OnShowContinueGame += GameEvents_OnShowContinueGame;
            Utility.SetButton(m_SettingButton, OnClickSettingButton);
        }
        private void OnDisable()
        {
            GameEvents.OnLevelFail -= GameEvents_OnLevelFail;
            GameEvents.OnShowRateUs -= GameEvents_OnShowRateUs;
            GameEvents.OnLevelUpdate -= GameEvents_OnLevelUpdate;
            GameEvents.OnShowContinueGame -= GameEvents_OnShowContinueGame;
        }
        private void GameEvents_OnShowContinueGame()
        {
            m_LevelFailPanel.gameObject.SetActive(false);
            m_ContinuePanel.gameObject.SetActive(true);
        }
        void OnClickSettingButton()
        {
            m_InGameSettingsPanel.gameObject.SetActive(true);
            SoundEvents.OnPlaySingleShotSound?.Invoke("Click");
        }
        private void GameEvents_OnShowRateUs()
        {
            m_RateUsPopup.gameObject.SetActive(true);
        }
        private void GameEvents_OnLevelUpdate()
        {
            GameManager.Instance.Score += 1;
            m_CurrentScore.text = GameManager.Instance.Score.ToString();
        }
        private void GameEvents_OnLevelFail()
        {
            m_LevelFailPanel.gameObject.SetActive(true);
        }
    }
}