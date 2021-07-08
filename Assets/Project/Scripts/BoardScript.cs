using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
    public AudioSource bounceSource;

    // Start is called before the first frame update
    void Start()
    {
        bounceSource = GetComponent<AudioSource> ();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.GetComponent<Ball>() != null)
        {
            bounceSource.Play();
        }
    }
}
