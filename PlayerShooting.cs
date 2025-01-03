using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject grassBullet;
    public GameObject fireBullet;
    public GameObject waterBullet;
    private GameObject selectedBullet;

    public bool canShoot;
    private float timer;
    public float shootingCooldown = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        selectedBullet = grassBullet;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedBullet = grassBullet;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedBullet = fireBullet;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedBullet = waterBullet;
        }

        if (!canShoot)
        {
            timer += Time.deltaTime;
            if (timer > shootingCooldown)
            {
                canShoot = true;
                timer = 0;
            }
        }
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Instantiate(selectedBullet, transform.position + (transform.up), transform.rotation);
            canShoot = false;
        }
    }
}
