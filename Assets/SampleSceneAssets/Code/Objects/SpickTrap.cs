using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpickTrap : MonoBehaviour
{
    [SerializeField] private GameObject SpickModel;
    [SerializeField] private float duration;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = SpickModel.transform.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SpickMovement(startPosition, Vector3.zero));
            other.GetComponent<PlayerUnit>().Death();
        }
    }

    private IEnumerator SpickMovement(Vector3 positionToStart, Vector3 positionToMove)
    {
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            SpickModel.transform.localPosition = Vector3.Lerp(positionToStart, positionToMove, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        SpickModel.transform.localPosition = positionToMove;

        yield return new WaitForSeconds(0.5f);

        if (positionToMove == Vector3.zero)
            StartCoroutine(SpickMovement(positionToMove, positionToStart));
    }
}
