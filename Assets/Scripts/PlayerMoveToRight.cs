using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveToRight : MonoBehaviour
{
    [SerializeField]

    public float speed = 0.1f;
    public GameObject fightEffect;
    private float tempSpeed;
    // Start is called before the first frame update
    void Start()
    {
        tempSpeed = speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed, Camera.main.transform);
    }

    void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.tag == "mob_enemy")
        {
            speed = 0;
            fightEffect.SetActive(true);
        }
        else if (enemy.gameObject.tag == "mob_player")
        {
            
        }

    }

    void OnCollisionExit2D(Collision2D enemy)
    {
        if (enemy.gameObject.tag == "mob_enemy" || enemy.gameObject.tag == "mob_player")
        {
            speed = tempSpeed;
            fightEffect.SetActive(false);
        }

    }
}
