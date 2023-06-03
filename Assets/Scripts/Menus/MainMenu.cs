using UnityEngine;
using UnityEngine.SceneManagement;

namespace WhoToastedMrToaster
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject quitButton = null;
        public GameObject quitModal = null;

        private void Awake()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                quitButton.SetActive(false);
            }
            quitModal.SetActive(false);
        }

        public void StartGame()
        {
            SceneManager.LoadScene("MainScene");
        }

        public void ShowQuit()
        {
            quitModal.SetActive(true);
        }

        public void QuitModalNo()
        {
            quitModal.SetActive(false);
        }
        public void QuitModalYes()
        {
            Application.Quit();
        }
    }
}
