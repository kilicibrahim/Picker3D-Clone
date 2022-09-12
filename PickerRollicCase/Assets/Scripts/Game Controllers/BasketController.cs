using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BasketController : MonoBehaviour
{
    public int bN;
    public int valueToPass = 20;

    private GameObject[] respawns;

    void Start()
    {
        GameEvents.current.onBasketExit += exitingBasket;
        GameEvents.current.onFailedAttemp += ClearTrack;
        GameEvents.current.onLvlFinish += ClearTrack;
    }
   

    void exitingBasket(int bN) //completing the platform track
    {
        if(bN == this.bN)
        {
            this.transform.Find("PlatformGround").gameObject.SetActive(true); //add animation
            Debug.Log("Exiting basket");
        }
        
    }

    private void ClearTrack(int lvlN)
    {
        respawns = GameObject.FindGameObjectsWithTag("pGround");
        foreach(GameObject PG in respawns)
        {
            PG.SetActive(false);
        }
    }
    private void OnDestroy()
    {
        GameEvents.current.onBasketExit -= exitingBasket;
        GameEvents.current.onFailedAttemp -= ClearTrack;
        GameEvents.current.onLvlFinish -= ClearTrack;
    }
}

