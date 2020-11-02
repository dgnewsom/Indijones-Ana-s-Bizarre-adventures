using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GemColour { Green, Red, Blue, Purple, Yellow };

public class GameManager : MonoBehaviour
{
    //[SerializeField]
    private GameObject gemIconPanel;
    
    //[SerializeField]
    private Text coinCounterText;

    public int coinsCollected;
    private Image[] icons;
    private List<GemColour> coloursCollected;

    // Start is called before the first frame update
    void Start()
    {
        gemIconPanel = FindObjectOfType<FindGemIcons>().gameObject;
        coinCounterText = FindObjectOfType<FindCoinCounter>().GetComponent<Text>();
        coinsCollected = 0;
        //coinCounterText.text = "0";
        coloursCollected = new List<GemColour>();
        icons = gemIconPanel.GetComponentsInChildren<Image>();
        
    }

    public void CollectGem(GemColour colour)
    {
        coloursCollected.Add(colour);
        SetIcon(colour);
    }

    private void SetIcon(GemColour colour)
    {
        foreach (Image icon in icons)
        {
            if (icon.GetComponent<GemIcon>().GetColour().Equals(colour))
            {
                icon.GetComponent<GemIcon>().setCollected();
            }
        }
    }

    public void CollectCoin()
    {
        coinsCollected++;
        coinCounterText.text = coinsCollected.ToString();
    }

    public bool CheckIfColourCollected(GemColour colour)
    {
        return coloursCollected.Contains(colour);
    }

    public bool allGemsCollected()
    {
        return coloursCollected.Count == 5;
    }
}
