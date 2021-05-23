using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEgg : MonoBehaviour
{
    [SerializeField]
    public int health;
    public int currentHealth;
    public GameObject greenDragon;
    private string layerName;
    DragonSpawner dragonSpawner;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        currentHealth = health;
        dragonSpawner = gameObject.AddComponent<DragonSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        GetComponent<Animator>().SetTrigger("Hit");
        GetHit(1);
    }
    public void GetHit(int damage)
    {
        currentHealth = health - damage;
        if (health <= 0)
        {
            layerName = gameObject.GetComponent<SpriteRenderer>().sortingLayerName;
            dragonSpawner.SpawnDragon(greenDragon, transform.position, layerName);
            Destroy(gameObject);
        }
        health = currentHealth;
    }
}
