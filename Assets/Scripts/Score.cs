using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Unit

public class Score : MonoBehaviour
{
    
   private int score = 0;
    [SerializeField] Text scoreText;
    [SerializeField] Slider slider;
  
    void Awake()
    {
         
    }
    void Start()
    {
       slider.value = 100;  
    }

    // Update is called once per frame
  

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString("000000000");
       
    }
    public void ResetScore()
    {
        score = 0;
    }

    public void SetSliderHealth(int health)
    {
      slider.value = health;
    }
}
