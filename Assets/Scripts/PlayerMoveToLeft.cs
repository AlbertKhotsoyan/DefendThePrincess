using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveToLeft : MonoBehaviour
{
    [SerializeField]

    public float speed = 0.1f;
    private float tempSpeed;
    // Start is called before the first frame update
    void Start()
    {
        tempSpeed = speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.left * speed, Camera.main.transform);
    }

    void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.tag == "mob_player")
        {
            speed = 0;
        }
        else if (enemy.gameObject.tag == "mob_enemy") 
        {

        }

    }

    void OnCollisionExit2D(Collision2D enemy)
    {
        if (enemy.gameObject.tag == "mob_player" || enemy.gameObject.tag == "mob_enemy")
            speed = tempSpeed;
    }
}
