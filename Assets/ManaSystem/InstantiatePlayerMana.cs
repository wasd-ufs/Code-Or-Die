using UnityEngine;

public class InstantiatePlayerMana : MonoBehaviour
{
    public static Mana Player1 { get; private set; }
    public static Mana Player2 { get; private set; }


    public void Init(int initial, int max)
    {
        Player1 = new Mana(initial, max);
        Player2 = new Mana(initial, max);
    }

    //Metodos para ver a mana atual
    public static int GetManaPlayer1() => Player1.GetCurrent();
    public static int GetManaPlayer2() => Player2.GetCurrent();
}
