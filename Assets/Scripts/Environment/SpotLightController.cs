using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

namespace WhoToastedMrToaster
{
    public class SpotLightController : MonoBehaviour
    {
        public GameObject[] waypoints;
        public float duration = 1f;
        public event Action OnMovementComplete;
        private int current = 0;

        private Coroutine movementCoroutine;
        public void SetMovement(int index)
        {
            current = index;
            if (movementCoroutine != null)
                StopCoroutine(movementCoroutine);
            movementCoroutine = StartCoroutine(MoveObject());
        }

        private IEnumerator MoveObject()
        {
            Vector3 initialPosition = transform.position;
            float t = 0f;
            float elapsedTime = 0f;
            while (t < 1f)
            {
                elapsedTime += Time.deltaTime;
                t = elapsedTime / duration;
                float easedT = Easing.InOutCubic(t);

                transform.position = Vector3.Lerp(initialPosition, waypoints[current].transform.position, easedT);
                yield return null;
            }

            OnMovementComplete?.Invoke();
        }
    }
}
