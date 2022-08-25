using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI waveNumberText;

    public WaveData waveData; //Used to increment score
    public PlayerData playerData; //Used to display players Health

    void Awake()
    {
     waveData.score = 0;
    }

    private void LateUpdate()
    {
     UpdateScore();
     UpdateHealth();
     UpdateWaveNumber();
    }

    private void UpdateScore()
    {
      scoreText.text = "Score: " + waveData.score;
    }

    private void UpdateHealth()
    {
      playerHealthText.text = "Health: " + playerData.playerHealth + "%";
    }

    private void UpdateWaveNumber()
    {
        waveNumberText.text = "Wave: " + waveData.waveNumber;
    }


    


}
