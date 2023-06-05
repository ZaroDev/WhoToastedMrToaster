using UnityEngine;

namespace WhoToastedMrToaster
{
    public class FinalLever : MonoBehaviour
    {
        [SerializeField]
        private GameObject warningMarker;

        [SerializeField]
        private SpotLightController controller;


        private bool canFinish = false;

        private void OnEnable()
        {
            GameManager.OnCanFinishGame += FinishedGame;
        }

        private void OnDisable()
        {
            GameManager.OnCanFinishGame -= FinishedGame;
        }
        private void FinishedGame()
        {
            canFinish = true;
        }

        public void OnDeactivate()
        {
            warningMarker?.SetActive(false);
        }
        public void OnActivate()
        {
            if (canFinish)
            {
                // 0 == Frank Freezer
                // 1 == Mike Microwave
                // 2 == Blake Blender

                switch (controller.current)
                {
                    case 0:
                        {
                            SceneTransitionManager.singleton.GoToSceneAsync(2);
                        }
                        break;
                    case 1:
                        {
                            SceneTransitionManager.singleton.GoToSceneAsync(3);
                        }
                        break;
                    case 2:
                        {
                            SceneTransitionManager.singleton.GoToSceneAsync(4);
                        }
                        break;
                }
                return;
            }
            else
            {
                warningMarker?.SetActive(true);
            }

        }
    }
}