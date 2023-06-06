using System.Collections;
using UnityEngine;

namespace WhoToastedMrToaster
{
    public class ObjectiveUnlock : MonoBehaviour
    {
        private Coroutine setIndex = null;
        public int objectiveIndex;
        public bool activateded = false;
        public bool canDisapear = true;
        private void Awake()
        {
            activateded = false;
        }
        public void Unlock()
        {
            if (activateded)
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
            activateded = true;
        }
    }
}
