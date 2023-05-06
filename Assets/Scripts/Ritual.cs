using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ritual", menuName = "Scriptable Objects/Ritual")]
public class Ritual : ScriptableObject
{
    public string Name;
    public string Description;
    public int PE_COAST;
    public int Circulo;

    public GameObject thingToAdd;

}
