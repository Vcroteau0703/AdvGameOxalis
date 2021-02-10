using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BagItem", menuName = "MyStuff/BagItem", order = 1)]
public class BagItem : ScriptableObject
{
    public string crop;
    public int supplyYield;
    public int growTime;
    public int seedYield;
    public int fertilizerYield;

}
