using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour {
    public InputField inputField;
    GameController GC;

	// Use this for initialization
	void Awake () {
        GC = GetComponent<GameController>();
        inputField.onEndEdit.AddListener(AcceptStringInput);
	}
    void Start()
    {
        inputField.ActivateInputField();
    }

    private void AcceptStringInput(string userInput)
    {
        userInput = userInput.ToLower();
        GC.logStringWithReturn(userInput);

        respondToInput(userInput);

        inputComplete();
    }

    private void respondToInput(string userInput)
    {
        char[] delimiters = { ' ' };
        string[] separatedInputWords = userInput.Split(delimiters);
        var keyword = separatedInputWords[0];
        if (GC.InputActions.ContainsKey(keyword))
        {
            var action = GC.InputActions[keyword];
            action.RespondToInput(GC, separatedInputWords);
        }
    }

    private void inputComplete()
    {
        GC.DisplayLogText();
        inputField.ActivateInputField();
        inputField.text = null;
    }
}
