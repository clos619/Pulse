using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Psuedocode!  Psuedocode everywhere!

public class Monster : MonoBehaviour {
    // What it says on the tin.
    public double movementSpeed;
    public double rotationSpeed;

    // Movement and rotation speed when chasing a ping.
    // Assuming monsters should move faster when chasing.
    public double pingMovementSpeed;
    public double pingRotationSpeed;
    
    // How long should the monster be stunned when it gets near an active tower?
    public double stunTime;

    // How far should the monster travel in the direction of a ping before giving up?
    public double trackDistance;

    // Array of points to patrol between.
    public Vector3[] patrolPath;

    // Is the monster moving along a path or just rotating in place?
    public bool isPatrolling;

    // Not sure if this should be public or private, so it's public for now.
    // Direction the monster is facing.
    public Vector3 facing;

    // index of the patrolPath point monster is currentlying moving to.
    private int currentPatrolPoint;

    private bool isRotating;        // Monster can move or rotate, not both.
    private bool isTracking;        // Player sent out a ping that the monster is tracking.
    private Vector3 pingPosition;   // Position of player when they pinged.

    // Direction to next patrolPath point.
    // TODO: Figure out how to figure this out.
    private Vector3 destinationDirection;

    // Direction vector that should never show up naturally, so sentry 
    // monsters have something to pass to the Rotate function.
    private Vector3 sentryDirection = new Vector3(-1f, -1f, -1f);


	// Use this for initialization
	void Start () {

        if (isPatrolling)
        {
            // Did the patrol path get set properly?
            if (patrolPath.Length == 0)
            {
                isPatrolling = false;
                Debug.Log("Patrol path not set, entering sentry mode.");
                isRotating = true;
            }
            else
            {
                currentPatrolPoint = 0;
                isRotating = false;
            }
        }
        else // not patrolling
        {
            isRotating = true;
        }
        isTracking = false;
	}
	
	// Update is called once per frame
	void Update () {

        if ( isPatrolling )
        {
            if (isRotating)
            {
                if ( facing == destinationDirection )
                {
                    // stop rotating, start moving.
                }
                else
                {
                    Rotate(destinationDirection);
                }
            }
            else
            {
                if (this.gameObject.transform.position == patrolPath[currentPatrolPoint])
                {
                    isRotating = true;
                    currentPatrolPoint += 1;
                    // Don't go past the end of the array.
                    if ( currentPatrolPoint >= patrolPath.Length )
                    {
                        currentPatrolPoint = 0;
                    }

                    // Probably figure out desitinationDirection here.

                }
                else
                {
                    Movement( patrolPath[currentPatrolPoint] );
                }
            }
        }
        else if (isTracking)
        {
            // Tracking code goes here.
            // If distance from monster to monster start location is more than the trackingdistance, stop tracking and resume patrolling.
                // Return to previous location or just path to next patrol location?
            // else If not facing the ping location, rotate to face ping location.
            // else move to ping location.

            // What happens when we reach the ping location?  Sit and spin, or return to patrolling?
        }
        else  // Not patrolling or tracking.
        {
            Rotate();
        }

        // Check for ping code goes here.
        //if there was a ping
            //set isTracking to true(unless a sentry?)
            //store location of player and current location of monster
            //Anything else?

        // Also need code for spotting the player.
	}

    // TODO:
    //      Movement code goes here.
    void Movement(Vector3 destination)
    {

    }

    // Used for sentry mode so it just sits and spins.
    // Pass the logic off to the other Rotate function.
    void Rotate()
    {
        Rotate(sentryDirection);
    }

    // Rotate the monster to face a direction.
    void Rotate(Vector3 direction)
    {
        if (direction == sentryDirection)
        {
            // Rotate in place code goes here.
        }
        else
        {
            // Rotate to face direction code goes here.
        }
    }
}
