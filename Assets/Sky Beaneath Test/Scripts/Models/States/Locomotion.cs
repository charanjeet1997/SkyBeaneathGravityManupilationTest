using UnityEngine.Serialization;

namespace Games.SkyBeaneathTest
{
	using CustomizeStateMachine;
	using UnityEngine;
	using System;
	using System.Collections;

	/// <summary>
	/// summary: class that will handle the locomotion state of the player
	/// </summary>
	public class Locomotion : BaseState
	{

		#region PRIVATE_VARS

		private Vector3 movementDir;
		private float moveInputAngle;
		private float movementMagnitude;
		private float turnAngle;
		private float turnVelocity = 0;
		private bool canMove;
		//[SerializeField] private bool hasAnimatorRotation;
		[SerializeField] private float turnSmoothTime = 0.2f;
		[SerializeField] private ThirdPersonStateMachine stateMachine;
		private Vector3 previousInputDirection;
		[SerializeField] private float quickTurnThreshold = 90;
		[SerializeField] private float directionalDampingValue;
		#endregion

		#region PUBLIC_VARS

		public bool canQuickTurn;
		#endregion

		#region UNITY_CALLBACKS

		#endregion

		#region PUBLIC_METHODS

		public override void Construct()
		{
			base.Construct();
		}

		public override void Transition()
		{
			if (stateMachine.locomotionData.currentAcceleration <= 0 && movementDir == Vector3.zero)
			{
				stateMachine.ChangeState(stateMachine.idleState);
			}
			
			if (stateMachine.jumpData.canJump)
			{
				stateMachine.ChangeState(stateMachine.jumpState);
			}

			if (!stateMachine.groundCheckData.isGrounded)
			{
				stateMachine.ChangeState(stateMachine.jumpState);
			}
			base.Transition();
		}

		public override void ProcessAnimation(Animator animator)
		{
			float locomotionDampTime = animator.GetFloat(stateMachine.animatorHash.LocomotionAnimatorHash) > 0.5f ? 0.5f : 0.2f;
			//animator.SetFloat(stateMachine.animatorHash.LocomotionAnimatorHash,movementMagnitude * stateMachine.locomotionData.currentAcceleration,0.3f,Time.deltaTime);
			animator.SetBool(stateMachine.animatorHash.LocomotionAnimatorHash, canMove);
			stateMachine.animator.SetBool(stateMachine.animatorHash.JumpAnimatorHash, false);
			base.ProcessAnimation(animator);
		}

		public override Vector3 ProcessMotion(Vector3 input)
		{
			stateMachine.groundCheckData.isGrounded = stateMachine.groundSensor.Sense();
			UpdateAcceleration(stateMachine.locomotionData.accelerationSpeed);
			if (input.magnitude > 0)
			{
				canMove = true;
				movementDir = stateMachine.locomotionData.movementDirection;
				if (movementDir.magnitude > 0) movementDir.Normalize();
				movementMagnitude = movementDir.magnitude;
				movementMagnitude = Mathf.Abs(movementMagnitude) > 0.2 ? movementMagnitude : 0;
			}
			else
			{
				canMove = false;
				movementDir = Vector3.zero;
				movementMagnitude = 0;
			}
			return movementMagnitude * stateMachine.mTransform.forward * stateMachine.locomotionData.movementSpeed * stateMachine.locomotionData.currentAcceleration;
		}

		public override Quaternion ProcessRotation(Vector3 input)
		{
			Transform cameraTransform = stateMachine.camera.transform;
			Vector3 cameraRotation = cameraTransform.rotation.eulerAngles;
			Vector3 playerForward = stateMachine.mTransform.forward;
			Vector3 inputCameraDirection = Quaternion.Euler(0, cameraRotation.y, 0) * input;
			inputCameraDirection = inputCameraDirection.normalized;
			directionalDampingValue = Vector3.Dot(playerForward, inputCameraDirection);
			float rotationMultiplier = Mathf.Abs(directionalDampingValue) > 0.2f ? Mathf.Abs(directionalDampingValue) : 0.2f;
			canQuickTurn = directionalDampingValue < -0.2f;
			if (input != Vector3.zero)
			{
				Vector3 cameraForward = cameraTransform.forward * input.z;
				cameraForward += cameraTransform.right * input.x;
				cameraForward.Normalize();
				cameraForward.y = 0;
				return Quaternion.Slerp(stateMachine.mTransform.rotation, Quaternion.LookRotation(cameraForward), Time.fixedDeltaTime * stateMachine.rotateData.rotateSpeed * rotationMultiplier);
			}
			return stateMachine.mTransform.rotation;
		}
		#endregion

		#region PRIVATE_METHODS

		void UpdateAcceleration(float acceleration)
		{
			if (stateMachine.locomotionData.movementDirection.magnitude > 0)
			{
				stateMachine.locomotionData.currentAcceleration += acceleration * Time.deltaTime;
			}
			else
			{
				stateMachine.locomotionData.currentAcceleration -= acceleration * Time.deltaTime;
			}
			stateMachine.locomotionData.currentAcceleration = Mathf.Clamp01(stateMachine.locomotionData.currentAcceleration);
		}
		#endregion

	}
}