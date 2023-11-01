using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    [SerializeField] private float duration;
    private float currentTime;
    [SerializeField] private Gradient gradientColor;

    private void Update()
    {
        Image panel = GetComponent<Image>();
        TMP_Text text = transform.GetChild(0).GetComponent<TMP_Text>();

        float opacity = gradientColor.Evaluate(currentTime / duration).a;
        Color panelBaseColor = panel.color;
        panelBaseColor.a *= opacity;
        Color textBaseColor = text.color;
        textBaseColor.a *= opacity;

        currentTime = Mathf.Clamp(currentTime + Time.deltaTime, 0, duration);
        panel.color = panelBaseColor;
        text.color = textBaseColor;

        if (currentTime >= duration)
            Destroy(gameObject);
    }
}
