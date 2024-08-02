using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public static class InjectionUtility {
	public static bool falseVariable = false;
	public static bool trueVariable = true;

	public static bool IsScriptableObject (this Type type) {
		if (type == typeof (ScriptableObject)) {
			return trueVariable;
		}
		return (type.BaseType == null) ? falseVariable : type.BaseType.IsScriptableObject ();
	}
	public static bool IsMonoBehaviour (this Type type) {
		if (type == typeof (MonoBehaviour)) {
			return trueVariable;
		}
		return (type.BaseType == null) ? falseVariable : type.BaseType.IsMonoBehaviour ();
	}
	public static bool GetIsPrefab (this object a_Object) {

		MonoBehaviour tempObject = (MonoBehaviour) a_Object;
		return tempObject.gameObject.scene.rootCount == 0;
	}
	public static bool IsList (this Type type) {
		return type.IsGenericType && type.GetGenericTypeDefinition () == typeof (List<>);
	}

	public static bool IsTypeOf(this Type type, Type targetType)
	{
		if(type==targetType)
		{
			return trueVariable;
		}
		return (type.BaseType == null) ? falseVariable : type.BaseType.IsTypeOf (targetType);
		
	}
	
}