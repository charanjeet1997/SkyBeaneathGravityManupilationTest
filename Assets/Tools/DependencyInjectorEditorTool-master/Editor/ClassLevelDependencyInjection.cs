namespace DependencyInjector {
	using System.Collections.Generic;
	using System.Collections;
	using System.Reflection;
	using System;
	using UnityEditor;
	using UnityEngine;
	[InitializeOnLoad]
	public static class ClassLevelDependencyInjection 
	{
		public static void ClassLevelInjection (MonoBehaviour monoOwner, object owner, FieldInfo field) {
			object classToBeInjectedIn = field.GetValue (owner);
			FieldInfo[] fields = classToBeInjectedIn.GetType ().GetFields (BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++) {
				Type typ = fields[i].FieldType;
				if (fields[i].FieldType.IsArray) {
					if (fields[i].FieldType.GetElementType ().IsMonoBehaviour ()) {
						MonoBehaviourInjection.InjectMonoBehaviourArray (monoOwner, classToBeInjectedIn, fields[i]);
					} else if (fields[i].FieldType.GetElementType ().IsScriptableObject ()) {
						ScriptableObjectInjection.InjectScriptableObjectArray (classToBeInjectedIn, fields[i]);
					}
				} else {
					if (typ.IsMonoBehaviour ()) {
						MonoBehaviourInjection.InjectMonoBehaviour (monoOwner, classToBeInjectedIn, fields[i]);
					} else if (typ.IsScriptableObject ()) {
						ScriptableObjectInjection.InjectScriptableObject (classToBeInjectedIn, fields[i]);
					} else if (fields[i].FieldType.IsSerializable && fields[i].FieldType.IsClass) {
						ClassLevelInjection (monoOwner, classToBeInjectedIn, fields[i]);
					}
				}
			}
		}
	}
}