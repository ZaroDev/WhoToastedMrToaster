using UnityEngine;
using WhoToastedMrToaster;

public class EndMenu : MonoBehaviour
{
    public GameObject playButton;
    public int sceneIndex = 0;
    public void GoToMainMenu()
    {
        SceneTransitionManager.singleton.GoToSceneAsync(sceneIndex);
        playButton.SetActive(false);
    }
}
