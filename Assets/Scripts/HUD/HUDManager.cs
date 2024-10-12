using UnityEngine;

namespace HUD
{
    public class HUDManager : MonoBehaviour
    {
        public static HUDManager instance;

        private void Start()
        {
            instance = this;
        }
    }
}
