using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static float timeScore;
    public static float similarityScore;

    [SerializeField] Text ScoreText;

    public int matchRate;
    [SerializeField] Text MatchRateText;
    [SerializeField] Slider MatchRateSlider;

    int timeMax = 600;

    void Start()
    {
        ScoreCulc();
        MatchRateCulc();
        ScoreText.text = score.ToString();
        Debug.Log(score);
    }

    void Update()
    {
        
    }

    void MatchRateCulc()
    {
        matchRate = Mathf.CeilToInt((255 - similarityScore) * 100) / 255;

        MatchRateText.text = matchRate.ToString();

        MatchRateSlider.value = matchRate;

        score += matchRate * 10;
    }

    public void ScoreCulc()
    {
        if(timeScore < timeMax)
        {
            score = timeMax - Mathf.CeilToInt(timeScore);
        }
        else
        {
            timeScore = 0;
        }
    }
}
