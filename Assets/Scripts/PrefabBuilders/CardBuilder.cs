using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBuilder : MonoBehaviour
{
    public Card card;

    // -------------------------------------
    public GameObject minionGameObject;
    public Image minionArtwork;
    public Text minionCardText;
    public Text minionDisplayName;
    public Text minionCardCost;
    public Text minionAttackValue;
    public Text minionDefenseValue;


    // -------------------------------------
    public GameObject spellGameObject;
    public Text spellDisplayName;
    public Image spellArtwork;
    public Text spellCardText;
    public Text spellCardCost;

    public void buildWithCard(Card card) {
        this.card = card;
        this.minionGameObject.SetActive(false);
        this.spellGameObject.SetActive(false);
        if(card.type == CardType.MINION) {
            this.minionGameObject.SetActive(true);
            this.minionArtwork.sprite = card.artwork;
            this.minionDisplayName.text = card.displayName;
            this.minionCardText.text = card.text;
            this.minionCardCost.text = card.cost.ToString();
            this.minionAttackValue.text = card.attack.ToString();
            this.minionDefenseValue.text = card.defense.ToString();
        }
        if(card.type == CardType.SPELL) {
            this.spellGameObject.SetActive(true);
            this.spellArtwork.sprite = card.artwork;
            this.spellDisplayName.text = card.displayName;
            this.spellCardText.text = card.text;
            this.spellCardCost.text = card.cost.ToString();
        }
    }

    public void Start() {
        if(this.card != null) {
            this.buildWithCard(this.card);
        }
    }

    public Card getCard() {
        return this.card;
    }

}
