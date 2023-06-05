using System;
using UnityEngine;
namespace WhoToastedMrToaster
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager singleton = null;

        public static Action OnCanFinishGame;

        public bool canFinish { private set; get; } = false;
        public bool win { private set; get; } = false;
        private void Awake()
        {
            if (singleton && singleton != this)
                Destroy(singleton);

            singleton = this;
        }

        public void FinishGame()
        {
            canFinish = true;
            OnCanFinishGame?.Invoke();
        }
    }
}
