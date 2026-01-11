using Unity.Netcode.Components;
using UnityEngine;

namespace Heim
{
    public class ClientNetworkAnimator : NetworkAnimator
    {
        protected override bool OnIsServerAuthoritative()
        {
            return false;
        }
    }
}
