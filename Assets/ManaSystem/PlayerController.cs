using UnityEngine;

public class PlayerController
{
    public int LifePoint { get; private set; }
    public int MaxLife { get; private set; }
    public int ManaPoint { get; private set; }
    public int MaxMana { get; private set; }

    //Construtor
    public PlayerController(int initialLife, int maxLife,int initialMana, int maxMana)
    {
        LifePoint = initialLife;
        MaxLife = maxLife;

        ManaPoint = initialMana;
        MaxMana = maxMana;
    }

    //Metodo para curar 
    public bool AddLife(int heal)
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

    //Metodo para aumentar mana a partir de uma carta que tenha esse efeito
    public void AddMana(int amount)
    {
        ManaPoint = Mathf.Min(ManaPoint + amount, MaxMana);
    }

    //Metodo para receber dano
    public bool ReduceLife(int damage)
    {
        if (LifePoint - damage <= 0) return false; //Morte
        LifePoint -= damage;
        return true; 
    }

    //Metodo para gasto de mana
    public bool ReduceMana(int amount) 
    {
        if (amount <= ManaPoint)
        {
            ManaPoint -= amount;
            return true;        
        }
        return false;
    }

    //Aumentar a mana no inico de cada turno
    public void IncreaseManaTurn(int amount)
    {
        MaxMana += amount;

    }

    //Metodo Get para acessar a vida atual
    public int GetLifePoint()
    {
        return LifePoint;
    }

    //Metodo para retornar a mana atual
    public int GetManaPoint()
    {
        return ManaPoint;
    }

    //Metodo para retornar a mana maxima
    public int GetMaxMana()
    {
        return MaxMana;
    }

    //Metodo Get para acessar a vida maxima
    public int GetMax()
    {
        return MaxLife;
    }
}
