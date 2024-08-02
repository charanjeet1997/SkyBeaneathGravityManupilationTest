using CustomizeStateMachine;

namespace Games.SkyBeaneathTest
{
	using UnityEngine;
	using System;
	using System.Collections;

	public class GravityManipulationAbility : BaseAbility
	{

		#region PRIVATE_VARS

		[SerializeField] private ThirdPersonStateMachine stateMachine;
		[SerializeField] private GameObject hologram;
		[SerializeField] private float rotateSpeed;
		[SerializeField ]Vector3 gravityDirection;
		Quaternion gravityRotation;
		#endregion

		#region PUBLIC_VARS

		#endregion

		#region UNITY_CALLBACKS

		#endregion

		#region PUBLIC_METHODS

		public override void Cast()
		{
			hologram.SetActive(Mathf.Abs(stateMachine.holoDirectionData.gravityDirection.magnitude) > 0);
			Vector3 direction = stateMachine.holoDirectionData.gravityDirection;
			float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
			if (Mathf.Abs(stateMachine.holoDirectionData.gravityDirection.magnitude) > 0)
			{
				hologram.transform.localRotation = Quaternion.Lerp(hologram.transform.localRotation,
					Quaternion.Euler(new Vector3(90, 0, angle)), Time.deltaTime * rotateSpeed);
				gravityRotation = hologram.transform.rotation;
			}
			else
			{
				hologram.transform.localRotation = Quaternion.Lerp(hologram.transform.localRotation,
					Quaternion.Euler(new Vector3(0, 0, 0)), Time.deltaTime * rotateSpeed);
			}

			if (Input.GetKeyDown(KeyCode.Space))
			{
				transform.rotation = gravityRotation;
				SetGravityDirection();
			}

			base.Cast();
		}
		
		void SetGravityDirection()
		{
			gravityDirection = stateMachine.holoDirectionData.gravityDirection.normalized;
			Physics.gravity = gravityDirection * 9.81f;
			if (stateMachine.rigidbody != null)
			{
				stateMachine.rigidbody.AddForce(gravityDirection * 9.81f, ForceMode.Acceleration);
			}
		}
		#endregion

		#region PRIVATE_METHODS

		#endregion

	}
}