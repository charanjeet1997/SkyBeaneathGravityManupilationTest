using System;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Games.SkyBeaneathTest
{
	using UnityEngine;

	public class ThirdPersonInputManager : MonoBehaviour,ThirdPersonInput.ILocomotionActions,ThirdPersonInput.IHoloDirectionActions
	{

		#region PRIVATE_VARS

		[SerializeField] private ThirdPersonStateMachine stateMachine;
		private ThirdPersonInput input;
		#endregion

		#region PUBLIC_VARS
		
		#endregion

		#region UNITY_CALLBACKS

		private void Awake()
		{
			input = new ThirdPersonInput();
			input.Locomotion.Enable();
			input.Locomotion.AddCallbacks(this);
			input.HoloDirection.Enable();
			input.HoloDirection.AddCallbacks(this);
		}

		private void OnDisable()
		{
			input.Locomotion.Disable();
			input.Locomotion.RemoveCallbacks(this);
			input.HoloDirection.Disable();
			input.HoloDirection.RemoveCallbacks(this);
		}

		#endregion

		#region PUBLIC_METHODS
		public void OnMovement(InputAction.CallbackContext context)
		{
			if (context.canceled)
			{
				stateMachine.locomotionData.movementDirection = Vector3.zero;
				stateMachine.locomotionData.canMove = false;
				return;
			}
			stateMachine.locomotionData.canMove = true;
			Vector2 movementDir = context.ReadValue<Vector2>();
			stateMachine.locomotionData.movementDirection = new Vector3(movementDir.x, 0, movementDir.y);
		}
		

		public void OnJump(InputAction.CallbackContext context)
		{
			if (context.performed)
			{
				stateMachine.jumpData.canJump = true;
			}
		}
		#endregion

		#region PRIVATE_METHODS

		#endregion

		public void OnHollowDirection(InputAction.CallbackContext context)
		{
			Vector2 holoDir = context.ReadValue<Vector2>();
			stateMachine.holoDirectionData.gravityDirection = new Vector3(holoDir.x, 0, holoDir.y/2);
		}
	}
}