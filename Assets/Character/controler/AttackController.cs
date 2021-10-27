using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackController : MonoBehaviour
{
    Character character;
    public int pos;
    Gamepad gamepad;
    // Start is called before the first frame update
    void Start()
    {
        character = transform.GetComponent<Character>();
        gamepad = Gamepad.current;
    }

    public bool Debouce = false;
    float myUpdate = 0;
    // Update is called once per frame
    void Update()
    {
        if (gamepad == null)
            return; // No gamepad connected.
        
        if (gamepad.rightTrigger.isPressed && Time.time > myUpdate + .2f)
        {
            character.selectedAttack.Use();
            myUpdate = Time.time;
        }
        if (gamepad.leftTrigger.wasPressedThisFrame)
        {
            Debug.Log("LT");
        }
        int direction = 0;
        if (gamepad.rightShoulder.wasPressedThisFrame) direction = 1;
        if (gamepad.leftShoulder.wasPressedThisFrame) direction = -1;

        if (gamepad.rightShoulder.wasPressedThisFrame || gamepad.leftShoulder.wasPressedThisFrame)
        {
            pos += direction;
            if (pos < 0) pos = character.attacks.Count - 1;
            character.selectedAttack = character.attacks[pos % character.attacks.Count];
        }
    }


}
