using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Gameobjects & Components")]
    [SerializeField] private TMP_Text timerTextMesh;
    private GameObject player;
    [SerializeField] private GameObject popupArea;
    [SerializeField] private GameObject popupPrefab;

    [Space, Header("Settings")]
    [SerializeField] private float duration;
    private float currentTime;

    private void Awake()
    {
        instance = this;
        player = GameObject.FindWithTag("Player");
    }

    private void Start()
    {
        ResetTimer();
    }

    private void Update()
    {
        UpdateTimer();
    }

    public void AddPopup(string popupText)
    {
        GameObject popup = Instantiate(popupPrefab, popupArea.transform);
        popup.transform.GetChild(0).GetComponent<TMP_Text>().text = popupText;
        popupArea.GetComponent<VerticalLayoutGroup>().SetLayoutVertical();
    }

    private void UpdateTimer()
    {
        currentTime = Mathf.Clamp(currentTime - Time.deltaTime, 0, duration);
        timerTextMesh.text = FormatTime(currentTime);

        if (currentTime <= 0)
        {
            GameOver();
        }
    }

    public void ResetTimer()
    {
        currentTime = duration;
    }

    private string FormatTime(float seconds)
    {
        int minutes = (int)seconds / 60;
        int remainingSeconds = (int)seconds % 60;

        string formattedTime = $"{minutes:D2}:{remainingSeconds:D2}";

        return formattedTime;
    }

    public void TeleportPlayer(Transform toTeleport)
    {
        player.GetComponent<Rigidbody>().position = toTeleport.position;
        player.GetComponent<Rigidbody>().rotation = toTeleport.rotation;
        //player.transform.position = toTeleport.position;
        //player.transform.rotation = toTeleport.rotation;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("DebugScene");
    }

    public void Win()
    {
        SceneManager.LoadScene("DebugScene");
    }
}
