using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_PickUpData")]
public class PickUpData : ScriptableObject
{
    public int dropChance; 
    public float amountToBuff;
    public float buffDuration;
    public bool spawn = false;
    public bool destroy = false;
    public Vector3 spawnLocation;
    



}
