using System;
using UnityEngine;

namespace ServiceLocatorFramework
{
	public static class Bootstrapper
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void InitiailzeBeforeSceneLoad()
		{
			// Debug.Log("Initialized");
			// Initialize default service locator.
			ServiceLocator.Initiailze();
		}
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		public static void InitializeAfterSceneLoad()
		{
			// ServiceLocator.Current.Register<IPropertyManager>(new PropertyManager());
			// ServiceLocator.Current.Register<IObserverManager>(new ObserverManager());
		}
	}
}