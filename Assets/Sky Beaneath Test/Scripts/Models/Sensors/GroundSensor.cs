using System;

namespace Games.SkyBeaneathTest
{
	using CustomizeStateMachine;
	using UnityEngine;

	/// <summary>
	/// Ground sensor class
	/// class that will check if player is grounded using raycast using multiple rays
	/// rays are casted from the bottom of the player to the ground
	/// </summary>
	[Serializable]
	public class GroundSensor : BaseSensor
	{
		[SerializeField] private ThirdPersonStateMachine stateMachine;
		public override bool Sense()
		{
			float rayCastHitCounter = 0;
			RaycastHit hit;
			for (int i = 0; i < stateMachine.groundCheckData.groundOffsets.Length; i++)
			{
				if (Physics.Raycast(stateMachine.mTransform.position + stateMachine.groundCheckData.groundOffsets[i], -stateMachine.transform.up, out hit, stateMachine.groundCheckData.groundDistance, stateMachine.groundCheckData.groundMask))
				{
					rayCastHitCounter++;	
				}
			}
			
			return rayCastHitCounter > 0;
		}
	}
}