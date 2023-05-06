using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public bool isMenu = false;

    public Ficha FichaDoPlayer;

    public Origem origemTeste;
    public Classe classeTeste;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        Register();

        if (FichaDoPlayer == null)
        {
            FichaDoPlayer = new Ficha(origemTeste, classeTeste);
        }

        FichaDoPlayer.InitializeFicha();

    }

    void Update()
    {
        if(!isMenu && Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public static int PegarMaiorValor(int[] valores)
    {
        int MaiorValor = -100000;
        for(int i = 0; i < valores.Length; i++)
        {
            if(valores[i] > MaiorValor)
            {
                MaiorValor = valores[i];
            }
        }

        return MaiorValor;

    }

    public static int PegarMenorValor(int[] valores)
    { 
        int MenorValor = 100000;
        for (int i = 0; i < valores.Length; i++)
        {
            if (valores[i] < MenorValor)
            {
                MenorValor = valores[i];
            }
        }

        return MenorValor;

    }

    public void Register()
    {
        
    }

    public static int RollDice(int numberOfDices, int typeOfDice, int soma)
    {
        if(numberOfDices > 0)
        {
            int[] dices = new int[numberOfDices];
            for (int i = 0; i <= numberOfDices; i++)
            {
                dices[i] = Random.Range(1, typeOfDice + 1);
            }
            return PegarMaiorValor(dices) + soma;
        }
        else 
        {
            int[] dices = new int[numberOfDices];
            for (int i = 0; i <= 1; i++)
            {
                dices[i] = Random.Range(1, typeOfDice + 1);
            }
            return PegarMenorValor(dices) + soma;
        }
    }

    public static int RollDanoDice(int numberOfDices, int typeOfDice, int soma)
    {
        int dano = 0;

        for(int i = 0; i <= numberOfDices; i++)
        {
            dano += Random.Range(1, typeOfDice + 1);
        }

        return dano + soma;

    }

}
