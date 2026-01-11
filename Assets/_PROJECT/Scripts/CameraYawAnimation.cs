using UnityEngine;
using static TraversalPro.TraversalUtilities;

namespace TraversalPro
{
    /// <summary>
    /// Rotates a character mesh to align with the camera's yaw.
    /// </summary>
    [AddComponentMenu("Traversal Pro/Animation/Camera Yaw Animation")]
    public class CameraYawAnimation : MonoBehaviour
    {
        [Tooltip("The ICharacterMotor component for the animated character.")]
        public InterfaceRef<ICharacterMotor> characterMotor;
        [Tooltip("The camera or view transform to follow.")]
        public Transform view;
        [Tooltip("Smooth time for yaw interpolation.")]
        [Range(0, 1)] public float smoothTime = 0.1f;
        float yaw;
        float yawVelocity;

        void Reset()
        {
            OnValidate();
        }

        void OnValidate()
        {
            characterMotor.Value ??= transform.root.GetComponentInChildren<ICharacterMotor>();
            if (!view)
            {
                ViewControl viewControl = transform.root.GetComponentInChildren<ViewControl>();
                if (viewControl) view = viewControl.transform;
            }
        }

        void OnEnable()
        {
            if (!ValidateRequiredField(this, characterMotor.Value)) enabled = false;
            if (ValidateRequiredField(this, view))
            {
                yaw = GetYaw(view.rotation);
            }
            else
            {
                enabled = false;
            }
        }

        void LateUpdate()
        {
            if (!characterMotor.Value.IsGrounded) return;
            float targetYaw = GetYaw(view.rotation);
            yaw = Mathf.SmoothDampAngle(yaw, targetYaw, ref yawVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0, yaw, 0);
        }
    }
}
