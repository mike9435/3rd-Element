using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 15;

    private Enemy Enemy;
    private BannerSpawner Banner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy = collision.gameObject.GetComponent<Enemy>();
        Banner = collision.gameObject.GetComponent<BannerSpawner>();

        if (gameObject.tag == "Grass")
        {
            if (collision.gameObject.tag == "Water Enemy")
            {
                Enemy.EnemyHitSuperEffective();
                Destroy(gameObject);
            }
            if (collision.gameObject.tag == "Grass Enemy")
            {
                Enemy.EnemyHit();
                Destroy(gameObject);
            }
            if (collision.gameObject.tag == "Fire Enemy")
            {
                Enemy.EnemyHit();
                Destroy(gameObject);
            }
        }

        if (gameObject.tag == "Fire")
        {
            if (collision.gameObject.tag == "Water Enemy")
            {
                Enemy.EnemyHit();
                Destroy(gameObject);
            }
            if (collision.gameObject.tag == "Grass Enemy")
            {
                Destroy(gameObject);
                Enemy.EnemyHitSuperEffective();
            }
            if (collision.gameObject.tag == "Fire Enemy")
            {
                Enemy.EnemyHit();
                Destroy(gameObject);
            }
        }

        if (gameObject.tag == "Water")
        {
            if (collision.gameObject.tag == "Water Enemy")
            {
                Enemy.EnemyHit();
                Destroy(gameObject);
            }
            if (collision.gameObject.tag == "Grass Enemy")
            {
                Enemy.EnemyHit();
                Destroy(gameObject);
            }
            if (collision.gameObject.tag == "Fire Enemy")
            {
                Destroy(gameObject);
                Enemy.EnemyHitSuperEffective();
            }
        }

        if (collision.gameObject.tag == "Walls")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Banner")
        {
            Banner.BannerHit();
            Destroy(gameObject);
        }
    }
}
