using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrenght;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public GameObject wingNormal;
    public GameObject wingFlapped;
    private float wingTimer = 0;
    private bool timerStarted = false;
    public float flapTime;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive)
        {
            myRigidBody.velocity = Vector2.up * flapStrenght;
            flap();
            timerStarted = true;
        }

        if (transform.position.y < -17.4 || transform.position.y > 17.4)
        {
            checkBirdAndGameOver();
        }

        if (timerStarted)
        {
            wingTimer += Time.deltaTime;
            if (wingTimer >= flapTime)
            {
                timerStarted = false;
                unflap();
                wingTimer = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        checkBirdAndGameOver();
    }

    private void flap()
    {
        wingFlapped.SetActive(true);
        wingNormal.SetActive(false);
    }

    private void unflap()
    {
        wingFlapped.SetActive(false);
        wingNormal.SetActive(true);
    }

    private void checkBirdAndGameOver()
    {
        if (birdIsAlive == true)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }
}
