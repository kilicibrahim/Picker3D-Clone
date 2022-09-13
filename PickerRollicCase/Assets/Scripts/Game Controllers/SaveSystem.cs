using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem saveSystem;
    private void Awake()
    {
        if (saveSystem == null)
        {
            saveSystem = this;
        }
    }
#if UNITY_EDITOR
    public void Reset()
    {
        PlayerPrefs.SetInt("lvlN", 0);
    }
#endif
    public void Save(int lvlN) // lvlNumber
    {
        PlayerPrefs.SetInt("lvlN", lvlN);
    }

    public int GetlvlN()
    {
        return (PlayerPrefs.GetInt("lvlN"));
    }

}
