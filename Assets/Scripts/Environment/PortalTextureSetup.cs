using UnityEngine;

namespace WhoToastedMrToaster
{
    public class PortalTextureSetup : MonoBehaviour
    {
        public Camera cameraA;
        public Material cameraMatA;

        public Camera cameraB;
        public Material cameraMatB;

        private void Awake()
        {
            SetupTexture(cameraA, cameraMatA);
            SetupTexture(cameraB, cameraMatB);
        }

        private void SetupTexture(Camera camera, Material material)
        {
            if (camera.targetTexture != null)
            {
                camera.targetTexture.Release();
            }
            camera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            material.mainTexture = camera.targetTexture;
        }
    }
}
