using UnityEngine;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class GameController : MonoBehaviour
{
    public int highScore = 0; //use persistentDataPath to save high score in custom GameData object
    public int currentScore = 0;
    public List<int> topHighScores = new List<int>{ 0, 0, 0, 0, 0 };
    const string fileName = "/highscore.dat";
    public static GameController gCtrl;
    public void Awake()
    {
        if (gCtrl == null)
        {
            DontDestroyOnLoad(gameObject);
            gCtrl = this;
            LoadScore();
        }
    }

    //Small custom class to hold high score that will be saved and serialized using persistentDataPath
    //Serialization: automatic process of transforming data structures or object states into a format that Unity can store and reconstruct later
    [Serializable]
    class GameData
    {
        //public int savedHighScore;
        public List<int> topHighScores = new List<int> { 0, 0, 0, 0, 0 };
    };

    //use persistentDataPath to load high score
    public void LoadScore()
    {
        if (File.Exists(Application.persistentDataPath + fileName))
        {
            BinaryFormatter bf = new BinaryFormatter(); //class to help serialize and deserialize data
            FileStream fs = File.Open(Application.persistentDataPath + fileName, FileMode.Open, FileAccess.Read); //open file path for reading
            
            if (fs.Length != 0) //if file contents is not empty
            {
                GameData data = (GameData)bf.Deserialize(fs); //deserialize data at filepath using Binary formatter, cast into GameData object
                fs.Close();
                //gCtrl.highScore = data.savedHighScore; //set current high score to saved high score

                if (data.topHighScores.Count > 0)
                {
                    data.topHighScores.Sort();
                    data.topHighScores.Reverse();
                    gCtrl.topHighScores = data.topHighScores;

                    // debug
                    int index = 0;
                    foreach (int i in data.topHighScores)
                    {
                        //gCtrl.topHighScores[index] = i;
                        print($"High Score {index + 1}: {i}");
                        ++index;
                    }
                }
            }
            
        }
    }

    //use persistentDataPath to save high score
    public void SaveScore(int score)
    {
        //gCtrl.highScore = score;
        BinaryFormatter bf = new BinaryFormatter(); //class to help serialize and deserialize data

        FileStream fs = null;
        if (File.Exists(Application.persistentDataPath + fileName))
        {
            fs = File.Open(Application.persistentDataPath + fileName, FileMode.Truncate, FileAccess.ReadWrite); //open file path for writing
        }
        else
        {
            fs = File.Open(Application.persistentDataPath + fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite); //open file path for writing
        }

        GameData data = new GameData();
        
        //data.savedHighScore = score;

        if (fs.Length != 0) //if file contents is not empty
        {
            data = (GameData)bf.Deserialize(fs); //deserialize data at filepath using Binary formatter, cast into GameData object
        }
        else
        {
            data.topHighScores = gCtrl.topHighScores;
        }

        // insert new score 
        int index = 0;
        int replacedScore = 0;
        List<int> initialTopScoresCopy = new List<int>(data.topHighScores);
        if (data.topHighScores.Count > 0)
        {
            // replace a high score less than new high score
            foreach (int scoreIter in data.topHighScores)
            {
                if (score > scoreIter)
                {
                    data.topHighScores[index] = score;
                    replacedScore = index;
                    print($"High Score #{index + 1} updated to value: {score}");
                    break;
                }
                ++index;
            }

            if (initialTopScoresCopy[replacedScore] != 0)
            {
                // shift each high score down the list
                for (int i = replacedScore; i + 1 < data.topHighScores.Count; i++)
                {
                    data.topHighScores[i + 1] = initialTopScoresCopy[i];
                }
            }
        }
        else
        {
            data.topHighScores = new List<int> { 0, 0, 0, 0, 0 };
            data.topHighScores[0] = score;
            print($"High Score #1 updated to value: {score}");
        }

        bf.Serialize(fs, data); //use binary formatter to serialize data at filepath
        fs.Close();
    }
    //Use PlayerPrefs to store current score
    public int GetCurrentScore()
    {
        return PlayerPrefs.GetInt("CurrentScore");
    }
    //Use PlayerPrefs to store current score
    public void SetCurrentScore(int num)
    {
        PlayerPrefs.SetInt("CurrentScore", num);
    }
    public void AddScorePressed()
    {
        /*
        int score = GetCurrentScore();
        score++;
        SetCurrentScore(score); //saves current score to playerPrefs
        UpdateHighScore(score);
        //SaveScore(score); //saves current score if it's a new high score
        */

        
        ++currentScore;
        UpdateHighScore(currentScore);
        
    }
    public void MinusScorePressed()
    {
        /*
        int score = GetCurrentScore();
        score--;
        SetCurrentScore(score); //saves current score to playerPrefs
        */

        
        --currentScore;
        UpdateHighScore(currentScore);
        
    }

    private void UpdateHighScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            //SaveScore(highScore); //saves current score if it's a new high score
        }
    }

    private void OnApplicationQuit()
    {
        print("Quit");
        if (gCtrl.highScore > 0) SaveScore(gCtrl.highScore);
    }

    private bool IsNewHighScore(int score)
    {
        return true;
    }
}