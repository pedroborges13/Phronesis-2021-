using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelWindow : MonoBehaviour
{
    private Text levelText;
    private Image expBarImage;

    private void Awake()
    {
        levelText = transform.Find("LevelText").GetComponent<Text>();
        expBarImage = transform.Find("expBar").GetComponent<Image>();
    }
}
