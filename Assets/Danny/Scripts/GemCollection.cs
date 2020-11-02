using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public enum GemColour {Green,Red,Blue,Purple,Yellow};
public class GemCollection : MonoBehaviour
{
    [SerializeField]
    private GameObject iconPanel;
    private Image[] icons;
    private List<GemColour> coloursCollected;
    // Start is called before the first frame update
    void Start()
    {
        coloursCollected = new List<GemColour>();
        icons = iconPanel.GetComponentsInChildren<Image>();
    }

    public void CollectGem(GemColour colour){
        Debug.Log("collected");
        coloursCollected.Add(colour);
        SetIcon(colour);
    }

    private void SetIcon(GemColour colour)
    {
        foreach(Image icon in icons)
        {
            if (icon.GetComponent<GemIcon>().GetColour().Equals(colour))
            {
                icon.GetComponent<GemIcon>().setCollected();
            }
        }
    }

    public bool CheckIfColourCollected(GemColour colour){
        return coloursCollected.Contains(colour);
    }

    public bool allCollected()
    {
        return coloursCollected.Count == 5;
    }
}
