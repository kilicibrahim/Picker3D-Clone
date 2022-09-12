using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public int lvlN = 1;
    private bool isLvlFinished = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            if(!isLvlFinished)
            {
                Debug.Log("YOU WIN!");
                lvlN += 1;
                GameEvents.current.LvlFinish(lvlN);
                isLvlFinished = true;
            }
            
        }
    }
}
