using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animate : MonoBehaviour
{
    public Sprite[] animatedImages;
    public Image animateImageObj;
    public bool isActive;
    // Update is called once per frame
    void Start()
    {
        isActive = true;
    }
    void Update()
    {
        if (isActive)
        {
            animateImageObj.sprite = animatedImages[(int)(Time.time*20)%animatedImages.Length];
        }
    }
}
