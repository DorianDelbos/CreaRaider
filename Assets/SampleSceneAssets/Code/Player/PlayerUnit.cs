using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    [System.Serializable]
    public enum View
    {
        Normal,
        Ball,
        CantMove
    }

    [Header("Gameobject & Components")]
    [SerializeField] private TMP_Text lifeTextMesh;

    [Space, Header("Settings")]
    public int life;
    [HideInInspector] public View cameraView;

    private void Start()
    {
        cameraView = View.Normal;
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
        transform.position = CheckpointManager.instance.currentCheckpoint.transform.position;

        if (life <= 0)
        {
            GameManager.instance.GameOver();
        }
    }

    public void SetView(int view)
    {
        cameraView = (View)view;
    }
}
