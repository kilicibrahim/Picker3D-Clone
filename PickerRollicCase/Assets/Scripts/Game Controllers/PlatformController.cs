using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] GameObject PlatformPrefab;
    [SerializeField] GameObject FinishPlatformPrefab;

    public int FPCounter = 0;
    private Queue<GameObject> Platforms = new Queue<GameObject>();
    private Queue<GameObject> FinishPlatforms = new Queue<GameObject>();
    private void Start()
    {               
        GameEvents.current.onLvlFinish += DestoryOldPlatform;
        GameEvents.current.onLvlFinish += DestoryOldFPlatform;

        float zPosition = (SaveSystem.saveSystem.GetlvlN()) * 230;
        GameObject tempPlatform = (GameObject)Instantiate(PlatformPrefab, transform.position + new Vector3(0, 0, zPosition), Quaternion.Euler(0, 0, 0));
        Platforms.Enqueue(tempPlatform);
        GameObject tempFPlatform = (GameObject)Instantiate(FinishPlatformPrefab, transform.position + new Vector3(0, 0, zPosition+ 180), Quaternion.Euler(0, 0, 0));
        FinishPlatforms.Enqueue(tempFPlatform);
    }
    public void InstantiatePlatform(int LvlNumber)
    {
            float zPosition = (LvlNumber) * 230;
            GameObject tempPlatform = (GameObject)Instantiate(PlatformPrefab, transform.position + new Vector3(0, 0, zPosition), Quaternion.Euler(0, 0, 0));
            Platforms.Enqueue(tempPlatform);
            GameObject tempFPlatform = (GameObject)Instantiate(FinishPlatformPrefab, transform.position + new Vector3(0, 0, zPosition + 180), Quaternion.Euler(0, 0, 0));
            FinishPlatforms.Enqueue(tempFPlatform);
    }


    void DestoryOldPlatform(int lvlN)
    {
        Destroy(Platforms.Dequeue());
    }
    void DestoryOldFPlatform(int lvlN)
    {
        if (FPCounter == 0)
        {
            FPCounter++;
        }
            else
                {
                    Destroy(FinishPlatforms.Dequeue());
                }
                    
    }
    private void OnDestroy()
    {
        GameEvents.current.onLvlFinish -= DestoryOldPlatform;
        GameEvents.current.onLvlFinish -= DestoryOldFPlatform;
    }

}
