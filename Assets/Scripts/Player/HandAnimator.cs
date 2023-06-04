using UnityEngine;
using UnityEngine.InputSystem;

namespace WhoToastedMrToaster
{
    public class HandAnimator : MonoBehaviour
    {
        [SerializeField]
        private InputActionProperty triggerAction;
        [SerializeField]
        private InputActionProperty gripAction;

        private Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            float triggerValue = triggerAction.action.ReadValue<float>();
            float gripValue = gripAction.action.ReadValue<float>();

            anim.SetFloat("Trigger", triggerValue);
            anim.SetFloat("Grip", gripValue);
        }
    }
}
