using UnityEngine;

public class ThirdSlot : MonoBehaviour, ICardDropArea
{
    public void OnCardDrop(Cards card)
    {
        card.transform.position = transform.position;
        Debug.Log("Card dropped in Third Slot: " + card.name);

    }
}
