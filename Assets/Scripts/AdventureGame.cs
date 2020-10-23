using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AdventureGame : MonoBehaviour
{
    //Ctrl + R, R Replace all occurences of a word

    [SerializeField] Text textComponent;
    State currentState;
    [SerializeField] State startingState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = startingState;
        textComponent.text = currentState.GetStoryText();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        State[] nextStates = currentState.GetNextStates();

        if(nextStates.Length == 1)
        {
            if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentState = nextStates[0];
            }
        } else if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentState = nextStates[0];
        } else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentState = nextStates[1];
        }

        textComponent.text = currentState.GetStoryText();
    }
}
