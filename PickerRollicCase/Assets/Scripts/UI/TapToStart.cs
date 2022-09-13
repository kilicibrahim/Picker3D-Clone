using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TapToStart : MonoBehaviour
{
    public static int lvlN = 1;
    [SerializeField] private Image clear;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI TTStext;

    void Start()
    {
        button.onClick.AddListener(OnButtonClicked);
        GameEvents.current.onFailedAttemp += RecreateTapToStart;
        GameEvents.current.onLvlFinish += RecreateTapToStart;
    }

    private void OnButtonClicked()
    {
        clear.enabled = false;
        TTStext.gameObject.SetActive(false);
        GameEvents.current.LvlStart(lvlN);
    }

    private void RecreateTapToStart(int lvlN)
    {
        clear.enabled = true;
        TTStext.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        GameEvents.current.onFailedAttemp -= RecreateTapToStart;
    }
}
