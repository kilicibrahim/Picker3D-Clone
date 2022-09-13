using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lvlCompleteText;
    [SerializeField] private TextMeshProUGUI lvlFailedText;
    [SerializeField] private TextMeshProUGUI currentlvlText;
    [SerializeField] private Button ResetSaveButton;
    private void Start()
    {
        GameEvents.current.onLvlStart += ResetTexts;
        GameEvents.current.onLvlStart += updateLvlText;
        GameEvents.current.onLvlFinish += LvlComplete;
        GameEvents.current.onFailedAttemp += FailedText;
    }

    void LvlComplete(int lvlN)
    {
        ResetSaveButton.gameObject.SetActive(true);
        lvlCompleteText.gameObject.SetActive(true);
    }
    void FailedText(int lvlN)
    {
        ResetSaveButton.gameObject.SetActive(true);
        lvlFailedText.gameObject.SetActive(true);
    }
    void ResetTexts(int lvlN)
    {
        currentlvlText.gameObject.SetActive(true);
        ResetSaveButton.gameObject.SetActive(false);
        lvlCompleteText.gameObject.SetActive(false);
        lvlFailedText.gameObject.SetActive(false);
    }
    void updateLvlText(int lvlN)
    {
        //int val = TapToStart.lvlN;
        int val = SaveSystem.saveSystem.GetlvlN()+1;
        currentlvlText.text = "Level " + val.ToString();
    }
    
    private void OnDestroy()
    {
        GameEvents.current.onLvlStart -= ResetTexts;
        GameEvents.current.onLvlStart -= updateLvlText;
        GameEvents.current.onLvlFinish -= LvlComplete;
        GameEvents.current.onFailedAttemp -= FailedText;
    }
}
