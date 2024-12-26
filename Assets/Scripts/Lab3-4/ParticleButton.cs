using System;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ParticleButton : MonoBehaviour
{
    public Action<ParticleSystem> callback;
    [SerializeField]
    private TMP_Text text;
    /*
    public void OnPointerClick(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }*/

    public void SetText(string s)
    {
        text.SetText(s);
    }
}
