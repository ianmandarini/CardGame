using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    private Hero hero;
    private int health = 0;
    private int maxHealth = 100;
    private int madness = 0;
    private int maxMadness = 100;
    private int insight = 0;

    private List<Card> deck = new List<Card>();

    public Obs onHeroChange = new Obs();
    public Obs onStatsChange = new Obs();

    // Start is called before the first frame update
    void Start() {
        this.setup(HeroesManager.Instance.get("JUDAS"));
    }

    public void setup(Hero hero) {
        this.hero = hero;
        this.maxHealth = this.hero.maxHealth;
        this.maxMadness = this.hero.maxMadness;
        this.health = this.maxHealth;
        this.madness = 0;
        this.insight = this.hero.startingInsight;

        this.deck.Add(CardsManager.Instance.get("MADMAN"));
        this.deck.Add(CardsManager.Instance.get("BABY_CHTULU"));
        this.deck.Add(CardsManager.Instance.get("UNAWARE_VICTIM"));
        this.deck.Add(CardsManager.Instance.get("ARMED_DETECTIVE"));
        this.deck.Add(CardsManager.Instance.get("BABY_CHTULU"));

        this.onHeroChange.trigger();
        this.onStatsChange.trigger();
    }

    public int getHealth() {
        return this.health;
    }

    public int getMaxHealth() {
        return this.maxHealth;
    }

    public int getMadness() {
        return this.madness;
    }

    public int getMaxMadness() {
        return this.maxMadness;
    }

    public int getInsight() {
        return this.insight;
    }

    
    public Sprite getHeroArtwork() {
        return this.hero.artwork;
    }

    public List<Card> getDeck() {
        return this.deck;
    }
}
