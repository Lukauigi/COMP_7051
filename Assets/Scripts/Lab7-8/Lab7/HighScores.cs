using UnityEngine;
using TMPro;

public class HighScores : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Update is called once per frame
    void Update()
    {
        text.text = $"High Scores:\n#1: {GameController.gCtrl.topHighScores[0]}\n" +
            $"#2: {GameController.gCtrl.topHighScores[1]}\n" +
            $"#3: {GameController.gCtrl.topHighScores[2]}\n" +
            $"#4: {GameController.gCtrl.topHighScores[3]}\n" +
            $"#5: {GameController.gCtrl.topHighScores[4]}";
    }
}
