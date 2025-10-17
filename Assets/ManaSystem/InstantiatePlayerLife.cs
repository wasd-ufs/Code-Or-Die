using UnityEngine;

public class InstantiatePlayerLife : MonoBehaviour
{
    public static Life Player1 { get; private set; }
    public static Life Player2 { get; private set; }


    public void Init(int initial, int max)
    {
        Player1 = new Life(initial, max);
        Player2 = new Life(initial, max);

    }

    //Metodos para ver a vida atual
    public static int GetLifePlayer1() => Player1.GetLifePoint();
    public static int GetLifePlayer2() => Player2.GetLifePoint();
}

