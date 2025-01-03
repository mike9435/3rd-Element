using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    private GameObject player;
    private float distance;

    public GameObject[] grassEnemyArray;
    public int currentGrassEnemyAmount;
    public GameObject[] fireEnemyArray;
    public int currentFireEnemyAmount;
    public GameObject[] waterEnemyArray;
    public int currentWaterEnemyAmount;
    public GameObject[] bannerArray;
    public int currentBannerAmount;

    public GameObject openDoor;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        GameObject[] grassEnemyArray = GameObject.FindGameObjectsWithTag("Grass Enemy");
        currentGrassEnemyAmount = grassEnemyArray.Length;
        GameObject[] fireEnemyArray = GameObject.FindGameObjectsWithTag("Fire Enemy");
        currentFireEnemyAmount = fireEnemyArray.Length;
        GameObject[] waterEnemyArray = GameObject.FindGameObjectsWithTag("Water Enemy");
        currentWaterEnemyAmount = waterEnemyArray.Length;
        GameObject[] bannerArray = GameObject.FindGameObjectsWithTag("Banner");
        currentBannerAmount = bannerArray.Length;

        distance = Vector2.Distance(player.transform.position, transform.position);

        if ((Mathf.Abs(distance) < 3 && Input.GetKeyDown(KeyCode.E)) && grassEnemyArray.Length == 0 && fireEnemyArray.Length == 0 && waterEnemyArray.Length == 0 && bannerArray.Length == 0)
        {
            Instantiate(openDoor,transform.position,quaternion.identity);
            Destroy(gameObject);
        }
    }
}
