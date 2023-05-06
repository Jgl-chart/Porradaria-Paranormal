using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FichaBuilder : MonoBehaviour
{

    public Classe Classe;
    public Origem Origem;

    void Start()
    {
        
    }

    public void NewFicha()
    {
        GameManager.instance.FichaDoPlayer = new Ficha(Origem, Classe);
    }


    void Update()
    {
        
    }
}
