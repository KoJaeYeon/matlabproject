using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public GameObject UI;
    public GameObject ball;

    public Ball Ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Deactive();
        }
    }

    public void Deactive()
    {
        if (UI.gameObject.activeSelf == true)
        {
            UI.gameObject.SetActive(false);
        }
        else
        {
            UI.gameObject.SetActive(true);
        }
    }

    public void playball()
    {
        ball.SetActive(false);
        ball.SetActive(true);
        StartCoroutine(Ball.WaitAndPrint());


    }

    public void trajmodi()
    {

    }
}
