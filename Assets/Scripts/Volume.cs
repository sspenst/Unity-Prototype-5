using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    private Slider slider;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(SetVolume);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetVolume(float v)
    {
        
    }
}
