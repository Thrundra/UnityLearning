using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpriteSpawner : MonoBehaviour
{
    public GameObject prefabSpriterObject;
    public float delay = 1f;
    public int numberOfSprites = 2;
    private float timer;
    private int countSprites = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = delay;
    }

    // Update is called once per frame
    void Update()
    {


            timer -= Time.deltaTime;

            if (timer <= 0 && countSprites < numberOfSprites)
            {
                SpawnSprite();
                timer = delay;
                countSprites++;
            }

    }

    void SpawnSprite()
    {
        Instantiate(prefabSpriterObject, transform.position, Quaternion.identity);
        Debug.Log("Sprite Spawned");
    }
}
