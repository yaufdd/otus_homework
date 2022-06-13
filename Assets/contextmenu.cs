using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contextmenu : MonoBehaviour
{
    public CharacterComponent player1_info;
    public CharacterComponent player2_info;

    [ContextMenu("Player1_Health")]
    void Player1_Health()
    {
        Debug.Log(player1_info.health);
    }
    [ContextMenu("Player1_Power")]
    void Player1_Power()
    {
        Debug.Log(player1_info.attack);
    }
    
    [ContextMenu("Player2_Health")]
    void Player2_Health()
    {
        Debug.Log(player2_info.health);
    }
    [ContextMenu("Player2_Power")]
    void Player2_Power()
    {
        Debug.Log(player2_info.attack);
    }

    
    
    
    
}
