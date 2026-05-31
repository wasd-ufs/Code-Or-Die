using UnityEngine;

public class FirstSlot : MonoBehaviour, ICardDropArea
{
    public void OnCardDrop(Cards card)
    {
        card.transform.position = transform.position;
        Debug.Log("Card dropped in First Slot: " + card.name);
        
    }
}
