using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new item", menuName = "item")]
public class Item : ScriptableObject
{
    public new string name;
    public string displayText;
    public string description;
    public Sprite sprite;
    public GameObject itemGameObject;
}
