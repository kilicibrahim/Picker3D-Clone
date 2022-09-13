using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerTrigger : MonoBehaviour
{
    public int bN=0;
    public static bool onBasketExit = true;
    private void OnTriggerEnter(Collider other)
    {
        string nameHolder = other.transform.gameObject.name; //Our Gameobjects have spesific names so that I could use this solition 
        char lastCharacter = nameHolder[nameHolder.Length - 1];
        if (other.gameObject == GameObject.Find("Basket" + lastCharacter)) // we need to know which specific basket entry we are at 
        {
            if(onBasketExit)
            {
            PickerMovement.canMove = false;
        //    Debug.Log("stoped");
            GameEvents.current.BasketEnter(bN);
            onBasketExit = false;
            Invoke("LetPickerGo", 5f);//easy way out, change this and add logic
            }
        }
        
    }

    private void LetPickerGo()
    {
        onBasketExit = true;
    }

}
