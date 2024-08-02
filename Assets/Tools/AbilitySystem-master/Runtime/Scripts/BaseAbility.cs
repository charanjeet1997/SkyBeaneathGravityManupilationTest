namespace CustomizeStateMachine {
	using System.Collections.Generic;
	using System.Collections;
	using UnityEngine;
	/// <summary>
	/// This is the base class of all the abilities that you build.
	/// It also inject it's require dependency at editor time which is base hero so make sure to add one before adding this one.
	/// </summary>
	/// <typeparam name="T">Base Hero</typeparam>
	/// <typeparam name="U">Base Motor</typeparam>
	public class BaseAbility : MonoBehaviour {
		public float cooldown = .5f;
		protected float lastCast;
#if UNITY_EDITOR
		[DependencyInjector.Inject (SearchType.OnGameObject)][HideInInspector]
		#endif
		public BaseHero baseHero;
		public virtual void Cast () {
			if (IsReady ()) {
				lastCast = Time.time;
			}
		}
		protected bool IsReady () {
			return Time.time - lastCast > cooldown;
		}
		public float GetCooldown () {
			float c = (cooldown - (Time.time - lastCast));
			return (c <= 0) ? 0 : c;
		}
	}
}