using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewCard", menuName = "Custom/Card", order = 1)]
public class Card : ScriptableObject
{
    public Sprite artwork;
    public CardType type;
    public string displayName;
    public string text;
    public int cost;
    public int attack;
    public int defense;

}