using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBall : MonoBehaviour
{
    [SerializeField] public GameObject respawn;

    public void OnTriggerEnter2D(Collider2D ball)
    {
        if (ball.gameObject.tag == "Ball")
        {
            ball.gameObject.transform.position = respawn.transform.position;
        }
    }
}
