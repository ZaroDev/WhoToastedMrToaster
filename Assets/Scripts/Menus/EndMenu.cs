using UnityEngine;
using WhoToastedMrToaster;

public class EndMenu : MonoBehaviour
{
    public GameObject playButton;

    public void GoToMainMenu()
    {
        SceneTransitionManager.singleton.GoToSceneAsync(0);
        playButton.SetActive(false);
    }
}
