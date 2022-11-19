using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TMP_InputField input;

    public string currentUser;

    public string topPlayer;
    public int hiScore = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHiScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string topPlayer;
        public int hiScore;
    }

    public void SaveHiScore(string recordBreaker, int brokenScore)
    {
        SaveData data = new SaveData();
        data.topPlayer = recordBreaker;
        data.hiScore = brokenScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHiScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            topPlayer = data.topPlayer;
            hiScore = data.hiScore;
        }
        Debug.Log("Successfully Loaded!");
    }
}
