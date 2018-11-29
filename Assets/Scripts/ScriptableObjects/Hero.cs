using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewHero", menuName = "Custom/Hero", order = 1)]
public class Hero : ScriptableObject
{
    public string heroName;
    public Sprite artwork;    
    public int maxHealth;
    public int maxMadness;
    public int startingInsight;

}