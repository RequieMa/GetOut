using TMPro;
using UnityEngine;
using GetOut.Utils;
using UnityEngine.UI;
namespace GetOut
{
    public class LevelFailPanel : MonoBehaviour
    {
        public TextMeshProUGUI m_HighScore;
        public TextMeshProUGUI m_Score;
        public Button m_RestartButton;
        public Button m_HomeButton;
        private void OnEnable()
        {
            m_Score.text = GameManager.Instance.Score.ToString();
                if (GameManager.Instance.Score > DataHandler.Instance.Highscore)
                {
                    DataHandler.Instance.Highscore = GameManager.Instance.Score;
                }
            m_HighScore.text = DataHandler.Instance.Highscore.ToString();
            Utility.SetButton(m_RestartButton, OnClickRestartButton);
            Utility.SetButton(m_HomeButton, OnClickHomeButton);
        }
        void OnClickRestartButton()
        {
            SceneLoader.RestartScene();
        }
        void OnClickHomeButton()
        {
            SceneLoader.LoadScene("Menu");
        }
    }
}