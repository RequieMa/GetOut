using TMPro;
using UnityEngine;
using UnityEngine.UI;
using GetOut.Utils;
using System.Collections;
using UnityEngine.SceneManagement;

namespace GetOut
{
    public class SplashScreen : MonoBehaviour
    {
        // Time To wait Afer Scene is Loaded
        [SerializeField] private float time;

        private AsyncOperation scene;
        //Loading Progress Text
        [SerializeField] private TextMeshProUGUI m_LoadingText;
        [SerializeField] private Slider m_LoadinImage;

        // Start is called before the first frame update
        /// <summary>
        ///  Start To load Menu Scene
        /// </summary>
        /// <returns></returns>
        IEnumerator Start()
        {
            scene = SceneManager.LoadSceneAsync("Menu");
            scene.allowSceneActivation = false;
            while (!scene.isDone)
            {
                if (scene.progress >= .9f)
                {
                    StartCoroutine(Utility.ChangeValue(0, 100, time, (value) =>
                    {
                        progrss = value;
                        if (value >= 100)
                        {
                            scene.allowSceneActivation = true;
                        }
                    }));
                    break;
                }
                yield return null;
            }
        }
        float progrss;
        private void Update()
        {
            m_LoadingText.text = (int)progrss + "%";
            m_LoadinImage.value = (progrss / 100);
        }
    }
}