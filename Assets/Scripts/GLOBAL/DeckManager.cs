using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DeckManager : Singleton<DeckManager>
{

    private List<Card> deck = new List<Card>();
    private List<Card> hand = new List<Card>();
    private List<Card> discard = new List<Card>();

    public Obs onHandChange = new Obs();


    // Start is called before the first frame update
    void Start()
    {
        this.prepare();
    }

    public void prepare() {
        this.deck.Clear();
        this.discard.Clear();
        this.hand.Clear();
        this.deck = new List<Card>(PlayerManager.Instance.getDeck());
        Debug.Log(this.deck.Count + " cards are in the deck.");
        this.onHandChange.trigger();
    }

    public void shuffleDeck() {
        this.deck = this.deck.OrderBy( x => Random.value ).ToList();
    }

    public List<Card> getHand() {
        return this.hand;
    }

    public List<Card> getDeck() {
        return this.deck;
    }

    public List<Card> getDiscard() {
        return this.discard;
    }

    public void draw() {
        if(this.deck.Count > 0) {
            this.hand.Add(this.deck[0]);
            this.deck.RemoveAt(0);
            this.onHandChange.trigger();
        } else {
            this.triggerFatigue();
        }
    }

    public void triggerFatigue() {
        Debug.Log("FATIGUE!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
