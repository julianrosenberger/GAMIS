using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorepanel : MonoBehaviour
{
    [SerializeField]
    private Sprite[] digits;

    [SerializeField]
    private Image[] characters;

    public static int scoreAmount = 0;

    private int numberOfDigitsInScoreAmount;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 2; i++)
        {
            characters[i].sprite = digits[0];
        }

        scoreAmount = 0;

        ScoreArea.Balling += AddScoreAndDisplayIt;
    }

    private void AddScoreAndDisplayIt(int scoreValue)
    {
        scoreAmount += scoreValue;

        Debug.Log("+ " + scoreValue);


        int[] scoreAmountByDigitsArray = GetDigitsArrayFromScoreAmount(scoreAmount);

        switch (scoreAmountByDigitsArray.Length)
        {
            // if array_length is 1 then last number displays our score
            case 1:
                characters[0].sprite = digits[0];
                characters[1].sprite = digits[0];
                characters[2].sprite = digits[scoreAmountByDigitsArray[0]];
                break;
            case 2:
                characters[0].sprite = digits[0];
                characters[1].sprite = digits[scoreAmountByDigitsArray[0]];
                characters[2].sprite = digits[scoreAmountByDigitsArray[1]];
                break;
            case 3:
                characters[0].sprite = digits[scoreAmountByDigitsArray[0]];
                characters[1].sprite = digits[scoreAmountByDigitsArray[1]];
                characters[2].sprite = digits[scoreAmountByDigitsArray[2]];
                break;
        }
    }

    private int[] GetDigitsArrayFromScoreAmount(int scoreAmount)
    {
        // create a list which contains digits from scoreAmount
        List<int> listOfInts = new List<int>();
        while (scoreAmount > 0)
        {
            // add last digit of scoreAmount to list
            listOfInts.Add(scoreAmount % 10);
            // cut last digit off
            scoreAmount = scoreAmount / 10;
        }
        listOfInts.Reverse();
        return listOfInts.ToArray();
    }

    
    private void OnDestroy()
    {
        ScoreArea.Balling -= AddScoreAndDisplayIt;
    }
}
