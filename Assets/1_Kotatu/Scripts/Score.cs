using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score;
    [SerializeField] Text ScoreText;

    private int matchRate;
    [SerializeField] Text MatchRateText;
    [SerializeField] Slider MatchRateSlider;

    void Start()
    {
        score =  280;
        ScoreText.text = score.ToString();

        matchRate = 65;
        MatchRateText.text = matchRate.ToString();

        MatchRateSlider.value = matchRate;
    }

    void Update()
    {
        
    }
}
