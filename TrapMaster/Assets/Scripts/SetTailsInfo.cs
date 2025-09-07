using System;
using UnityEngine;

[Serializable]
public class SetTailsInfo : MonoBehaviour
{
    //  roadCross - 0, roadTailV - 1, roadTailH - 2, roadThreeCrossR - 3, roadThreeCrossD - 4, roadThreeCrossL - 5, roadThreeCrossU - 6, 
    //  roadAngleUR - 7, roadAngleDR - 8, roadAngleDL - 9, roadAngleUL - 10, roadEndD - 11, roadEndL - 12, roadEndU - 13, roadEndR - 14,
    //  roadPable - 15
    //  stoneCross - 20, stoneTailV - 21, stoneTailH - 22, stoneThreeCrossU - 23,  stoneThreeCrossR - 24, stoneThreeCrossD - 25, stoneThreeCrossL - 26,
    //  stoneAngleUL - 27, stoneAngleUR - 28, stoneAngleDR - 29, stoneAngleDL - 30
    //  stoneTample - 40, portal - 41, roadSpawn - 42, pole - 43, poleSpawn - 44 

    //  road - 0, stoneTail - 1, stoneAngle - 2, Tample - 3, Spawn - 4, portal - 5, pole - 6, roadPable - 7

    [SerializeField] private int setID;
    [SerializeField] private int[] tails = new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    public int ID { get { return setID; } }
}
