namespace DependencyInjector {

	using System.Collections.Generic;
	using System.Collections;
	using System.Reflection;
	using System;
	using UnityEditor;
	using UnityEngine;
	[InitializeOnLoad]
	public static class ScriptableObjectInjection {
		public static void InjectScriptableObject (object owner, FieldInfo field) {
			InjectAttribute attribute = Attribute.GetCustomAttribute (field, typeof (InjectAttribute)) as InjectAttribute;
			if (attribute == null)
				return;
			object objectToBeInjected = Resources.FindObjectsOfTypeAll (field.FieldType) [0];
			field.SetValue (owner, objectToBeInjected);
		}
		public static void InjectScriptableObjectArray (object owner, FieldInfo field) {
			InjectAttribute attribute = Attribute.GetCustomAttribute (field, typeof (InjectAttribute)) as InjectAttribute;
			if (attribute == null)
				return;
			Type elementType = field.FieldType.GetElementType ();
			object[] scriptableArray = Resources.FindObjectsOfTypeAll (elementType);
			Array objectArray = (Array) field.GetValue (owner);
			objectArray = Array.CreateInstance (elementType, scriptableArray.Length);
			for (int i = 0; i < scriptableArray.Length; i++) {
				objectArray.SetValue (scriptableArray[i], i);
			}
			field.SetValue (owner, objectArray);
		}
		public static void InjectScriptableObjectList (object owner, FieldInfo field) {
			InjectAttribute attribute = Attribute.GetCustomAttribute (field, typeof (InjectAttribute)) as InjectAttribute;
			if (attribute == null)
				return;
			Type elementType = field.FieldType.GetGenericArguments () [0];
			object[] scriptableArray = Resources.FindObjectsOfTypeAll (elementType);
			var instance = (IList) field.GetValue (owner);
			instance.Clear ();
			foreach (object ob in scriptableArray) {
				instance.Add (ob);
			}
			field.SetValue (owner, instance);
		}
	}
}