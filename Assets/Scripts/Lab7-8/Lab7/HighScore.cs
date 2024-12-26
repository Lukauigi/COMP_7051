using UnityEngine;
using TMPro;
public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Update is called once per frame
    void Update()
    {
        text.text = $"High Score: {GameController.gCtrl.highScore}";
    }
}