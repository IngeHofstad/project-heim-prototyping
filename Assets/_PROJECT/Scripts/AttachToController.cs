using Unity.Netcode;

namespace Heim
{
    public class AttachToController : NetworkBehaviour
    {
        private void Awake()
        {
            if (!IsOwner)
                return;
        }
    }
}
