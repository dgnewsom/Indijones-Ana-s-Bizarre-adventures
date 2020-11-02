using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemIcon : MonoBehaviour
{
    [SerializeField]
    private Sprite notCollected;
    [SerializeField]
    private Sprite collected;
    [SerializeField]
    private GemColour colour;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = notCollected;
    }

    public void setCollected()
    {
        image.sprite = collected;
    }

    public GemColour GetColour()
    {
        return colour;
    }
}
