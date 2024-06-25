using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalTimeText;

    void Start()
    {
        // Ambil waktu dari PlayerPrefs
        float finalTime = PlayerPrefs.GetFloat("FinalTime", 0f);

        int minutes = Mathf.FloorToInt(finalTime / 60);
        int seconds = Mathf.FloorToInt(finalTime % 60);
        finalTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
