using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isdead;
    // Start is called before the first frame update
    void Start()
    {
        isdead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isdead && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void SetIsDead()
    {
        isdead = true;
    }
}
