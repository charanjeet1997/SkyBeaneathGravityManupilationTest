using UnityEngine.Serialization;

namespace Games.SkyBeaneathTest
{
	using CustomizeStateMachine;	
	using UnityEngine;
	using System;
	using System.Collections;
	public class AnimatorHash
	{
		public int LocomotionAnimatorHash => Animator.StringToHash("Locomotion");
		public int JumpAnimatorHash => Animator.StringToHash("Jump");
	}
	// create locomotion class which contains movement speed, movement direction, can run, current acceleration, acceleration speed
	[Serializable]
	public class LocomotionData
	{
		public bool canMove;
		public float movementSpeed;
		public Vector3 movementDirection;
		public float currentAcceleration;
		public float accelerationSpeed;
	}
	
	[Serializable]
	public class GravityManipulationData
	{
		public Vector3 gravityDirection;
	}

	[Serializable]
	public class RotateData
	{
		public float rotateSpeed;
	}

	[Serializable]
	public class JumpData
	{
		public float jumpDistance;
		public float jumpHeight;
		public bool canJump;
	}
	
	// create a class that will check if player is grounded using raycast using multiple rays
	[Serializable]
	public class GroundCheckData
	{
		public bool isGrounded;
		public float groundDistance;
		public LayerMask groundMask;
		public Vector3[] groundOffsets;
	}
	

	/// <summary>
	/// state machine for third person controller
	/// </summary>
	public class ThirdPersonStateMachine : BaseMotor
	{

		#region PRIVATE_VARS
		private Vector3 moveVector;
		#endregion

		#region PUBLIC_VARS

		public AnimatorHash animatorHash;
		public Camera camera;
		public Animator animator;
		public Vector3 MoveVector {get => moveVector; set => moveVector = value;}
		public Quaternion RotationQuaternion{set;get;}
		public Transform mTransform;

		[Header("States")] 
		public BaseState idleState;
		public BaseState locomotionState; 
		public BaseState jumpState;
		
		[Header("Third Person Data")]
		public LocomotionData locomotionData;
		public RotateData rotateData;
		public JumpData jumpData;
		public GroundCheckData groundCheckData;
		public GravityManipulationData holoDirectionData;
		
		[Header("Sensors")]
		public GroundSensor groundSensor;
		#endregion

		#region UNITY_CALLBACKS

		private void Awake()
		{
			animatorHash = new AnimatorHash();
		}

		public void Start ()
		{
			state = idleState;
			state.Construct ();
		}

		private void OnDrawGizmos()
		{
			for (int i = 0; i < groundCheckData.groundOffsets.Length; i++)
			{
				Gizmos.DrawRay(mTransform.position + groundCheckData.groundOffsets[i],Vector3.down * groundCheckData.groundDistance);
			}
		}

		private void FixedUpdate()
		{
//			Debug.Log(currentState);
			state.Transition();
			state.ProcessAnimation(animator);
			Move();
		}
		private void Update()
		{
			Vector3 input = locomotionData.movementDirection;
			moveVector=state.ProcessMotion(input);
		//	moveVector.y = Physics.gravity.y;
			RotationQuaternion = state.ProcessRotation(input);
			Rotate();
		}
		

		#endregion

		#region PUBLIC_METHODS
		public void Move()
		{
			rigidbody.velocity = moveVector;
		}
		public void Rotate()
		{
			transform.rotation=RotationQuaternion;
		}
		#endregion

		#region PRIVATE_METHODS

		#endregion

	}
}