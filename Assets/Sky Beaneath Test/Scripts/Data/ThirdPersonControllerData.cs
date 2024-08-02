namespace Games.SkyBeaneathTest
{
	using UnityEngine;
	using System;
	[CreateAssetMenu(menuName = "Data/ThirdPersonControllerData",fileName = "ThirdPersonControllerData")]
	public class ThirdPersonControllerData:ScriptableObject
	{
		public LocomotionData locomotionData;
		public RotateData rotateData;
	}
	
}