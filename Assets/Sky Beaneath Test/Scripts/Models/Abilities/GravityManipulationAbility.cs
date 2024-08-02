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
			hologram.transform.localRotation = Quaternion.Lerp(hologram.transform.localRotation, Quaternion.Euler(new Vector3(0, 0, angle)), Time.deltaTime * rotateSpeed);
			base.Cast();
		}
		#endregion

		#region PRIVATE_METHODS

		#endregion

	}
}