using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName = "";
    public string bestPlayerName = "";
    public int bestPlayerScore = 0;

    [SerializeField] TMP_InputField nameInputField;

    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestPlayerData();
    }

    public void NameInputChanged()
    {
        playerName = nameInputField.text;
        Debug.Log($"Player name: {playerName}");
    }

    public void PlayButtonPressed()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Start button pressed");
    }

    [System.Serializable]
    private class SaveData
    {
        public string bestPlayerName;
        public int bestPlayerScore;
    }

    public void SaveBestScore(int score)
    {
        SaveData data = new()
        {
            bestPlayerName = playerName,
            bestPlayerScore = score
        };

        if (score <= bestPlayerScore)
        {
            return;
        }

        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/bestplayer.json";

        File.WriteAllText(path, json);
    }

    public void LoadBestPlayerData()
    {
        string path = Application.persistentDataPath + "/bestplayer.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.bestPlayerName;
            bestPlayerScore = data.bestPlayerScore;
        }
    }
}
