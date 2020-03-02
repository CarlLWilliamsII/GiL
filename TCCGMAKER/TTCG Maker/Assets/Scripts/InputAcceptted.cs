using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputAcceptted : MonoBehaviour
{
    private void Awake()
    {
        NewBehaviourScript.onTriggerDown += TriggerDown;
        NewBehaviourScript.onTriggerUp += TriggerUp;
    }

    private void TriggerDown()
    {
        print("Trigger Down");
    }

    private void TriggerUp()
    {
        print("Trigger Up");
    }



}
