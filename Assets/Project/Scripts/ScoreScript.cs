using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreTest = 0;
    Text Score;

    // Start is called before the first frame update
    void Start()
    {
        Score = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreTest < 10)
        {
            Score.text = "00" + scoreTest.ToString();
        }
        else if (scoreTest < 100)
        {
            Score.text = "0" + scoreTest.ToString();
        }
    }
}
