using UnityEngine.Serialization;

namespace Games.SkyBeaneathTest
{
	using CustomizeStateMachine;
	using UnityEngine;
	using System;
	using System.Collections;
/// <summary>
/// summary: class that will handle the crouch state of the player
/// </summary>
	public class Idle : BaseState
	{

		#region PRIVATE_VARS

		private Vector3 movementDirection = Vector3.zero;
		private float moveInputAngle;
		private float turnAngle;
		[SerializeField] private ThirdPersonStateMachine stateMachine;
		private Vector3 previousInputDirection;
		#endregion

		#region PUBLIC_VARS

		public bool canQuickTurn;
		#endregion

		#region UNITY_CALLBACKS

		#endregion

		#region PUBLIC_METHODS

		public override void Transition()
		{
			if (movementDirection != Vector3.zero) 
			{
				stateMachine.ChangeState(stateMachine.locomotionState);
			}
			
			// if statmachine jumpdata canjump is true change to jump state
			if (stateMachine.jumpData.canJump)
			{
				stateMachine.ChangeState(stateMachine.jumpState);
			}
			base.Transition();
		}

		public override void ProcessAnimation(Animator animator)
		{
			float locomotionDampTime = animator.GetFloat(stateMachine.animatorHash.LocomotionAnimatorHash) > 0.5f ? 0.5f : 0.2f;
			animator.SetBool(stateMachine.animatorHash.LocomotionAnimatorHash, false);
			stateMachine.animator.SetBool(stateMachine.animatorHash.JumpAnimatorHash, false);
			base.ProcessAnimation(animator);
		}

		public override Vector3 ProcessMotion(Vector3 input)
		{
			stateMachine.groundCheckData.isGrounded = stateMachine.groundSensor.Sense();
			movementDirection = input;
			return Vector3.zero;
		}

		public override Quaternion ProcessRotation(Vector3 input)
		{
			Transform cameraTransform = stateMachine.camera.transform;
			// Vector3 cameraRotation = cameraTransform.rotation.eulerAngles;
			// Vector3 playerForward = stateMachine.mTransform.forward;
			// Vector3 inputCameraDirection = Quaternion.Euler(0, cameraRotation.y, 0) * input;
			// inputCameraDirection = inputCameraDirection.normalized;
			// directionalDampingValue = Vector3.Dot(playerForward, inputCameraDirection);
			// float rotationMultiplier = Mathf.Abs(directionalDampingValue) > 0.2f ? Mathf.Abs(directionalDampingValue) : 0.2f;
			// canQuickTurn = directionalDampingValue < -0.2f;
			// if (input != Vector3.zero)
			// {
			// 	Vector3 cameraForward = cameraTransform.forward * input.z;
			// 	cameraForward += cameraTransform.right * input.x;
			// 	cameraForward.Normalize();
			// 	cameraForward.y = 0;
			// 	return Quaternion.Slerp(stateMachine.mTransform.rotation, Quaternion.LookRotation(cameraForward), Time.fixedDeltaTime * stateMachine.data.rotateData.rotateSpeed * rotationMultiplier);
			// }

			return stateMachine.mTransform.rotation;
		}
		#endregion

		#region PRIVATE_METHODS

		#endregion

	}
}