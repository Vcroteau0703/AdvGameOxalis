using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    public enum ItemType
    {
        Potato,
        PotatoSeed,
        Corn,
        CornSeed,
        Fertilizer,
    }

    public ItemType itemType;
    public int amount;
}
