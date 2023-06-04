using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
namespace WhoToastedMrToaster
{
    public class XRAlyxGrabInteractable : XRGrabInteractable
    {
        public float velocityThreshold = 2f;
        public float jumpAngleInDegree = 60f;

        private XRRayInteractor rayInteractor;
        private Vector3 previousPos;
        private Rigidbody interactableRigidbody;
        private bool canJump = true;

        protected override void Awake()
        {
            base.Awake();
            interactableRigidbody = GetComponent<Rigidbody>();
        }


        private void Update()
        {
            if (isSelected && firstInteractorSelecting is XRRayInteractor && canJump)
            {
                Vector3 velocity = (rayInteractor.transform.position - previousPos) / Time.deltaTime;
                previousPos = rayInteractor.transform.position;

                if (velocity.magnitude > velocityThreshold)
                {
                    Drop();
                    interactableRigidbody.velocity = ComputeVelocity();
                    canJump = false;
                }
            }
        }
        public Vector3 ComputeVelocity()
        {
            Vector3 diff = rayInteractor.transform.position - transform.position;
            Vector3 diffXZ = new Vector3(diff.x, 0, diff.z);
            float diffXZLength = diffXZ.magnitude;
            float diffYLength = diff.y;

            float angleInRadians = jumpAngleInDegree * Mathf.Deg2Rad;

            float jumpSpeed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(diffXZLength, 2)
                / (2 * Mathf.Cos(angleInRadians) * Mathf.Cos(angleInRadians) * (diffXZLength * Mathf.Tan(angleInRadians) - diffYLength)));

            Vector3 jumpVelocityVector = diffXZ.normalized * Mathf.Cos(angleInRadians) * jumpSpeed + Vector3.up * Mathf.Sin(angleInRadians) * jumpSpeed;
            return jumpVelocityVector;
        }
        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            if (args.interactorObject is XRRayInteractor)
            {
                trackPosition = false;
                trackRotation = false;
                throwOnDetach = false;

                rayInteractor = (XRRayInteractor)args.interactorObject;
                previousPos = rayInteractor.transform.position;
                canJump = true;
            }
            else
            {
                trackPosition = true;
                trackRotation = true;
                throwOnDetach = true;
            }

            base.OnSelectEntered(args);
        }
    }
}
