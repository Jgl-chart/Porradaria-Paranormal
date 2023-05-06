using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ritual : MonoBehaviour
{
    public string Name;
    public string Description;
    public int PE_COAST;
    public int Circulo;

    public abstract void Action();
}
