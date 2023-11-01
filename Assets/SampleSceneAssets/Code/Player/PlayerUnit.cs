using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    [Header("Gameobject & Components")]
    [SerializeField] private TMP_Text lifeTextMesh;

    [Space, Header("Settings")]
    public int life;

    private void Start()
    {
        lifeTextMesh.text = "REMAINING LIFE <b><color=#135CAF>" + life.ToString("D2") + "</color></b>";
    }

    public void AddLife(int lifeToAdd)
    {
        life += lifeToAdd;
        lifeTextMesh.text = "REMAINING LIFE <b><color=#135CAF>" + life.ToString("D2") + "</color></b>";
    }

    public void Death()
    {
        AddLife(-1);
        GameManager.instance.ResetTimer();
        transform.position = CheckpointManager.instance.currentCheckpoint.transform.position;
    }
}
