using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command {
    Transform charTransform;
    Vector3 direction;

    public MoveCommand(Transform transform, Vector3 dir) {
        charTransform = transform;
        direction = dir;
    }

    public override void Execute() {
        float speed = PlayerController.instance.moveSpeed;
        charTransform.Translate(direction * speed * Time.deltaTime);
    }
}
