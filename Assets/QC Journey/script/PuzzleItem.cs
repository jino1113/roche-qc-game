using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleItem : MonoBehaviour, IPointerClickHandler
{
    public bool isIncorrectItem;
    public GameObject correctMark;
    private bool alreadyClicked = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (alreadyClicked) return;
        alreadyClicked = true;

        if (isIncorrectItem)
        {
            PuzzleManager.instance.FoundIncorrectItem(this);
            correctMark.SetActive(true);
        }
        else
        {
            PuzzleManager.instance.ClickedWrongItem();
        }
    }
}
