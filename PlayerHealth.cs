using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public GameObject blip1;
    public GameObject blip2;
    public GameObject blip3;
    public GameObject blip4;
    public GameObject blip5;

    private bool invulnerable = false;
    Renderer ren;

    public GameManager manager;
    public GameObject youdiedtext;
    // Start is called before the first frame update
    void Start()
    {
        health = 5;

        ren = gameObject.GetComponent<Renderer>();

        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Grass Enemy" || collision.gameObject.tag == "Water Enemy" || collision.gameObject.tag == "Fire Enemy") && invulnerable == false)
        {
            TakeDamage();
        }
    }
    public void TakeDamage()
    {
        invulnerable = true;
        health--;
        if (health == 4)
        {
            blip5.SetActive(false);
        }
        if (health == 3)
        {
            blip4.SetActive(false);
        }
        if (health == 2)
        {
            blip3.SetActive(false);
        }
        else if (health == 1)
        {
            blip2.SetActive(false);
        }
        else if (health <= 0)
        {
            blip1.SetActive(false);
            manager.SetIsDead();
            youdiedtext.SetActive(true);
            Destroy(gameObject);
        }

        StartCoroutine(InvinicibilityTimer());
    }
    IEnumerator InvinicibilityTimer()
    {
        Color lightred = new Color(1, 0.5f, 0.5f);
        ren.material.color = lightred;
        yield return new WaitForSeconds(1);
        
        Color white = new Color(1, 1, 1);
        ren.material.color = white;
        invulnerable = false;
    }
}
