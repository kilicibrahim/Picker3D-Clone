using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lvlCompleteText;
    [SerializeField] private TextMeshProUGUI lvlFailedText;
    private void Start()
    {
        GameEvents.current.onLvlStart += ResetTexts;
        GameEvents.current.onLvlFinish += LvlComplete;
        GameEvents.current.onFailedAttemp += FailedText;
    }
    void LvlComplete(int lvlN)
    {
        lvlCompleteText.gameObject.SetActive(true);
    }
    void FailedText(int lvlN)
    {
        lvlFailedText.gameObject.SetActive(true);
    }
    void ResetTexts(int lvlN)
    {
        lvlCompleteText.gameObject.SetActive(false);
        lvlFailedText.gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        GameEvents.current.onLvlStart += ResetTexts;
        GameEvents.current.onLvlFinish -= LvlComplete;
        GameEvents.current.onFailedAttemp -= FailedText;
    }
}
