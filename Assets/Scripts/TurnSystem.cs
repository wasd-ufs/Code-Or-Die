using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public enum PlayerTurn
{
    Player1,
    Player2
}

public class TurnSystem : MonoBehaviour
{
    private PlayerTurn currentTurn;
    public TextMeshProUGUI turnText;
    public Button player1ActionButton;
    public Button player2ActionButton;

    void Start()
    {
        StartTurn(PlayerTurn.Player1);
    }
    private void StartTurn(PlayerTurn turn)
    {
        currentTurn = turn;

        if (currentTurn == PlayerTurn.Player1)
        {
            turnText.text = "Turno do Jogador 1";
            
            player1ActionButton.interactable = true;
            player2ActionButton.interactable = false;
        }
        else
        {
            turnText.text = "Turno do Jogador 2";

            player1ActionButton.interactable = false;
            player2ActionButton.interactable = true;
        }
    }
    public void EndTurn()
    {
        if (currentTurn == PlayerTurn.Player1)
        {
            StartTurn(PlayerTurn.Player2);
        }
        else if (currentTurn == PlayerTurn.Player2)
        {
            StartTurn(PlayerTurn.Player1);
        }
    }
}