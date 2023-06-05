using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WhoToastedMrToaster
{
    public class HandDisplay : MonoBehaviour
    {
        public List<Toggle> objectives = new List<Toggle>();

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
            foreach (var objective in objectives)
            {
                objective.isOn = false;
            }
        }

        public void UnlockNextObjective(int objective)
        {
            objectives[objective].isOn = true;
        }
    }
}
