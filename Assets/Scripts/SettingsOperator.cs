using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SettingsOperator : MonoBehaviour
{
    [SerializeField] Text sureText;
    public void ShowSureText()
    {
        sureText.gameObject.SetActive(true);
    }

    public void HideSureText()
    {
        sureText.gameObject.SetActive(false);
    }

   
}
