using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMakerController : MonoBehaviour
{

    public static string LED_colour = "red";

    public GameObject CoffeeCup;

    public GameObject JustUI;
    public GameObject ExitUI;
    public GameObject COFFEETIMEUI;

    public GameObject DoorRight;

    public GameObject DoorLeft;

    public int DoorsOpening = 0;

    public int interacted;

    int CoffeeTime = 0;

    int DoorsClosing = 0;

    int CoffeeCups = 0;

    int Timer = 4;

    Vector3 move;

    void Start()
    {
       
    }

    public void OpenDoors()
    {

        if(DoorRight.transform.position.x >= 0.170f)
        {
            DoorsOpening = 0;

            CoffeeEjection();

        }
        else
        {
            move = new Vector3(1, 0, 0);

            DoorRight.transform.position += move * Time.deltaTime;

            move = new Vector3(-1, 0, 0);

            DoorLeft.transform.position += move * Time.deltaTime;
        }

    }

    public void CloseDoors()
    {

        if (DoorRight.transform.position.x <= 0.08f)
        {
            DoorsClosing = 0;

            float CurrentY = DoorRight.transform.position.y;
            float CurrentZ = DoorRight.transform.position.z;

            DoorRight.transform.position = new Vector3(0.08f, CurrentY, CurrentZ);

            CurrentY = DoorLeft.transform.position.y;
            CurrentZ = DoorLeft.transform.position.z;

            DoorLeft.transform.position = new Vector3(-0.04f, CurrentY, CurrentZ);
        }
        else
        {
            move = new Vector3(-1, 0, 0);

            DoorRight.transform.position += move * Time.deltaTime;

            move = new Vector3(1, 0, 0);

            DoorLeft.transform.position += move * Time.deltaTime;
        }

    }

    private void CoffeeEjection()
    {
        Instantiate(CoffeeCup);

        move = new Vector3(0, 0.70f, 4.6f);

        CoffeeCup.transform.position = move;

        float thrust = Random.Range(5.0f, 10.0f);

        Debug.Log(thrust);

        CoffeeCup.GetComponent<Rigidbody>().AddForce(transform.forward * thrust);

        CoffeeTime = 1;


    }

    void Update()
    {

        if(GetComponent<Interactable>().currentState == 1) 
        {



            if (LED_colour == "red")
            {

                LED_colour = "green";

                COFFEETIMEUI.SetActive(true);
                JustUI.SetActive(true);
                ExitUI.SetActive(true);

            }
            else
            {

                LED_colour = "red";

            }

            GetComponent<Interactable>().currentState = 0;

        }


        if(DoorsOpening == 1)
        {
            OpenDoors();
        }

        if(DoorsClosing == 1)
        {
            CloseDoors();
        }

        if (CoffeeTime == 1 && CoffeeCups <= 25)
        {

            if(Timer < 5)
            {
                Timer++;
            }
            else
            {
                CoffeeEjection();
                CoffeeCups++;
                Timer = 0;
            }
        } else if(CoffeeCups >= 25)
        {
            CoffeeCups = 0;
            CoffeeTime = 0;
            DoorsClosing = 1;
        }


    } // End Update()
}
