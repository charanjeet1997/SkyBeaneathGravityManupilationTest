﻿namespace CustomizeStateMachine.Samples {
	using System.Collections.Generic;
	using System.Collections;
	using CustomizeStateMachine;
	using UnityEngine.Assertions;
	using UnityEngine;
	public class TankIdle : BaseState {
		#if UNITY_EDITOR
		[DependencyInjector.Inject(SearchType.OnGameObject)]
		#endif
		public TankStateMachine tankStateMachine;
#if UNITY_EDITOR
		[DependencyInjector.Inject(SearchType.OnGameObject)]
		#endif
		public Tank tank;
		public override void Construct()
		{
			base.Construct();
			immuneTime=0f;
		}
		public override void Transition () {
			base.Transition ();
			if (tankStateMachine.movementData.moveAmount > 0) {
				tankStateMachine.ChangeState ("TankWalk");
			}
		}
		public override Quaternion ProcessRotation(Vector3 input)
		{
			return Quaternion.LookRotation(tankStateMachine.mTransform.forward);
		}
		
	}
}