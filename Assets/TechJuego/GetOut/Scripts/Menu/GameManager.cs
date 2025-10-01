using UnityEngine;
namespace TechJuego.GetOut
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public Ball m_Ball;
        public Effect m_Effect;
        public int Score;
        public bool isGameEnded;
        public Color[] m_BgColor;
        public GameObject m_LooseEffect;
        private void Awake()
        {
            Instance = this;
            isGameEnded = false;
            Camera.main.backgroundColor = m_BgColor[UnityEngine.Random.Range(0, m_BgColor.Length)];
        }
        private void Start()
        {
            DataHandler.Instance.gameState = GameState.CreateLevel;

        }
    }
}