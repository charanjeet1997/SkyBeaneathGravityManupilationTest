namespace DependencyInjector {
	using System.Collections.Generic;
	using System.Collections;
	using System.Reflection;
	using System;
	using UnityEditor;
	using UnityEngine;
	[InitializeOnLoad]
	public static class DependencyInjector {
		[MenuItem ("Dependency Injector / MonoInjection")]
		public static void InjectMonoDependency (MonoBehaviour[] monoBehaviours) {
			foreach (MonoBehaviour mono in monoBehaviours) {
				FieldInfo[] objectFields = mono.GetType ().GetFields (BindingFlags.Instance | BindingFlags.Public);
				for (int i = 0; i < objectFields.Length; i++) {
					// Debug.Log(objectFields[i].Name);
					object owner = (object) mono;
					Type typ = objectFields[i].FieldType;
					if (typ.IsList ()) {
						if (typ.GetGenericArguments () [0].IsTypeOf (typeof(MonoBehaviour)) || typ.GetGenericArguments () [0].IsTypeOf (typeof(Component))) {
							MonoBehaviourInjection.InjectMonoBehaviourList (mono, owner, objectFields[i]);
						} else if (typ.GetGenericArguments () [0].IsTypeOf (typeof(ScriptableObject))) {
							ScriptableObjectInjection.InjectScriptableObjectList (owner, objectFields[i]);
						}
					} else if (objectFields[i].FieldType.IsArray) {
						if (objectFields[i].FieldType.GetElementType ().IsTypeOf (typeof(MonoBehaviour)) || objectFields[i].FieldType.GetElementType ().IsTypeOf (typeof(Component))  ) {
							MonoBehaviourInjection.InjectMonoBehaviourArray (mono, owner, objectFields[i]);
						} else if (objectFields[i].FieldType.GetElementType ().IsTypeOf (typeof(ScriptableObject))) {
							ScriptableObjectInjection.InjectScriptableObjectArray (owner, objectFields[i]);
						} else if (objectFields[i].FieldType.IsSerializable && objectFields[i].FieldType.IsClass) {

						}
					} else {
						if (typ.IsTypeOf (typeof(MonoBehaviour)) || typ.IsTypeOf (typeof(Component))) {
							MonoBehaviourInjection.InjectMonoBehaviour (mono, owner, objectFields[i]);
						} else if (typ.IsTypeOf (typeof(ScriptableObject))) {
							ScriptableObjectInjection.InjectScriptableObject (mono, objectFields[i]);
						} else if (objectFields[i].FieldType.IsSerializable && objectFields[i].FieldType.IsClass) {
							ClassLevelDependencyInjection.ClassLevelInjection (mono, owner, objectFields[i]);
						}
					}
				}
			}
		}
		
		[MenuItem ("Dependency Injector / Resolve Scene Dependency")]
		public static void ResolveSceneDependency()
		{
			InjectMonoDependency(GameObject.FindObjectsOfType<MonoBehaviour> ());
		}
		[MenuItem ("Dependency Injector / Resolve Selected Objects Dependency  ")]
		public static void ResolveSelectedObjectDependency () {
			if (Selection.gameObjects.Length > 0) {
				Debug.Log (Selection.gameObjects[0].name);
				List<MonoBehaviour> monos=new List<MonoBehaviour>();
				foreach(GameObject gameObj in Selection.gameObjects)
				{
					MonoBehaviour[] tempMonoBehaviours=gameObj.GetComponents<MonoBehaviour>();
				
					foreach(MonoBehaviour tempMono in tempMonoBehaviours)
					{
						monos.Add(tempMono);
					}
				}
				InjectMonoDependency(monos.ToArray());
			} else if (Selection.objects.Length > 0) {
				Debug.Log (Selection.objects[0].name);
			}
		}
	}
}