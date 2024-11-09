using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] TMP_InputField nameInputField;

    public string playerName;

    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
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
}
