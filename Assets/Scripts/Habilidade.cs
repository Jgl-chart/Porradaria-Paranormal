using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Habilidade : MonoBehaviour
{
    public string Name;
    public string Description;
    public int PE_COAST;

    public abstract void Action();

    private void Start()
    {
        
    }

}
