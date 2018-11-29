using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroWatcher : MonoBehaviour
{
    public Image heroPortrait;
    public Text healthText;
    public Text madnessText;
    public Text insightText;


    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.Instance.onHeroChange.subscribe(this.onHeroChange);
    }

    private void onStatsChange() {
        this.refreshUI();
    }

    private void onHeroChange() {
        this.refreshUI();
    }

    private void refreshUI() {
		this.heroPortrait.sprite = PlayerManager.Instance.getHeroArtwork();
        this.healthText.text = PlayerManager.Instance.getHealth().ToString() + "/" + PlayerManager.Instance.getMaxHealth().ToString();
        this.madnessText.text = PlayerManager.Instance.getMadness().ToString() + "/" + PlayerManager.Instance.getMaxMadness().ToString();
        this.insightText.text = PlayerManager.Instance.getInsight().ToString();
    }

    private void destroyChildren() {
        foreach (Transform child in this.transform) {
			GameObject.Destroy(child.gameObject);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
