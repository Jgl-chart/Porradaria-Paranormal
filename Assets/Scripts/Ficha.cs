using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ficha
{
    public int For, Agi, Pre, Vig, Int = 1;

    public Origem origem;
    public Classe classe;

    public int NEX = 5;

    public int Deslocamento;

    public int PV_MAX;
    public int PE_MAX;
    public int SAN_MAX;

    public int Defesa = 10;
    public int Esquiva = 15;

    public Dictionary<string, int> Pericias = new Dictionary<string, int>();

    public List<Habilidade> Habilidades;
    public List<Ritual> Rituais;

    public Ficha(Origem origenh, Classe classenh)
    {
        origem = origenh;
        classe = classenh;
    }

    public void InitializeFicha()
    {
        Habilidades.Add(origem.habilidade);
        foreach(Habilidade hab in classe.HabilidadesIniciais)
        {
            Habilidades.Add(hab);
        }

        Deslocamento = 9;
        Defesa = 10 + Agi;
        if(Pericias.TryGetValue("Reflexos", out int valorDoReflexo))
        {
            Esquiva = Defesa + valorDoReflexo;
        }

        PV_MAX = classe.PV_INICIAl + Vig + ((NEX - 5) / 5) * classe.PV_POR_NEX + Vig;
        PE_MAX = classe.PE_INICIAl + Pre + ((NEX - 5) / 5) * classe.PE_POR_NEX + Pre;
        SAN_MAX = classe.SAN_INICIAl + ((NEX - 5) / 5) * classe.SAN_POR_NEX;

        foreach(string pericia in classe.PericiasTreinadas)
        {
            if(!Pericias.TryGetValue(pericia, out int valorPericia))
            {
                Pericias.Add(pericia, 5);
            }
        }

        foreach (string pericia in origem.periciasTreinadas)
        {
            if (!Pericias.TryGetValue(pericia, out int valorPericia))
            {
                Pericias.Add(pericia, 5);
            }
        }

    }


}
