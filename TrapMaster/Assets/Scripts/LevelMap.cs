using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelMap : MonoBehaviour
{
    [SerializeField] private GameObject[] setPrefabs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateMap()
    {

    }
}

[Serializable]
public class MapLevelInfo
{
    private int level;
    private List<SetTailsInfo> setTails = new List<SetTailsInfo>();

    public int LevelNumber {  get { return level; } }

}
