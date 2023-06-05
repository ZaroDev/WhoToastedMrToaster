using System;
using UnityEngine;
namespace WhoToastedMrToaster
{
    public class GameManager : MonoBehaviour
    {
        public int maxObjectives = 4;
        public static GameManager singleton = null;

        public GameObject finalAnim;

        public static Action OnCanFinishGame;

        public static Action<int> OnUnlockObjective;

        public int objectiveCount { private set; get; } = 0;

        public bool canFinish { private set; get; } = false;
        public bool win { private set; get; } = false;
        private void Awake()
        {
            if (singleton && singleton != this)
                Destroy(singleton);

            singleton = this;

            finalAnim.SetActive(false);
        }
        // 0 Find the murder weapon
        // 1 Find the 1st memory
        // 2 Find the 2nd memory
        // 3 Find the 3rd memory

        private void Update()
        {
            if (objectiveCount >= maxObjectives)
            {
                finalAnim.SetActive(true);
            }
        }
        public void UnlockNextObjective(int objective)
        {
            OnUnlockObjective?.Invoke(objective);
            objectiveCount++;

            CanFinishGame();
        }


        public void CanFinishGame()
        {
            canFinish = true;
            OnCanFinishGame?.Invoke();
        }
    }
}
