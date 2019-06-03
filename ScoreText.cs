using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
	Text scoreText;
	static public int score;
    // Start is called before the first frame update
    void Start()
    {
    	scoreText = GetComponent<Text>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }
}
