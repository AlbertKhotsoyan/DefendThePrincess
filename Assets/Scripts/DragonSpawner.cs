using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSpawner : MonoBehaviour
{
    private SpriteRenderer spriteLayer;

    public void SpawnDragon(GameObject dragon, Vector3 position, string layerName)
    {
        GameObject Mob_Dragon = Instantiate(dragon) as GameObject;
        Mob_Dragon.transform.position = position;

        spriteLayer = Mob_Dragon.GetComponent<SpriteRenderer>();
        spriteLayer.sortingLayerName = layerName;
        spriteLayer.sortingOrder = 0;
    }

}
