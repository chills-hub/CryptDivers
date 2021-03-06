using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonHover : MonoBehaviour
{
    [SerializeField]
    private Color HoverColour;
    [SerializeField]
    private Color DefaultColour;
    [SerializeField]
    private TextMeshProUGUI TextToChange;

// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColour()
    {
        TextToChange.color = HoverColour;
    }

    public void ChangeColourBack()
    {
        TextToChange.color = DefaultColour;
    }
}
