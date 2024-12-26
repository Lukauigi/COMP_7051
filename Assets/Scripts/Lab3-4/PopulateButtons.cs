using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonPrefab;
    [SerializeField]
    private Transform content;
    private int numButtons = 10;

    private void Start()
    {
        for(int i = 0; i < numButtons; i++)
        {
            // create GO from prefab and grab the instance's MyButton script
            MyButton button = Instantiate(buttonPrefab, content).GetComponent<MyButton>();
            button.SetText("Button " + i); //set btn text
            button.callback = ButtonClicked; //pass callback to MyButton callback
        }
    }

    public void ButtonClicked(string buttonText)
    {
        Debug.Log("Clicked: " + buttonText);
    }
}
