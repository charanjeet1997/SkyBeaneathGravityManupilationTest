namespace DependencyInjector {
	using System.Collections.Generic;
	using System.Collections;
	using UnityEngine;
	using System;
	
	
	[AttributeUsage(AttributeTargets.Field,AllowMultiple=true)]
	public class InjectAttribute : Attribute {
		public SearchType searchType=SearchType.InScene;
		public InjectAttribute(SearchType searchType=SearchType.InScene)
		{
			this.searchType=searchType;
		}
	}
}