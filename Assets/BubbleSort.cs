using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : MonoBehaviour
{
    
    
   public int[] arr = new int[100];
   
    
    // это квардратный алгоритм и пузырьковая сортировка вместе получается
   [ContextMenu("Bubble")]
    public void Bubble()
    {

        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int swap = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = swap;
                }
            }
            
        }
        
    }
    
    //Это линейный алгоритм
    [ContextMenu("AddValue")]
    public void AddValue()
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = Random.Range(0, 100);
        }
    }
}
