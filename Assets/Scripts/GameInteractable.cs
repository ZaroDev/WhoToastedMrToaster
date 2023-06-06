using UnityEngine;

namespace WhoToastedMrToaster
{
    public class GameInteractable : MonoBehaviour
    {
        public GameObject animToActivate = null;

        private bool isActivated = false;


        public void Activate()
        {
            if (isActivated)
                return;

            animToActivate.SetActive(true);
            isActivated = true;
        }
    }
}
