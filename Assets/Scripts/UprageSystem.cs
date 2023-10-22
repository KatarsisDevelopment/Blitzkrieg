using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UprageSystem : MonoBehaviour
{
    public Button[] skillImages;
    public bool IsSelect;
    private void OnEnable()
    {
        RandomSkill();
    }
    private void OnDisable()
    {
        foreach (var item in skillImages)
        {
            item.gameObject.SetActive(false);
        }
    }
    public  void RandomSkill()
    {
        int randomIndex = Random.Range(0, skillImages.Length);
        Button selectedImage = skillImages[randomIndex];
        selectedImage.gameObject.SetActive(true);
        IsSelect = false;
    }
}







