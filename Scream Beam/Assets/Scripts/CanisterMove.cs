using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CanisterMove : MonoBehaviour {
    public float moveSpeed;
    private int choice;
    public float maxTimer = 2;
    private float timer;
    private bool canDoStuff = false;
    public string PowerupName;
    private int PowerupChoice;

    void OnEnable()
    {
        canDoStuff = true;
        PowerupChoice = Random.Range(1, 2);

        switch(PowerupChoice)
        {
            case 1:
                PowerupName = "Canister";
                return;
            case 2:
                PowerupName = "Canister";
                return;
        }
    }
    void Update()
    {
        if (canDoStuff == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                RandomMove();
                timer = maxTimer;
            }
        }

        if(this.gameObject.transform.position.y < 150)
        {
            this.gameObject.SetActive(false);
        }
    }
    void RandomMove()
    {
        choice = Random.Range(1, 5);

        switch(choice)
        {
            case 1:
                MoveRight();
                return;
            case 2:
                MoveLeft();
                return;
            case 3:
                MoveDown();
                return;
            case 4:
                MoveDown();
                return;
            case 5:
                MoveDown();
                return;
        }
    }
    void MoveRight()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.right * moveSpeed, ForceMode2D.Impulse);
    }
    void MoveLeft()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.left * moveSpeed, ForceMode2D.Impulse);
    }
    void MoveDown()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.down * moveSpeed, ForceMode2D.Impulse);
    }
}
