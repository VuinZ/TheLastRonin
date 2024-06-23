using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalTimeText;

    void Start()
    {
        float finalTime = PlayerPrefs.GetFloat("FinalTime", 0);
        int minutes = Mathf.FloorToInt(finalTime / 60);
        int seconds = Mathf.FloorToInt(finalTime % 60);
        finalTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
