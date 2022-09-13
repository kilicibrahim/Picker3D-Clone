using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlController : MonoBehaviour //we have 3 platforms and 3 baskets to pass a lvl, we will create pushible object pairs for each one of them
{
    PushibleObjectController POC;
    PlatformController PC;
    void Start()
    {
        POC = this.gameObject.GetComponent<PushibleObjectController>();
        PC = this.gameObject.GetComponent<PlatformController>();
        GameEvents.current.onLvlStart += CreateLvl;
        GameEvents.current.onLvlFinish += FinishedLevel;
    }

    void CreateLvl(int lvlN) // there are 3 platforms and baskets in each lvl we will call first 10 lvls as we wanted, after that there will be random lvls
    {
        int N = (lvlN % 10); // for looping after lvl 10
        switch (N -1) // we are starting our levels from 1
        {
            case 9:
                // First one is how many object parents, second one is how many objects in the parents, Third one is which platform (for ex Platform"0") objects, 
                 // fourth one is line-up style, last one is our lvl number
                POC.createParentObj(4, 8, 0, 4, (lvlN - 1));
                POC.createParentObj(3, 8, 1, 1, (lvlN - 1));
                POC.createParentObj(1, 120, 2, 2, (lvlN - 1));
                PC.InstantiatePlatform(lvlN);
                break;
            case 8:
                POC.createParentObj(2, 14, 0, 1, (lvlN - 1));
                POC.createParentObj(4, 8, 1, 3, (lvlN - 1));
                POC.createParentObj(1, 120, 2, 2, (lvlN - 1));
                PC.InstantiatePlatform(lvlN);
                break;
            case 7:
                POC.createParentObj(2, 14, 0, 1, (lvlN - 1));
                POC.createParentObj(4, 8, 1, 1, (lvlN - 1));
                POC.createParentObj(1, 120, 2, 2, (lvlN - 1));
                PC.InstantiatePlatform(lvlN);
                break;
            case 6:
                POC.createParentObj(2, 14, 0, 2, (lvlN - 1));
                POC.createParentObj(4, 8, 1, 1, (lvlN - 1));
                POC.createParentObj(5, 6, 2, 5, (lvlN - 1));
                PC.InstantiatePlatform(lvlN);
                break;
            case 5:
                POC.createParentObj(2, 14, 0, 3, (lvlN - 1));
                POC.createParentObj(4, 8, 1, 1, (lvlN - 1));
                POC.createParentObj(5, 5, 2, 5, (lvlN - 1));
                PC.InstantiatePlatform(lvlN);
                break;
            case 4:
               // Debug.Log("Lvl 5");
                POC.createParentObj(4, 6, 0, 0, (lvlN - 1));
                POC.createParentObj(4, 9, 1, 4, (lvlN - 1));
                POC.createParentObj(1, 120, 2, 2, (lvlN - 1));
                PC.InstantiatePlatform(lvlN);
                break;
            case 3:
               // Debug.Log("Lvl 4");
                POC.createParentObj(3, 8, 0, 0, (lvlN - 1));
                POC.createParentObj(4, 8, 1, 1, (lvlN - 1));
                POC.createParentObj(1, 40, 2, 3, (lvlN - 1));
                PC.InstantiatePlatform(lvlN);
                break;
            case 2:
               // Debug.Log("Lvl 3");
                POC.createParentObj(4, 5, 0, 1, (lvlN - 1));
                POC.createParentObj(5, 6, 1, 1, (lvlN - 1));
                POC.createParentObj(2, 24, 2, 2, (lvlN - 1));
                PC.InstantiatePlatform(lvlN);
                break;
            case 1:
                //Debug.Log("Lvl 2");
                POC.createParentObj(3, 10, 0, 1, (lvlN - 1));
                POC.createParentObj(4, 8, 1, 1, (lvlN - 1));
                POC.createParentObj(1, 120, 2, 2, (lvlN - 1));
                PC.InstantiatePlatform(lvlN);
                break;
            default:
               // Debug.Log("Lvl 1");
                POC.createParentObj(2, 14, 0, 0, (lvlN-1)); 
                POC.createParentObj(4, 8, 1, 1, (lvlN-1));
                POC.createParentObj(1, 90, 2, 2, (lvlN - 1));
                PC.InstantiatePlatform(lvlN);
                break;
        }
    }


    private void FinishedLevel(int lvlN)
    {
       // TapToStart.lvlN += 1;
        SaveSystem.saveSystem.Save(
           (SaveSystem.saveSystem.GetlvlN() + 1));
    }

    private void OnDestroy()
    {
        GameEvents.current.onLvlStart -= CreateLvl;
        GameEvents.current.onLvlFinish -= FinishedLevel;
    }
}
