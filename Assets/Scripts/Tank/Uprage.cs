using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Uprage : MonoBehaviour
{
    public int ClickNumber, CurrentCost,ActiveObjCount;
    public GameObject[] UprageObjects;
    public ParticleSystem Confetti;
    public Slider Slider;
    void Update()
    {
    
        if (ClickNumber >= 5)
        {
            UprageObjects[ActiveObjCount].gameObject.SetActive(true);
            if (ClickNumber % 5 == 0 && ClickNumber != 5)
            {
                ActiveObjCount += 1;
                ClickNumber += 1;
                Confetti.Play();
            }
        }
        float sliderValue = Slider.value; // Slider'ýn deðerini al
        float rotationAmount = sliderValue * 100f * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount); // Objeyi y ekseni etrafýnda döndür
    }
    public void Purchase()
    {
        CurrentCost *= 2;
        ClickNumber += 1;
    }
}
