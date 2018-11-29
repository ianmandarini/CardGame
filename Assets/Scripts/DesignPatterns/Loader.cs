using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader<R>: Singleton<Loader<R>> where R: ScriptableObject
{
    private Dictionary<string, R> dict = new Dictionary<string, R>();

    public override void onAwake() {
        this.loadAll();
    }

    private void loadAll() {
        this.dict.Clear();
        R[] dict = (R[]) Resources.LoadAll<R>("");
        foreach(R resource in dict) {
            this.dict[resource.name] = resource;
        }
        Debug.Log(dict.Length.ToString() + " " + typeof(R) + " loaded.");
    }

    public R get(string key) {
        if(this.dict.ContainsKey(key)) {
            return Instantiate(this.dict[key]);
        } else {
            throw new UnityException("The key " + key + " does not correspond to a " + typeof(R) + " in its Loader.");
        }
    }

    public R getRef(string key) {
        if(this.dict.ContainsKey(key)) {
            return this.dict[key];
        } else {
            throw new UnityException("The key " + key + " does not correspond to a " + typeof(R) + " in its Loader.");
        }
    }
}
