using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BannerSpawner : MonoBehaviour
{

    //This code will:
    //start spawning an enemy every 10 seconds when player is within 12 units
    //Spawned enemy must be outside of wall (1 unit below)
    //Can be destroyed after 3 hits

    private bool canSpawn;
    private float timer;
    public float spawningCooldown = 10f;

    public GameObject enemyType;

    private GameObject player;
    private float distance;

    private int bannerHealth = 3;
    private SpriteRenderer currentSprite;
    private Material currentMaterial;
    public Material whiteMaterial;
    public GameObject bannerSpriteGameObject;
    public GameObject brokenWall;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        canSpawn = true;

        bannerSpriteGameObject = gameObject;
        currentSprite = bannerSpriteGameObject.GetComponent<SpriteRenderer>();
        currentMaterial = currentSprite.material;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(player.transform.position, transform.position);

        if (!canSpawn)
        {
            timer += Time.deltaTime;
            if (timer > spawningCooldown)
            {
                canSpawn = true;
                timer = 0;
            }
        }
        if (canSpawn && distance <13)
        {
            Instantiate(enemyType, transform.position - new Vector3(0,1),Quaternion.identity);
            canSpawn = false;
        }
    }
    public void BannerHit()
    {
        bannerHealth--;
        currentSprite.material = whiteMaterial;
        if (bannerHealth <= 0)
        {
            Instantiate(brokenWall,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            Invoke("ResetMaterial", 0.1f);
        }
    }
    private void ResetMaterial()
    {
        currentSprite.material = currentMaterial;
    }
}
