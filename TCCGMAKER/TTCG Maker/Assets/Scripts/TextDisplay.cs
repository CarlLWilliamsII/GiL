using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    private int health = 5;
    public Text healthText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Controller Output: " + health;

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            health--;
        }if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            health++;
        }
    }
}
