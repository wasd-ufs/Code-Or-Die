using UnityEngine;


public enum CardType
    {
        Damage,
        Heal,
        Buff,
        Debuff,
        Conditional
    }

public enum BuffType
    {
        None,
        IncreaseManaMax,
        IncreaseDamage,
        Heal
    }

public enum DebuffType
    {
        None,
        CancelEffect,            //Anula efeito da carta do adversário
        ReduceDamage,           //Reduz dano do adversário
        IncreaseManaCost,       //Aumenta Custo de mana do adversário
        ReduceMana              //Reduz mana do adversário
    }

public class Card : ScriptableObject
{
    public int manaCost;
    public CardType type;
    public int amount;

    public string conditionVariable;
    public int conditionValue;

    public BuffType buffEffect = BuffType.None;
    public DebuffType debuffEffect = DebuffType.None;

    public void ExecuteEffect(Player caster, Player target)
    {
        switch (type)
        {
            case CardType.Damage:
                if (target != null)
                {
                    target.TakeDamage(amount);
                }
                break;

            case CardType.Heal:
                caster.Heal(amount);
                break;

            case CardType.Buff:
                ApplyBuffEffect(caster);
                break;

            case CardType.Debuff:
                if (target != null)
                {
                    ApplyDebuffEffect(target);
                }
                break;

            case CardType.Conditional:
                break;

        }
    }

    private void ApplyBuffEffect(Player caster)
    {
        switch (buffEffect)
        {
            case BuffType.IncreaseDamage:
                caster.IncreaseCardDamage(amount);
                break;
            case BuffType.IncreaseManaMax:
                caster.IncreaseManaMax(amount);
                break;
            case BuffType.Heal:
                caster.Heal(amount);
                break;
        }

    }
    private void ApplyDebuffEffect(Player target)
    {
        switch (debuffEffect)
        {
            case DebuffType.CancelEffect:
                target.SetCancelEffect(true);
                break;
            
            case DebuffType.ReduceDamage:
                target.ModifyDamage(amount);
                break;
            
            case DebuffType.ReduceMana:
                target.ReduceMana(amount);
                break;
            
            case DebuffType.IncreaseManaCost:
                target.IncreaseCardManaCost(amount);
                break;
        }
    }

}
