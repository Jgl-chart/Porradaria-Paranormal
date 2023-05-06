using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Origem", menuName = "Scriptable Objects/Origem")]
public class Origem : ScriptableObject
{
    public string Name;
    public string Description;
    public string[] periciasTreinadas;
    public Habilidade habilidade;
}
