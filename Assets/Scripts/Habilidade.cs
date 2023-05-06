using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Habilidade", menuName = "Scriptable Objects/Habilidade")]
public class Habilidade : ScriptableObject
{
    public string Name;
    public string Description;
    public int PE_COAST;

    public GameObject thingToAdd;

    

}
