using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BagItem", menuName = "MyStuff/BagItem", order = 1)]
public class BagItem : ScriptableObject
{
    public string crop;
    public string seeds;
    public int supplyYield;
    public int cropYield;
    public int seedYield;
    public int fertilizerYield;
    public int growTime;
    public Sprite Image;
    public bool isSeed;
    public GameObject plant;
    public bool isCrop;
    public bool isFertilizer;
    public int hungerWorth;

}
