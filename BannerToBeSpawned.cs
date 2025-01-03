using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class BannerToBeSpawned : MonoBehaviour
{

    private bool canSpawn;
    private GameObject player;
    private float distance;

    public GameObject banner;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(player.transform.position, transform.position);
        if (canSpawn && distance < 13)
        {
            Instantiate(banner, transform.position, Quaternion.identity);
            canSpawn = false;
            Destroy(gameObject);
        }
    }
}
