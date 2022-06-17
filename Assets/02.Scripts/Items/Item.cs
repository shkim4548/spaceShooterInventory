using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newItem", menuName = "Create New Item")]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        atk,
        def,
        rec
    }

    public string itemName;
    public Sprite itemImage;
    public ItemType itemType;

    public float atk;
    public float def;
    public float rec;
}
