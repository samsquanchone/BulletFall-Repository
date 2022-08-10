using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WaveData")]
public class WaveData : ScriptableObject
{
    public int enemyCount = 5;
    public float spawnTimerLimit= 5f;
}
