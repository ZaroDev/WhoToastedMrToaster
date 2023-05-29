using UnityEngine;

namespace WhoToastedMrToaster
{
    public class PushButtonActions : MonoBehaviour
    {
        public int index;
        public SpotLightController spotLight;
        public void OnClick()
        {
            spotLight.SetMovement(index);
        }
    }
}
