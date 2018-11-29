using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 clickDelta;
    private Vector3 cardPosition;

    public CardBuilder cardBuilderScript;

    private Vector3 pointerEventDataToScreenPosition(PointerEventData data) {
        Ray ray = Camera.main.ScreenPointToRay(data.position);
        return ray.GetPoint(Vector3.Distance(transform.position, Camera.main.transform.position));
    }

    public void OnBeginDrag(PointerEventData data)
    {
        clickDelta = this.pointerEventDataToScreenPosition(data);
        clickDelta -= transform.position;
        clickDelta.z = 0;
        this.cardPosition = this.transform.position;
        InteractionManager.Instance.startDraggingCard(this.cardBuilderScript.getCard());
    }

    public void OnDrag(PointerEventData data)
    {
        transform.position = this.pointerEventDataToScreenPosition(data) - clickDelta;
    }

    public void OnEndDrag(PointerEventData data)
    {
        this.transform.position = this.cardPosition;
        InteractionManager.Instance.cancelDraggingCard();
    }

}
