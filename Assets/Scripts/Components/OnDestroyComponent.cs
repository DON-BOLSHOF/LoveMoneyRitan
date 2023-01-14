using UnityEngine;

namespace Components
{
    public class OnDestroyComponent : MonoBehaviour
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
