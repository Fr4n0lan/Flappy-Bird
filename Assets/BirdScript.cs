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

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive) {
            myRigidBody.velocity = Vector2.up * flapStrenght;
        }

        if (transform.position.y < -17.4 || transform.position.y > 17.4)
        {
            checkBirdAndGameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        checkBirdAndGameOver();
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
