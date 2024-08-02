using System.Collections;
using System.Collections.Generic;
using DependencyInjector;
using UnityEngine;

namespace DependencyInjector
{
    [System.Serializable]
    public class DataClass
    {
        [Inject(SearchType.InScene)] public MonoService service;

        [Inject] public DataA dataA;
        public DataClassB dataClassB;
    }

    [System.Serializable]
    public class DataClassB
    {
        [Inject] public DataA dataA;
        public DataClassC dataClassC;
    }

    [System.Serializable]
    public class DataClassC
    {
        [Inject] public MonoService monoService;
        [Inject(SearchType.InScene)] public MonoB[] monoB;
        public DataA[] dataAs;
    }

    public class MonoA : MonoBehaviour
    {
        [Inject(SearchType.InScene)] public MonoService service;

        [Inject(SearchType.InScene)] public MonoB[] monoB;


        public DataA dataA;
        [Inject] public List<DataA> dataAs;

        [Inject(SearchType.InScene)] public List<MonoB> monoBs;

        public DataClass dataClass;
    }
}