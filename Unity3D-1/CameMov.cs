using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameMov : MonoBehaviour
{
    [SerializeField]
    float mouseSensitivity;

    [SerializeField]
    Transform Player, armmesh;

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Rotate_Camera();
    }

    void Rotate_Camera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float rotAmountX = mouseX * mouseSensitivity;
        float rotAmountY = mouseY * mouseSensitivity;

        Vector3 rotPlayerArms = armmesh.transform.rotation.eulerAngles;
        Vector3 rotPlayer = Player.transform.rotation.eulerAngles;
        rotPlayerArms.x -= rotAmountY;
        rotPlayerArms.z = 0;
        rotPlayer.y += rotAmountX;
        armmesh.rotation = Quaternion.Euler(rotPlayerArms);
        Player.rotation = Quaternion.Euler(rotPlayer);
    }

    }

