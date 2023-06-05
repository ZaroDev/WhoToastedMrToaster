using UnityEngine;

namespace WhoToastedMrToaster
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject quitButton = null;
        public GameObject quitModal = null;
        public GameObject playButton = null;

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
            HideAll();
            SceneTransitionManager.singleton.GoToSceneAsync(1);
        }

        public void HideAll()
        {
            playButton.SetActive(false);
            quitButton.SetActive(false);
            quitModal.SetActive(false);
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
