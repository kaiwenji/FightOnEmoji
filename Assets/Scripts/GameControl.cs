using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public bool gameOver;
    private float startTime;
    public GameObject gameOverText;
    public GameObject successText;
//    public GameObject terminalObj;
//    public CircleScript outer;
//    public innerCircleScript inner;
//    private bool isShrinked;
    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        gameOverText.SetActive(false);
        successText.SetActive(false);
        gameOver = false;
//        isShrinked = false;
//        startTime = Time.time;
//        inner.setNewCentroid(outer.getCenter(), outer.getRadius());
    }

//    // Update is called once per frame
//    void Update()
//    {
//        float deltaTime = Time.time - startTime;
//        if (deltaTime >= 10f)
//        {
//            if (outer.getRadius() > 0.2f)
//            {
//                if (!isShrinked)
//                {
//                    Vector2 speed = calSpeed();
//                    outer.shrink(speed.x / 100, speed.y / 100);
//                    isShrinked = true;
//                }
//                else
//                {
//                    inner.setNewCentroid(outer.getCenter(), outer.getRadius());
//                    isShrinked = false;
//                }
//            }
//            else
//            {
//                terminalObj.transform.position = inner.getCenter();
//                terminalObj.SetActive(true);
//            }
//
//            startTime = Time.time;
//
//        }
//    }
//    private Vector2 calSpeed()
//    {
//        return outer.getCenter() - inner.getCenter();
//    }
    public void frogDied()
    {
        gameOver = true;
        gameOverText.SetActive(true);
    }
    public void success()
    {
        gameOver = true;
        successText.SetActive(true);
    }
}
