using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandWatcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DeckManager.Instance.onHandChange.subscribe(this.onHandChange);
        this.onHandChange();
    }

    private void onHandChange() {
		this.destroyChildren();
		foreach(Card card in DeckManager.Instance.getHand()) {
            GameObject newInstance = Instantiate(Resources.Load("RuntimePrefabs/Card"), this.transform) as GameObject;
            CardBuilder cardBuilderScript = newInstance.GetComponent<CardBuilder>();
            cardBuilderScript.buildWithCard(card);
		}
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
