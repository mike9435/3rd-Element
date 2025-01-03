using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpellUIManager : MonoBehaviour
{
    public Sprite grassBullet;
    public Sprite fireBullet;
    public Sprite waterBullet;
    private Sprite selectedBullet;

    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        selectedBullet = grassBullet;
    }

    // Update is called once per frame
    void Update()
    {
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
        image.sprite = selectedBullet;
    }
}
