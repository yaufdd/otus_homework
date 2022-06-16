using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIthings : MonoBehaviour
{
    public CharacterComponent player1;
    public CharacterComponent player2;
    
    [SerializeField] private Text player1_txt;
    [SerializeField] private Text player2_txt;
    private void Update()
    {
        player1_txt.text = $"{player1.health}";
        player2_txt.text = $"{player2.health}";
        
    }
}
