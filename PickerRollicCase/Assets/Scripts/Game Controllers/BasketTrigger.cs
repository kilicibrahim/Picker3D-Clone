using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// In this text we are controlling if we have enough objects to pass the basket checkpoint, if we have enough we are calling BasketExit event else we are calling FailedAttemp event
public class BasketTrigger : MonoBehaviour
{
    public int lvlN = 1; // FIX THIS

    public int bN;
    private int counter = 0;
    public int valueToPass = 20;

    public TMP_Text basketText;

    private bool isPassed = false;
    private bool isExitingBasketCalled = false;
    private void OnTriggerEnter(Collider other)
    {
        waitingBasket(bN);
    }
     private void Start()
    {
        basketText.text = counter + "/" + valueToPass;
    }
    void waitingBasket(int bN)
    {

        if (bN == this.bN)
        {
            if (basketText != null)
            {
                basketText.text = counter + "/" + valueToPass;
            }
            counter++;
            if (counter > valueToPass && isPassed ==false)
            {
                Debug.Log("PASSED!");
                isPassed = true;
            }
            if (!isExitingBasketCalled)
            {
                Invoke("CallExitingBasket", 2.5f);
                isExitingBasketCalled = true;
            }
        }
    }
    public void CallExitingBasket()
    {
        if (isPassed)
        {
            counter = 0;
            basketText.text = counter + "/" + valueToPass;           
            GameEvents.current.BasketExit(bN);
            isExitingBasketCalled = false;
            isPassed = false;
        }
        else CallFailledAttemp();
    }
    public void CallFailledAttemp()
    {
        Debug.Log("Failed");
        counter = 0;
        basketText.text = counter + "/" + valueToPass;
        isPassed = false;
        isExitingBasketCalled = false;
        GameEvents.current.FailedAttemp(lvlN);
    //    GameEvents.current.LvlStart(lvlN);
    }

}
