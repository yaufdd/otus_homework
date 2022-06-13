using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;


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
        }
        else
        {
            Debug.Log("player2 WIN, Player2 HP = " + player2.health + ", Player1 HP = " + player1.health );
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
            player2.health -= player1.attack;
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
            
            
            yield return new WaitForSeconds(1f);               
            player1.health -= player2.attack;
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


            //пункт г мой вариант) сделать маханику удара молнии
            //которая  с веротностью 75% бьёт по player 2
            yield return new WaitForSeconds(2f);
            float number = Random.Range(0, 2);
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
                case  2f:
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

    

