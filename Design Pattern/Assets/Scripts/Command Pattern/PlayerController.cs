using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float moveSpeed = 3;

    CommandInvoker CommandInvoker = new CommandInvoker();

    private Dictionary<string, KeyCode> moveKeys = new Dictionary<string, KeyCode> {
        {"Forward", KeyCode.W },
        {"Back", KeyCode.S },
        {"Left", KeyCode.A },
        {"Right", KeyCode.D },
    };

    void Awake()
    {
        instance = this;    
    }

    void Update()
    {
        Move();
    }

    public void Show() {
        int i = 0;
        foreach (var pair in moveKeys) {
            Debug.Log(pair.Key);
            Debug.Log(pair.Value);
            i++;
        }
    }

    private void Move() {
        Vector3 moveDirection = Vector3.zero;

        foreach (var pair in moveKeys) {
            if (Input.GetKey(pair.Value)) { //딕셔너리에 존재하는지?
                switch (pair.Key) {
                    case "Forward":
                        moveDirection += Vector3.forward;
                        break;
                    case "Back":
                        moveDirection += Vector3.back;
                        break;
                    case "Left":
                        moveDirection += Vector3.left;
                        break;
                    case "Right":
                        moveDirection += Vector3.right;
                        break;
                }
            }
        }
        Command moveCommand = new MoveCommand(transform, moveDirection);
        CommandInvoker.SetCommand(moveCommand);
        CommandInvoker.ExecuteCommand();
        //moveCommand.Execute(); -> 해당 코드를 사용해도 되지만 캡슐화하여 실행되게 하는 것이 커맨드 패턴의 핵심화
    }

    public void SetKeys(Dictionary<string, KeyCode> newKeys) {
        moveKeys = newKeys;
    }

    public Dictionary<string, KeyCode> GetKeys() {
        return moveKeys;
    }
}
