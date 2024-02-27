using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeKeyCommand : Command {
    private Dictionary<string, KeyCode> newKeys;

    public ChangeKeyCommand(Dictionary<string, KeyCode> keys) {
        newKeys = keys;
    }

    public override void Execute() {
        PlayerController.instance.SetKeys(newKeys);
    }
}
