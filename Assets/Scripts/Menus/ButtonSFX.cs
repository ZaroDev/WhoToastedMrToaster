using UnityEngine;

namespace WhoToastedMrToaster
{

    public class ButtonSFX : MonoBehaviour
    {

        public AudioClip hoverSFX;
        public AudioClip clickSFX;
        public AudioClip exitSFX;
        public AudioSource source;

        private void Awake()
        {
            source = GetComponent<AudioSource>();
        }

        public void OnClick()
        {
            source.PlayOneShot(clickSFX);
        }

        public void OnHover()
        {
            source.PlayOneShot(hoverSFX);
        }
        public void OnExit()
        {
            source.PlayOneShot(exitSFX);
        }

    }
}
