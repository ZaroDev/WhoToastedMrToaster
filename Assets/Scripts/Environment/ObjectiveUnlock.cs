using UnityEngine;

namespace WhoToastedMrToaster
{
    public class ObjectiveUnlock : MonoBehaviour
    {
        public int objectiveIndex;
        public void Unlock()
        {
            GameManager.singleton.UnlockNextObjective(objectiveIndex);
        }
    }
}
