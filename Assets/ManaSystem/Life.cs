using UnityEngine;
using JetBrains.Annotations;


public class Life{

    public int LifePoint { get; private set; }
    public int MaxLife { get; private set; }
    //Construtor
    public Life(int initial, int max)
    {
        MaxLife = max;
        LifePoint = initial;
    }

    //Metodo para curar 
    public bool Heal (int heal)
    {
        //Cura a mais
        if (LifePoint + heal >= MaxLife)
        {
            LifePoint = MaxLife;
            return false;
        } 
            
        LifePoint += heal;
        return true;
    }

    //Metodo para receber dano
    public bool ReceiveDamage (int damage)
    {
        if (LifePoint - damage <= 0) return false; //Morte
        LifePoint -= damage;
        return true; 
    }

    //Metodo Get para acessar a vida atual
    public int GetLifePoint()
    {
        return LifePoint;
    }

    //Metodo Get para acessar a vida maxima
    public int GetMax()
    {
        return MaxLife;
    }
    
}

