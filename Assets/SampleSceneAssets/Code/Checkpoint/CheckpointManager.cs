using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;

    private Checkpoint[] allCheckpoints;
    public Checkpoint currentCheckpoint { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        allCheckpoints = FindObjectsOfType<Checkpoint>();
    }

    public void SetCheckpoint(Checkpoint checkpoint)
    {
        currentCheckpoint = checkpoint;
    }
}
