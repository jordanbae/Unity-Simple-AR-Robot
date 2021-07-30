using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarrelCounter : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static float itemCounter;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = itemCounter.ToString();
    }
}
