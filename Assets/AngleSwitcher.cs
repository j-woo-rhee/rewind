using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AngleSwitcher : MonoBehaviour
{
    public VideoPlayer frontVideoPlayer;
    public VideoPlayer leftVideoPlayer;
    public Transform player;

    public GameObject frontVideoPlane;
    public GameObject leftVideoPlane;

    private void Start()
    {
        // Start both videos
        frontVideoPlayer.Play();
        leftVideoPlayer.Play();
    }

    void Update()
    {
        Vector3 playerPosition = player.position;

        // Directions from player to video planes
        Vector3 toFront = (frontVideoPlane.transform.position - playerPosition).normalized;
        Vector3 toLeft = (leftVideoPlane.transform.position - playerPosition).normalized;

        // Player's forward direction
        Vector3 playerForward = player.forward;

        // Calculate angles between player's forward direction and directions to video planes
        float angleToFront = Vector3.SignedAngle(playerForward, toFront, Vector3.up);
        float angleToLeft = Vector3.SignedAngle(playerForward, toLeft, Vector3.up);

        // Determine which video to show based on the direction
        if (angleToFront > -90 && angleToFront < 90)
        {
            // Player is looking towards the front
            frontVideoPlayer.targetCamera = Camera.main;
            leftVideoPlayer.targetCamera = null;

            frontVideoPlane.GetComponent<MeshRenderer>().enabled = true;
            leftVideoPlane.GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            // Player is looking towards the left
            leftVideoPlayer.targetCamera = Camera.main;
            frontVideoPlayer.targetCamera = null;

            frontVideoPlane.GetComponent<MeshRenderer>().enabled = false;
            leftVideoPlane.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
