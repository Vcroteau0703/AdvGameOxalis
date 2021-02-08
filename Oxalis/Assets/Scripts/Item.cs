using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    public enum ItemType
    {
        Carrot,
        CarrotSeed,
        Corn,
        CornSeed,
        Fertilizer,
    }

    public ItemType itemType;
    public int amount;
}
