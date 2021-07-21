using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    static public ScoreCounter Instance { get; private set; }

    [SerializeField] private Text output;
    [SerializeField] private float score = 0;

    public float Score { get => score; private set => score = value; }

    void Start()
    {
        Instance = this;
        updateScore();
    }

   

    public void takeAway(float scr)
    {
        score -= scr;
        updateScore();
    }
    public void add(float scr)
    {
        score += scr;
        updateScore();
    }

    public void updateScore()
    {
        output.text = $"{score}";
    }

}
