using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Classe", menuName = "Scriptable Objects/Classe")]
public class Classe : ScriptableObject
{
    public string Name;
    public string Description;

    public List<Habilidade> HabilidadesIniciais;
    public string[] PericiasTreinadas;

    public int PV_INICIAl;
    public int PV_POR_NEX;

    public int PE_INICIAl;
    public int PE_POR_NEX;

    public int SAN_INICIAl;
    public int SAN_POR_NEX;

    public Dictionary<int, Habilidade> HabilidadePorNex;

}