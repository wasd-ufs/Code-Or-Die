using JetBrains.Annotations;
using UnityEngine;

public class Mana
{
    public int Current { get; private set; }
    public int Max { get; private set; }
    public Mana(int initial, int max)
    {
        Current = initial;
        Max = max;
    }

    //Metodo para gasto de mana
    public bool SpeendMana (int amount) 
    {
        if (amount <= Current)
        {
            Current -= amount;
            return true;        
        }
        return false;
    }

    //Metodo para aumentar mana a partir de uma carta que tenha esse efeito
    public void RestoreMana (int amount)
    {
        Current = Mathf.Min(Current + amount, Max);
    }

    //Aumentar a mana no inico de cada turno
    public void IncreaseManaTurn(int amount)
    {
        Max += amount;

    }

    //Metodo para retornar a mana atual
    public int GetCurrent()
    {
        return Current;
    }

}

