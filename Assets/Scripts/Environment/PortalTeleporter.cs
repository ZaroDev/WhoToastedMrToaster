using UnityEngine;

namespace WhoToastedMrToaster
{
    public class PortalTeleporter : MonoBehaviour
    {
        public Transform player;
        public Transform reciever;

        private bool playerIsOverlapping = false;

        private void LateUpdate()
        {
            if (playerIsOverlapping)
            {
                Vector3 portalToPlayer = player.position - transform.position;
                float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

                //The player has moved accross the portal
                if (dotProduct < 0f)
                {
                    // Teleport the player
                    float rotationDiff = Quaternion.Angle(transform.rotation, reciever.rotation);
                    rotationDiff += 180f;
                    player.Rotate(Vector3.up, rotationDiff);

                    Vector3 positionOffset = Quaternion.Euler(0, rotationDiff, 0f) * portalToPlayer;
                    player.position = reciever.position + positionOffset;

                    playerIsOverlapping = false;
                }

            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerIsOverlapping = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerIsOverlapping = false;
            }
        }
    }
}
