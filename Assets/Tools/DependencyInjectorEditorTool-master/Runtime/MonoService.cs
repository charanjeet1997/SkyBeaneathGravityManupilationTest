using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DependencyInjector;

public class MonoService : MonoBehaviour {
	[DependencyInjector.Inject]
	public MonoB monoB;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
