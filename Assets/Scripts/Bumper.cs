using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] private float timerMax;
    [SerializeField] private float force;
    [SerializeField] private float sizeIncreaseX;
    [SerializeField] private float sizeIncreaseY;

    private float defaultX;
    private float defaultY;
    private float defaultZ;

    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        defaultX = transform.localScale.x;
        defaultY = transform.localScale.y;
        defaultZ = transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            transform.localScale = new Vector3(defaultX, defaultY, defaultZ);
        }
    }

    void OnCollisionEnter2D(Collision2D collide)
    {
        if (timer <= 0)
        {
            collide.rigidbody.AddForce(-collide.contacts[0].normal * force, ForceMode2D.Impulse);
            timer = timerMax;
            transform.localScale = new Vector3(sizeIncreaseX, sizeIncreaseY, 1f);
        }
    }
}
