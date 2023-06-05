using System;
using UnityEngine;
namespace WhoToastedMrToaster
{
    public class GameManager : MonoBehaviour
    {
        public int maxObjectives = 4;
        public static GameManager singleton = null;

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
        }
        // 0 Find the murder weapon
        // 1 Find the 1st memory
        // 2 Find the 2nd memory
        // 3 Find the 3rd memory
        public void UnlockNextObjective(int objective)
        {
            objectiveCount++;
            OnUnlockObjective?.Invoke(objective);

            CanFinishGame();
        }


        public void CanFinishGame()
        {
            canFinish = true;
            OnCanFinishGame?.Invoke();
        }
    }
}
