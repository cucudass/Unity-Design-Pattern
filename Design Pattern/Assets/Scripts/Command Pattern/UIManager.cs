using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] Text[] keyTexts;
    [SerializeField] InputField[] keyInputs;

    private CommandInvoker commandInvoker;

    void Start()
    {
        commandInvoker = new CommandInvoker();
        InitUpper();
        UpdateKey();
    }

    //입력된 글자를 대문자로 변경
    private void InitUpper() {
        foreach (var input in keyInputs) {
            input.onValidateInput += (text, charIndex, addChar) => char.ToUpper(addChar);
        }
    }

    public void UpdateCurrentKeys(Dictionary<string, KeyCode> keys) {
        int i = 0;

        foreach (var pair in keys) {
            keyTexts[i].text = pair.Key + ": " + pair.Value;
            keyInputs[i].text = pair.Value.ToString();
            i++;
        }
    }

    public Dictionary<string, KeyCode> GetNewKeys() {
        Dictionary<string, KeyCode> newKeys = new Dictionary<string, KeyCode>();

        for (int i = 0; i < keyInputs.Length; i++) {
            if (Enum.TryParse(keyInputs[i].text, out KeyCode newkey)) {
                newKeys[keyTexts[i].text.Split(':')[0]] = newkey;
            }
        }
        return newKeys;
    }

    public void ChangeKeyButton() {
        Dictionary<string, KeyCode> newKeys = GetNewKeys();

        Command changeKeyCommand = new ChangeKeyCommand(newKeys);
        PlayerController.instance.SetKeys(newKeys);

        commandInvoker.SetCommand(changeKeyCommand);
        commandInvoker.ExecuteCommand();

        UpdateKey();
    }

    private void UpdateKey() {
        UpdateCurrentKeys(PlayerController.instance.GetKeys());  //변경된 키값 전달
    }
}
