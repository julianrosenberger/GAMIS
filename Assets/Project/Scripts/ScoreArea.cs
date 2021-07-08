using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using UnityEngine.UI;

public class ScoreArea : MonoBehaviour
{
    [SerializeField]
    private Image customImage;
    
    public static event Action<int> Balling = delegate { };
    public AudioSource cheerSource;
    public GameObject effectObject;

    public int score = 0;

    public float sec = 3f;

    private void Start()
    {
        cheerSource = GetComponent<AudioSource> ();

        if (effectObject.activeInHierarchy)
        {
            effectObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.GetComponent<Ball>() != null)
        {
            //var milliseconds = 3000;
            //Thread.Sleep(milliseconds);

            cheerSource.Play();

            ScoreScript.scoreTest += 1;

            effectObject.SetActive(true);

            score += 1;
            Balling(score);
        }
    }

    /*void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.GetComponent<Ball>() != null)
        {
            //var milliseconds = 3000;
            //Thread.Sleep(milliseconds);
            customImage.enabled = false;
        }
    }*/
}
