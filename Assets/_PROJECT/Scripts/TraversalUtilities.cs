using UnityEngine;

/*
 * Utilities from Traversal Pro, as they are internal in the package.
 */
namespace TraversalPro
{
    public static class TraversalUtilities
    {
        
        // Helper: Yaw from Quaternion
        public static float GetYaw(Quaternion orientation)
        {
            orientation.Normalize();
            Vector3 forward = orientation * Vector3.forward;
            if (forward.y > .9999f)
            {
                forward = orientation * -Vector3.up;
            }
            else if (forward.y < -.9999f)
            {
                forward = orientation * Vector3.up;
            }
            return Mathf.Atan2(forward.z, forward.x) * Mathf.Rad2Deg * -1 + 90;
        }

        // Helper: Validate required field
        public static bool ValidateRequiredField<T>(MonoBehaviour owner, T value) where T : class
        {
            if (value == null)
            {
                Debug.LogError($"[{owner.GetType().Name}] Missing {typeof(T).Name} field on GameObject '{owner.name}'.");
                return false;
            }
            return true;
        }
        
        public static Vector3 WithY(this Vector3 value, float y)
        {
            return new Vector3(value.x, y, value.z);
        }
    }
}
