using UnityEngine;

public class InstantiatePlayerController : MonoBehaviour
{
    public static PlayerController Player1 { get; private set; }
    public static PlayerController Player2 { get; private set; }


    public void Init(int initialLife, int maxLife,int initialMana, int maxMana)
    {
        Player1 = new PlayerController(initialLife, maxLife, initialMana, maxMana);
        Player2 = new PlayerController(initialLife, maxLife, initialMana, maxMana);

    }

    //Metodos para ver os status do player atual
    public static int GetLifePlayer1() => Player1.GetLifePoint();
    public static int GetManaPlayer1() => Player1.GetManaPoint();
    public static int GetLifePlayer2() => Player2.GetLifePoint();
    public static int GetManaPlayer2() => Player2.GetManaPoint();

}
