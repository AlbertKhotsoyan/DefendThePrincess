using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEggs : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject[] reservedEggs;
    public GameObject[] eggs;
    private int randomIndex;
    private int index;
    private int i;
    private float eggRollSpeed;
    private SpriteRenderer spriteLayer;

    public Vector3[] eggPosition;
    Vector3 spawnPoint = new Vector3(-21f, -3f, 0f);



    GreenEgg eggGreen;
    RedEgg eggRed;
    PurpleEgg eggPurple;


    // Start is called before the first frame update
    void Start()
    {
        eggRollSpeed = 6f;
        eggGreen = gameObject.GetComponentInChildren<GreenEgg>();
        eggRed = gameObject.GetComponentInChildren<RedEgg>();
        eggPurple = gameObject.GetComponentInChildren<PurpleEgg>();
        eggs[0] = eggPurple.gameObject; //Layer0
        eggs[1] = eggGreen.gameObject; //Layer1
        eggs[2] = eggRed.gameObject; //Layer2
        spriteLayer = eggs[0].GetComponent<SpriteRenderer>();
        spriteLayer.sortingLayerName = "Line0";
        spriteLayer = eggs[1].GetComponent<SpriteRenderer>();
        spriteLayer.sortingLayerName = "Line1";
        spriteLayer = eggs[2].GetComponent<SpriteRenderer>();
        spriteLayer.sortingLayerName = "Line2";
        eggPosition[0] = eggs[0].transform.position;
        eggPosition[1] = eggs[1].transform.position;
        eggPosition[2] = eggs[2].transform.position;
    }


    void FixedUpdate()
    {

        for (i = 0; i < eggs.Length; i++)
        {
            if (eggs[i] == null)
            {
                SpawnRndEgg(reservedEggs);
            }
            if (eggs[i].transform.position != eggPosition[i])
            {
                eggRolling(eggs[i],eggPosition[i]);
            }
        }
            
    }

    public void SpawnRndEgg(GameObject[] reservedEggs)
    {
        randomIndex = Random.Range(0, 3);
        index = randomIndex;
        GameObject Mob_egg = Instantiate(reservedEggs[randomIndex], spawnPoint, Quaternion.identity, transform) as GameObject;
        eggs[i] = Mob_egg;

        spriteLayer = eggs[i].GetComponent<SpriteRenderer>();
        spriteLayer.sortingLayerName = "Line" + i;
        spriteLayer.sortingOrder = 0;
    }

    public void eggRolling(GameObject eggs, Vector3 defaultEggPosition)
    {
        float step = eggRollSpeed * Time.deltaTime;
        eggs.transform.position = Vector3.MoveTowards(eggs.transform.position, defaultEggPosition, step);
    }
}
