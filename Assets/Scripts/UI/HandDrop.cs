using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HandDrop : MonoBehaviour, IDropHandler
{
    private Vector3 pointerEventDataToScreenPosition(PointerEventData data) {
        Ray ray = Camera.main.ScreenPointToRay(data.position);
        return ray.GetPoint(Vector3.Distance(transform.position, Camera.main.transform.position));
    }

    public void OnDrop(PointerEventData data)
    {
        RectTransform handPanel = this.transform as RectTransform;
        if(!RectTransformUtility.RectangleContainsScreenPoint(handPanel, this.pointerEventDataToScreenPosition(data))) {
            InteractionManager.Instance.useDraggedCard();
        }
    }

}
