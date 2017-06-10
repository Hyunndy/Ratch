using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    public GameObject Player;
    public float FollowSpeed = 1f;
    public float OffsetX = 0f;
    public float OffsetY = 25f;
    public float OffsetZ = -35f;

    Vector3 CameraPosition;

    private void LateUpdate()
    {
        CameraPosition.x = Player.transform.position.x + OffsetX;
        CameraPosition.y = Player.transform.position.y + OffsetY;
        CameraPosition.z = Player.transform.position.z + OffsetZ;

        transform.position = CameraPosition;
    }
}
