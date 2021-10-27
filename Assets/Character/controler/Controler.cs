using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Controler : MonoBehaviour
{
    public NavMeshAgent agent;
    public Camera cam;
    bool battleStance;
    [Range(0, .1f)]
    public float moveSpeed;
    [Range(-10, 0)]
    public float camDistance = 3;
    [Range(0, 10)]
    public float camHeight = 1.5f;
    Gamepad gamepad;

    void Start()
    {
        battleStance = false;
        gamepad = Gamepad.current;
    }

    // Update is called once per frame
    void Update()
    {
        if (gamepad == null)
            return; // No gamepad connected.
        Movecharacter();
        rotatePlayerAndCam();
        //ClickToMove();
        Cursor.visible = battleStance;
    }

    void rotatePlayerAndCam()
    {

        // cam.transform.position = transform.TransformDirection(transform.position  + new Vector3(0, Input.GetAxis("XBOX_RIGHT_ANALOG_Y"), camDistance));
        cam.transform.position = transform.TransformPoint(0, gamepad.rightStick.y.ReadValue() + camHeight + 1, camDistance);
        cam.transform.LookAt(transform.TransformPoint(0, camHeight, 0));
        transform.Rotate(new Vector3(0, gamepad.rightStick.x.ReadValue(), 0));
    }

    void Movecharacter()
    {

        agent.Move(
                transform.TransformDirection(
                    (new Vector3(
                        gamepad.leftStick.x.ReadValue() * moveSpeed, 0, gamepad.leftStick.y.ReadValue() * moveSpeed
                        )
                    )
                    )
                );
    }


}
