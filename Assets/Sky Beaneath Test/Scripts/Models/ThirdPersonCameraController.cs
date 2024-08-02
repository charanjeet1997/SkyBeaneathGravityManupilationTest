namespace Games.SkyBeaneathTest
{
	using Cinemachine;
	using UnityEngine.InputSystem;
	using UnityEngine;
	using System;
	using System.Collections;

	public class ThirdPersonCameraController :MonoBehaviour,ThirdPersonInput.IMouseMovementActions
	{

		#region PRIVATE_VARS

		[SerializeField] private Vector2 mouseAxis;
		[SerializeField] private float _cinemachineTargetYaw;
		[SerializeField] private float _cinemachineTargetPitch;
		private const float _threshold = 0.01f;
		private ThirdPersonInput _input;
		[SerializeField] private float xSensitivity, ySensitivity;
		[SerializeField] private bool xInverse, yInverse;
		#endregion

		#region PUBLIC_VARS
		[Header("Cinemachine")]
		[Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
		public GameObject CinemachineCameraTarget;

		[Tooltip("How far in degrees can you move the camera up")]
		public float TopClamp = 70.0f;

		[Tooltip("How far in degrees can you move the camera down")]
		public float BottomClamp = -30.0f;

		[Tooltip("Additional degress to override the camera. Useful for fine tuning camera position when locked")]
		public float CameraAngleOverride = 0.0f;

		[Tooltip("For locking the camera position on all axis")]
		public bool LockCameraPosition = false;
		#endregion

		#region UNITY_CALLBACKS
		private void Awake()
		{
			_input = new ThirdPersonInput();
			_input.MouseMovement.Enable();
			_input.MouseMovement.AddCallbacks(this);
		}

		private void Start()
		{
			_cinemachineTargetYaw = CinemachineCameraTarget.transform.rotation.eulerAngles.y;
		}

		private void OnDisable()
		{
			_input.MouseMovement.Disable();
			_input.MouseMovement.RemoveCallbacks(this);
		}
		private void LateUpdate()
		{
			CameraRotation();
		}

		#endregion

		#region PUBLIC_METHODS
		public void OnMouse(InputAction.CallbackContext context)
		{
			mouseAxis = context.ReadValue<Vector2>();
		}
		
		#endregion

		#region PRIVATE_METHODS
		private void CameraRotation()
		{
			if (mouseAxis.sqrMagnitude >= _threshold && !LockCameraPosition)
			{
				//Don't multiply mouse input by Time.deltaTime;
				float deltaTimeMultiplier = 1.0f; 
				
				_cinemachineTargetYaw += mouseAxis.x * deltaTimeMultiplier * (xInverse ? -xSensitivity : xSensitivity);
				_cinemachineTargetPitch += mouseAxis.y * deltaTimeMultiplier * (yInverse ? -ySensitivity : ySensitivity);
			}

			// clamp our rotations so our values are limited 360 degrees
			_cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
			_cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

			// Cinemachine will follow this target
			CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride,
				_cinemachineTargetYaw, 0.0f);
		}
		private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
		{
			if (lfAngle < -360f) lfAngle += 360f;
			if (lfAngle > 360f) lfAngle -= 360f;
			return Mathf.Clamp(lfAngle, lfMin, lfMax);
		}
		#endregion

	}
}