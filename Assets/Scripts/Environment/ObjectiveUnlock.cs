using System.Collections;
using UnityEngine;

namespace WhoToastedMrToaster
{
    public class ObjectiveUnlock : MonoBehaviour
    {
        private Coroutine setIndex = null;
        public int objectiveIndex;
        public bool activated = false;
        public bool canDisapear = true;
        private void Awake()
        {
            activated = false;
        }
        public void Unlock()
        {
            if (activated)
                return;

            if (setIndex != null)
                StopCoroutine(setIndex);

            setIndex = StartCoroutine(SetIndex());
        }

        IEnumerator SetIndex()
        {

            yield return new WaitForSeconds(2f);
            GameManager.singleton.UnlockNextObjective(objectiveIndex);
            if (canDisapear)
                gameObject.SetActive(false);
            setIndex = null;
            activated = true;
        }
    }
}
