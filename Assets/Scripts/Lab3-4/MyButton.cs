using System;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MyButton : MonoBehaviour, IPointerClickHandler
{
    public Action<string> callback; // Var to access text script
    [SerializeField]
    private TMP_Text text; // create a callback function

    public void OnPointerClick(PointerEventData data)
    {
         callback?.Invoke(text.text); //call callback function and passes string from the GO's text
    }

    public void SetText(string s)
    {
        text.SetText(s);
    }
}
