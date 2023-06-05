using System.Collections;
using UnityEngine;

namespace WhoToastedMrToaster
{
    public class ObjectiveUnlock : MonoBehaviour
    {
        private Coroutine setIndex = null;
        public int objectiveIndex;
        public void Unlock()
        {
            if (setIndex != null)
                StopCoroutine(setIndex);

            setIndex = StartCoroutine(SetIndex());
        }

        IEnumerator SetIndex()
        {
            yield return new WaitForSeconds(2f);
            GameManager.singleton.UnlockNextObjective(objectiveIndex);
            gameObject.SetActive(false);
            setIndex = null;
        }
    }
}
