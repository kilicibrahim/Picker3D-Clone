using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// we have 4 different main pushible objects: cube, capsule, cylinder, sphere
public class PushibleObjectController : MonoBehaviour 
{
    [SerializeField] GameObject SpherePushible;
    [SerializeField] GameObject CubePushible;
    [SerializeField] GameObject CapsulePushible;
    [SerializeField] GameObject CylinderPushible;

    public List<GameObject> pushibleObjectsParents = new List<GameObject>();

    List<GameObject> Pushibles = new List<GameObject>();

private void Start()
    {
        Pushibles.Add(SpherePushible);
        Pushibles.Add(CubePushible);
        Pushibles.Add(CapsulePushible);
        Pushibles.Add(CylinderPushible);
        GameEvents.current.onBasketExit += DestroyPushible;
        GameEvents.current.onFailedAttemp += OnFailed;
    }

    //maybe transfer just one vector3 istead of separate floats
    private void InitilizeObjects(GameObject Parent, float zPosition, float xPotision, int randValue) // We need a parent, z postion and x position and we are instatiating our PushibleObject Prefab (Y position is same in these) 
    {
        GameObject tempObj = Instantiate(Pushibles[randValue], transform.position + new Vector3(xPotision, 0.3f, zPosition), Quaternion.Euler(0, 0, 0));
        tempObj.transform.SetParent(Parent.transform, true);
    }

    public void createParentObj(int howManyParents, int howManyObj, int PlatformNumber, int StyleNumber, int lvlN)
    {
        int randValue = Random.Range(0, 3);
        int zPosition = 0 + (PlatformNumber * 60) + (lvlN * 230);
        for (int i = 0; i < howManyParents; i++)
        {
            GameObject Parent = new GameObject(PlatformNumber + "Pushibles" + i);
            createpushibleObjects(howManyObj, Parent, StyleNumber, randValue);
            pushibleObjectsParents.Add(Parent);
            Parent.transform.position = transform.position + new Vector3(0, 0, zPosition);
            zPosition += howManyObj +2 ;
        }
    }
    void createpushibleObjects(int howManyObj, GameObject Parent, int sN, int randValue) // creating all the levels in script instead of scene because it can be editible much easyly 
    {
        
        switch (sN) 
        {
            case 5:
                Style5(howManyObj, Parent, randValue);
                break;
            case 4:
                Style4(howManyObj, Parent, randValue);
                break;
            case 3:
                Style3(howManyObj, Parent, randValue);
                break;
            case 2:
                Style2(howManyObj, Parent, randValue);
                break;
            case 1:
                Style1(howManyObj, Parent, randValue);
                break;
            default:
                Style0(howManyObj, Parent, randValue);
                break;
        }
    }



    private void DestroyPushible(int bN)
    {

        foreach (GameObject obj in pushibleObjectsParents)
        {
            if (obj != null)
            {
                string nameHolder = obj.transform.gameObject.name;
                char firstCharacter = nameHolder[0];
                string temp = "" + bN;
                char bNumber = temp[0];
                if (firstCharacter == bNumber)
                {
                    Destroy(obj);
                }
            }
        
        }
        
    }

    private void OnFailed(int lvlN)
    {
        for (int i = 0; i < 3; i++) DestroyPushible(i);
    }
    private void OnDestroy()
    {
        GameEvents.current.onBasketExit -= DestroyPushible;
        GameEvents.current.onFailedAttemp -= OnFailed;
    }

    private void Style5(int howManyObj, GameObject Parent, int randValue) //don't send more than 7 obj
    {
        float zPosition = -18;
        float xPotision = 5.5f;
        for (int i = 0; i < howManyObj; i++)
        {
            zPosition += 1.1f;
            xPotision -= 1.6f;
            InitilizeObjects(Parent, zPosition, xPotision, randValue);
        }
    }
    private void Style4(int howManyObj, GameObject Parent, int randValue) //don't send more than 9 obj
    {
        float zPosition = -22;
        float xPotision = 5.5f;
        for (int i = 0; i < howManyObj; i++)
        {
            zPosition += 1.1f;
            xPotision -= 1.1f;
            InitilizeObjects(Parent, zPosition, xPotision, randValue);
        }
    }

    private void Style3(int howManyObj, GameObject Parent, int randValue)
    {
        float xPotision = 0;
        float zPosition = -18;
        for (int i = 0; i < howManyObj; i++)
        {
            if (i % 2 == 0)
            {
                InitilizeObjects(Parent, zPosition, xPotision, randValue);
            }
            else
            {
                zPosition += 2;
                InitilizeObjects(Parent, zPosition, xPotision, randValue);
            }
        }
    }

    private void Style2(int howManyObj, GameObject Parent, int randValue)
    {
        float zPosition = -22;
        float xPotision = 5.2f;
        for (int i = 0; i < howManyObj; i++)
        {
            if (i % 6 == 0)
            {
                zPosition += 2;
                xPotision = 5.2f;
                InitilizeObjects(Parent, zPosition, xPotision, randValue);
            }
            else
            {
                xPotision -= 2.1f;
                InitilizeObjects(Parent, zPosition, xPotision, randValue);
            }
        }
    }

    private void Style1(int howManyObj, GameObject Parent, int randValue)
    {
        float zPosition = -16;
        for (int i = 0; i < howManyObj/2; i++)
        {
            if (i % 2 == 0)
            {
                zPosition += 1;
                float xPotision = 3.1f;
                InitilizeObjects(Parent, zPosition, xPotision, randValue);
            }
            else
            {
                float xPotision = 1.9f;
                zPosition += 1;
                InitilizeObjects(Parent, zPosition, xPotision, randValue);
            }
        }

        for (int i = howManyObj / 2; i < howManyObj; i++)
        {
            if (i % 2 == 0)
            {
                zPosition += 1;
                float xPotision = -3.1f;
                InitilizeObjects(Parent, zPosition, xPotision, randValue);
            }
            else
            {
                float xPotision = -1.9f;
                zPosition += 1;
                InitilizeObjects(Parent, zPosition, xPotision, randValue);
            }
        }
    }

    private void Style0(int howManyObj, GameObject Parent, int randValue)
    {
        float zPosition = -18;
        for (int i = 0; i < howManyObj; i++)
        {
            if (i % 2 == 0)
            {
                float xPotision = 3;
                InitilizeObjects(Parent, zPosition, xPotision, randValue);
            }
            else
            {
                float xPotision = 0f;
                zPosition += 2;
                InitilizeObjects(Parent, zPosition, xPotision, randValue);
            }
        }
    }
}
