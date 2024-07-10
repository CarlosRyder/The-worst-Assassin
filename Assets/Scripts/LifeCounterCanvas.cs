using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeCounterCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI lifeText;
    LifeCounter lifeCounter;
    // Start is called before the first frame update
    void Start()
    {
        lifeCounter = GameObject.FindAnyObjectByType<LifeCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeCounter != null) 
        {
            lifeText.text = $"lives: {lifeCounter.lives}";
        }
    }
}
