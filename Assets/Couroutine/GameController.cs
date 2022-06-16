using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    [SerializeField] private CharacterComponent player1;
    [SerializeField] private CharacterComponent player2;
    public CharacterComponent characterComponent;
    private bool gameisover;
    private State state;
    private Coroutine mainCoroutine;
    private enum State
    {
        Turn1,
        Turn2
    }
    
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("BattleMusic");
        gameisover = false;
        Debug.Log("Health 1: " + player1.health);
        Debug.Log("Health 2: " + player2.health);
        mainCoroutine = StartCoroutine(GameLoop());

    }
    private IEnumerator GameLoop()
    {
        Coroutine turn = StartCoroutine(Turn());
        
        yield return new WaitUntil(() => gameisover == true);
        
        if (state == State.Turn1)
        {
            Debug.Log("player1 WIN, Player1 HP = " + player1.health + ", Player2 HP = " + player2.health );
            FindObjectOfType<AudioManager>().Play("Win");
        }
        else
        {
            Debug.Log("player2 WIN, Player2 HP = " + player2.health + ", Player1 HP = " + player1.health );
            FindObjectOfType<AudioManager>().Play("Lose");
        }
        
        StopCoroutine(turn);
        Debug.Log("FINISH");
        
    }
    private IEnumerator Turn()
    {
        while (true)
        {
       
            yield return new WaitForSeconds(1f);
            Debug.Log("player1 aiming to shoot");
            
                                           
            yield return new WaitForSeconds(1f);
            FindObjectOfType<AudioManager>().Play("ShootHit");

            yield return new WaitForSeconds(.5f);
            player2.health -= player1.attack;
            FindObjectOfType<AudioManager>().Play("TakeDamageShort");
            Debug.Log("player1 shoot!");
            state = State.Turn1;

            if (player2.health <= 0)
            {
                gameisover = true;
                break;
            }
            
            
            yield return new WaitForSeconds(1f);
            Debug.Log("player 1 finished turn");
            
            
            yield return new WaitForSeconds(1f);
            Debug.Log("player2 run to player1");

            yield return new WaitForSeconds(.5f);
            FindObjectOfType<AudioManager>().Play("HandHit");
            
            
            yield return new WaitForSeconds(1f);               
            player1.health -= player2.attack;
            FindObjectOfType<AudioManager>().Play("TakeDamageShort");
            Debug.Log("player2 attack!");
            state = State.Turn2;
            
            if (player1.health <= 0)
            {
                gameisover = true;
                break;
            }
            
            yield return new WaitForSeconds(1f);
            Debug.Log("player2 run to default position");
            
            
            yield return new WaitForSeconds(1f);
            Debug.Log("player 2 finished turn");


            
            yield return new WaitForSeconds(2f);
            float number = Random.Range(0, 1);
            FindObjectOfType<AudioManager>().Play("Lightning");
            switch (number)
            {
                case  0f:
                    player1.health -= 3;
                    Debug.Log("Random Lightning damaged player1! " + number);
                    break;
                case  1f:
                    player2.health -= 3;
                    Debug.Log("Random Lightning damaged player2! " + number);
                    break;
            }

            if (player1.health > 0 && player2.health > 0) continue;
            gameisover = true;
            break;

        }
    }

    

    
}

    

