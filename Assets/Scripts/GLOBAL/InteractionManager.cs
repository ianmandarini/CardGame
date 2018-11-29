using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : Singleton<InteractionManager>
{
    private bool _isCardBeingDragged = false;
    private Card cardBeingDragged;

    // Start is called before the first frame update
    void Start() {

    }

    public void startDraggingCard(Card card) {
        this.cardBeingDragged = card;
        this._isCardBeingDragged = true;
    }

    public void cancelDraggingCard() {
        this._isCardBeingDragged = false;
    }

    public void useDraggedCard() {
        Debug.Log(cardBeingDragged.displayName + " was used!");
        this._isCardBeingDragged = false;
    }

}
