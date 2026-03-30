using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PurchaseUI : MonoBehaviour
{
    public float floatSpeed = 50f;
    public float lifetime = 1.5f;

    private TextMeshProUGUI text;
    private Color startColor;
    private float timer;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        startColor = text.color;
    }

    public void Setup(string message, bool success)
    {
        text.text = message;

        if(success)
            text.color = Color.green;
        else
            text.color = Color.red;
    }

    void Update()
    {
        timer += Time.deltaTime;

        //moves ui up
        transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);

        //fades ui out
        float alpha = Mathf.Lerp(1f,0f,timer / lifetime);
        text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);

        if(timer >= lifetime)
            Destroy(gameObject);
    }
}
