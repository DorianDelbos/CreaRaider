using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Gameobjects & Components")]
    [SerializeField] private TMP_Text timerTextMesh;
    private GameObject player;

    [Space, Header("Settings")]
    [SerializeField] private float duration;
    private float currentTime;

    private void Awake()
    {
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

    private void UpdateTimer()
    {
        currentTime = Mathf.Clamp(currentTime - Time.deltaTime, 0, duration);
        timerTextMesh.text = FormatTime(currentTime);

        if (currentTime <= 0)
        {
            player.GetComponent<PlayerUnit>().Death();
            ResetTimer();
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
}
