using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    int enemyHealth = 3;
    float enemySpeed = 3.5f;

    GameObject player;

    private SpriteRenderer currentSprite;
    private Material currentMaterial;
    public Material whiteMaterial;
    public GameObject enemySpriteGameObject;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        currentSprite = enemySpriteGameObject.GetComponent<SpriteRenderer>();
        currentMaterial = currentSprite.material;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
    }

    public void EnemyHitSuperEffective() 
    {
        Destroy(gameObject);
    }

    public void EnemyHit()
    {
        enemyHealth--;
        currentSprite.material = whiteMaterial;
        if (enemyHealth <= 0)
        {
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
