using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerScript : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, .5f, 0);
    public float speed;
    public float deadZoneRange = 0.05f;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMasterHandlerScript>().transform;
    }

    private void FixedUpdate()
    {
        if ((transform.position - player.position + offset).magnitude > deadZoneRange)
        {

            transform.position = Vector3.Lerp(transform.position, player.position + offset, speed * Time.deltaTime);
        }
    }
}
