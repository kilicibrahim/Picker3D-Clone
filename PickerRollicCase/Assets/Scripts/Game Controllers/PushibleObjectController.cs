using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// we have 4 different main pushible objects: cube, capsule, cylinder, sphere
public class PushibleObjectController : MonoBehaviour 
{
    [SerializeField] GameObject pOPrefab;

    public List<GameObject> pushibleObjectsParents = new List<GameObject>();



    private void Start()
    {
        GameEvents.current.onBasketExit += DestroyPushible;
        GameEvents.current.onFailedAttemp += OnFailed;
    }

    //maybe transfer just one vector3 istead of separate floats
    private void InitilizeObjects(GameObject Parent, float zPosition, float xPotision) // We need a parent, z postion and x position and we are instatiating our PushibleObject Prefab (Y position is same in these) 
    {
        GameObject tempObj = Instantiate(pOPrefab, transform.position + new Vector3(xPotision, 0.3f, zPosition), Quaternion.Euler(0, 0, 0));
        tempObj.transform.SetParent(Parent.transform, true);
    }

    public void createParentObj(int howManyParents, int howManyObj, int PlatformNumber)
    {
        int zPosition = 0 + (PlatformNumber * 60);
        for (int i = 0; i < howManyParents; i++)
        {
            GameObject Parent = new GameObject(PlatformNumber + "Pushibles" + i);
            createpushibleObjects(howManyObj, Parent);
            pushibleObjectsParents.Add(Parent);
            Parent.transform.position = transform.position + new Vector3(0, 0, zPosition);
            zPosition += howManyObj +2 ;
        }
    }
    void createpushibleObjects(int howManyObj, GameObject Parent)
    {
        float zPosition = -10;
        for (int i=0; i< howManyObj; i++)
        {
            if (i%2 == 0)
            {
                float xPotision = 3;
                InitilizeObjects(Parent, zPosition, xPotision);
            }
            else
            {
                float xPotision = -1f;
                zPosition += 2;
                InitilizeObjects(Parent, zPosition, xPotision);
            } 
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
}
