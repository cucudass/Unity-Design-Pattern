using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker
{
    private Command command;

    public void SetCommand(Command newCommand) {
        command = newCommand;
    }

    //외부에서 명령을 실행할 함수
    public void ExecuteCommand() {
        command.Execute();
    }
}
