using UnityEngine;

public class SecondSlot : MonoBehaviour, ICardDropArea
{
    public void OnCardDrop(Cards card)
    {
        card.transform.position = transform.position;
        Debug.Log("Card dropped in Second Slot: " + card.name);

    }
}
