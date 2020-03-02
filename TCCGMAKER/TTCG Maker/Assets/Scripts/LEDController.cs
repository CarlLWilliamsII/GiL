using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDController : MonoBehaviour
{

    public Renderer LED_Renderer;

    void Awake()
    {

        LED_Renderer = GetComponent<Renderer>();

    } // End Awake()

    void Start()
    {

    }

    void Update()
    {
        if( CoffeeMakerController.LED_colour == "green")
        {

            LED_Renderer.material = Resources.Load<Material>("Materials/LED_Green");

        } else if (CoffeeMakerController.LED_colour == "red")
        {

            LED_Renderer.material = Resources.Load<Material>("Materials/LED_Red");

        }
    } // End Update()
}
