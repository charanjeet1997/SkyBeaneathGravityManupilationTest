namespace DependencyInjector {

	using System.Collections.Generic;
	using System.Collections;
	using System.Reflection;
	using System;
	using UnityEditor;
	using UnityEngine;
	[InitializeOnLoad]
	public static class MonoBehaviourInjection {
		public static void InjectMonoBehaviour (MonoBehaviour monoOwner, object owner, FieldInfo field) {
			InjectAttribute attribute = Attribute.GetCustomAttribute (field, typeof (InjectAttribute)) as InjectAttribute;
			object objectToBeInjected;
			if (attribute != null) {
				switch (attribute.searchType) {
					case SearchType.InScene:
						objectToBeInjected = GameObject.FindObjectOfType (field.FieldType);
						field.SetValue (owner, objectToBeInjected);
						break;
					case SearchType.InChildren:
						objectToBeInjected = monoOwner.GetComponentInChildren (field.FieldType);
						field.SetValue (owner, objectToBeInjected);
						break;
					case SearchType.OnGameObject:
						objectToBeInjected = monoOwner.GetComponent (field.FieldType);
						field.SetValue (owner, objectToBeInjected);
						break;
				}
			}
		}
		public static void InjectMonoBehaviourArray (MonoBehaviour monoOwner, object owner, FieldInfo field) {
			InjectAttribute attribute = Attribute.GetCustomAttribute (field, typeof (InjectAttribute)) as InjectAttribute;
			object[] monoBehaviourArray;
			Array objectArray;
			Type elementType = field.FieldType.GetElementType ();
			if (attribute != null) {
				switch (attribute.searchType) {
					case SearchType.InScene:
						monoBehaviourArray = GameObject.FindObjectsOfType (elementType);
						objectArray = (Array) field.GetValue (owner);
						objectArray = Array.CreateInstance (elementType, monoBehaviourArray.Length);
						for (int i = 0; i < monoBehaviourArray.Length; i++) {
							objectArray.SetValue (monoBehaviourArray[i], i);
						}
						field.SetValue (owner, objectArray);
						break;
					case SearchType.InChildren:
						monoBehaviourArray = monoOwner.GetComponentsInChildren (elementType);
						objectArray = (Array) field.GetValue (owner);
						objectArray = Array.CreateInstance (elementType, monoBehaviourArray.Length);
						for (int i = 0; i < monoBehaviourArray.Length; i++) {
							objectArray.SetValue (monoBehaviourArray[i], i);
						}
						field.SetValue (owner, objectArray);
						break;
					case SearchType.OnGameObject:
						monoBehaviourArray = monoOwner.GetComponents (elementType);
						objectArray = (Array) field.GetValue (owner);
						objectArray = Array.CreateInstance (elementType, monoBehaviourArray.Length);
						for (int i = 0; i < monoBehaviourArray.Length; i++) {
							objectArray.SetValue (monoBehaviourArray[i], i);
						}
						field.SetValue (owner, objectArray);
						break;
				}
			}
		}
		public static void InjectMonoBehaviourList (MonoBehaviour monoOwner, object owner, FieldInfo field) {
			InjectAttribute attribute = Attribute.GetCustomAttribute (field, typeof (InjectAttribute)) as InjectAttribute;
			object[] monoBehaviourArray;
			IList objectList;
			// Type elementType = field.FieldType.GetElementType ();
			Type elementType = field.FieldType.GetGenericArguments () [0];

			if (attribute != null) {
				switch (attribute.searchType) {
					case SearchType.InScene:
						monoBehaviourArray = GameObject.FindObjectsOfType (elementType);
						objectList = (IList) field.GetValue (owner);
						objectList.Clear ();
						for (int i = 0; i < monoBehaviourArray.Length; i++) {
							objectList.Add (monoBehaviourArray[i]);
						}
						field.SetValue (owner, objectList);
						break;
					case SearchType.InChildren:
						monoBehaviourArray = monoOwner.GetComponentsInChildren (elementType);
						objectList = (IList) field.GetValue (owner);
						objectList.Clear ();
						for (int i = 0; i < monoBehaviourArray.Length; i++) {
							objectList.Add (monoBehaviourArray[i]);
						}
						field.SetValue (owner, objectList);
						break;
					case SearchType.OnGameObject:
						monoBehaviourArray = monoOwner.GetComponents (elementType);
						objectList = (IList) field.GetValue (owner);
						objectList.Clear ();
						for (int i = 0; i < monoBehaviourArray.Length; i++) {
							objectList.Add (monoBehaviourArray[i]);
						}
						field.SetValue (owner, objectList);
						break;
				}
			}
		}
	}
}