using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WhoToastedMrToaster
{
    public class HandDisplay : MonoBehaviour
    {
        public float waitTime = 3f;
        public List<Toggle> objectives = new List<Toggle>();
        public AudioSource source;
        public GameObject glowingObject;

        private Coroutine unlockCoroutine = null;
        private void OnEnable()
        {
            GameManager.OnUnlockObjective += UnlockNextObjective;
        }
        private void OnDisable()
        {
            GameManager.OnUnlockObjective -= UnlockNextObjective;
        }

        public void Awake()
        {
            source = GetComponent<AudioSource>();
            foreach (var objective in objectives)
            {
                objective.isOn = false;
            }
        }
        int obj = 0;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                UnlockNextObjective(obj++);
            }
        }

        public void UnlockNextObjective(int objective)
        {
            objectives[objective].isOn = true;

            source.Play();
            if (unlockCoroutine != null)
            {
                StopCoroutine(unlockCoroutine);
            }
            unlockCoroutine = StartCoroutine(UnlockCoroutine(waitTime));
        }

        private IEnumerator UnlockCoroutine(float waitTime)
        {
            float endTime = Time.time + waitTime;
            WaitForSeconds timeToWait = new WaitForSeconds(0.2f);

            bool active = true;
            while (Time.time < endTime)
            {
                glowingObject.SetActive(active);
                active = !active;

                yield return timeToWait;
            }
            glowingObject.SetActive(false);
            unlockCoroutine = null;
        }
    }
}
