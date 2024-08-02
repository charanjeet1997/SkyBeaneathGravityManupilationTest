using UnityEngine.Serialization;

namespace Games.SkyBeaneathTest
{
	using CustomizeStateMachine;
	using UnityEngine;
	using System;
	using System.Collections;

	/// <summary>
	/// class that will handle the jump state of the player
	/// </summary>
	public class Jump : BaseState
	{

		#region PRIVATE_VARS
		[SerializeField] private float landDistance;
		Vector3 jumpVelocity;
		[SerializeField] private ThirdPersonStateMachine stateMachine;
		[SerializeField]private bool hasPlayerLanded;
		#endregion

		#region PUBLIC_VARS

		public bool canQuickTurn;
		#endregion

		#region UNITY_CALLBACKS
		private void OnDrawGizmos()
		{
			for (int i = 0; i < stateMachine.groundCheckData.groundOffsets.Length; i++)
			{
				Gizmos.DrawRay(stateMachine.mTransform.position + stateMachine.groundCheckData.groundOffsets[i],Vector3.down * stateMachine.groundCheckData.groundDistance);
				Gizmos.DrawRay(stateMachine.mTransform.position + stateMachine.groundCheckData.groundOffsets[i],Vector3.down * landDistance);
			}
		}
		#endregion

		#region PUBLIC_METHODS

		public override void Construct()
		{
			hasPlayerLanded = false;
			base.Construct();
		}

		public override void Transition()
		{
			if(hasPlayerLanded)
			{
				if (stateMachine.locomotionData.canMove)
				{
					stateMachine.ChangeState(stateMachine.locomotionState);
				}
				else
				{
					stateMachine.ChangeState(stateMachine.idleState);
				}
			}
			base.Transition();
		}
		
		public override void ProcessAnimation(Animator animator)
		{
			stateMachine.animator.SetBool(stateMachine.animatorHash.JumpAnimatorHash, !stateMachine.groundCheckData.isGrounded);
			//stateMachine.animator.SetBool(stateMachine.animatorHash.LocomotionAnimatorHash, false);
			base.ProcessAnimation(animator);
		}
		public override Vector3 ProcessMotion(Vector3 input)
		{
			stateMachine.groundCheckData.isGrounded = stateMachine.groundSensor.Sense();
			//check if player is falling down then check for landing using player rigidbody velocity y
			if (!stateMachine.groundCheckData.isGrounded && stateMachine.rigidbody.velocity.y < 0)
			{
				hasPlayerLanded = HasLanded();
			}
			if(!stateMachine.groundCheckData.isGrounded)
			{
				stateMachine.jumpData.canJump = false;
			}

			if(stateMachine.groundCheckData.isGrounded && stateMachine.jumpData.canJump)
			{
				stateMachine.jumpData.canJump = false;
				Vector3 jumpDirection = stateMachine.mTransform.forward * stateMachine.locomotionData.movementDirection.z + stateMachine.mTransform.right * stateMachine.locomotionData.movementDirection.x;
				float absGravity = Mathf.Abs(Physics.gravity.y);
				float velocity = Mathf.Sqrt(2 * absGravity * stateMachine.jumpData.jumpHeight);
				jumpVelocity = new Vector3(jumpDirection.x, velocity, jumpDirection.z);
			}
			float gravity = Physics.gravity.y;
			jumpVelocity.y += gravity * Time.fixedDeltaTime;
			return jumpVelocity;
		}
		
		public override Quaternion ProcessRotation(Vector3 input)
		{
			return stateMachine.mTransform.rotation;
		}

		#endregion

		#region PRIVATE_METHODS
		 
		private bool HasLanded()
		{
			float rayCastHitCounter = 0;
			RaycastHit hit;
			for (int i = 0; i < stateMachine.groundCheckData.groundOffsets.Length; i++)
			{
				if (Physics.Raycast(stateMachine.mTransform.position + stateMachine.groundCheckData.groundOffsets[i], -stateMachine.transform.up, out hit, landDistance, stateMachine.groundCheckData.groundMask))
				{
					return true;
				}
			}
			return false;
		}
		#endregion

	}
}