using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TapToStart : MonoBehaviour
{
    public static int lvlN = 1;
    [SerializeField] private Image fade;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI text;

    void Start()
    {
        button.onClick.AddListener(OnButtonClicked);
        GameEvents.current.onFailedAttemp += RecreateTapToStart;
        GameEvents.current.onLvlFinish += RecreateTapToStart;
    }

    private void OnButtonClicked()
    {
        fade.enabled = false;
        text.gameObject.SetActive(false);
        GameEvents.current.LvlStart(lvlN);
    }

    private void RecreateTapToStart(int lvlN)
    {
        fade.enabled = true;
        text.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        GameEvents.current.onFailedAttemp -= RecreateTapToStart;
    }
}
