using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Psuedocode!  Psuedocode everywhere!

public class Monster : MonoBehaviour {
    // What it says on the tin.
    public float movementSpeed = 4f;
    public float rotationSpeed = 45f; //degrees per second
                         // at 45 does a 360 in 8 seconds.

    // Movement and rotation speed when tracking a ping.
    // Assuming monsters should move faster when tracking.
    public float trackMovementSpeed;
    public float trackRotationSpeed; // degrees per second
    
    // THIS DOESN'T DO ANYTHING YET, SHOULD PROBABLY MAKE IT DO SOMETHING.
    // How long should the monster be stunned when it gets near an active tower?
    public float stunTime;

    // How far should the monster travel in the direction of a ping before giving up?
    public float trackDistance;

    // Array of points to patrol between.
    public Vector3[] patrolPath;

    // Is the monster moving along a path or just rotating in place?
    public bool isPatrolling;

    // index of the patrolPath point monster is currentlying moving to.
    private int currentPatrolPoint;

    private bool isRotating = true;         // Monster can move or rotate, not both.
    private bool isTracking;                // Player sent out a ping that the monster is tracking.
    private Vector3 pingPosition;           // Position of player when they pinged.
    private Vector3 trackStartPosition;     // Position of monster when it started tracking a ping.

    // Direction to next patrolPath point.
    // TODO: Figure out how to figure this out.
    private Vector3 destinationDirection;

    public Quaternion destinationRotation;
    private Quaternion startRotation;
    private float rotationAngle;
    private float rotationTime;

    // Direction vector that should never show up naturally, so sentry 
    // monsters have something to pass to the Rotate function.
    private Quaternion sentryDirection = new Quaternion(-1f, -1f, -1f, -1f);


    public Quaternion facing;

	// Use this for initialization
	void Start () {

        if (isPatrolling)
        {
            // Did the patrol path get set properly?
            if (patrolPath.Length <= 1) // Need at least two points to patrol.
            {
                isPatrolling = false;
                Debug.Log("Patrol path not set, entering sentry mode.");
                Debug.Log(patrolPath.Length);
            }
            // It's all good
            else
            {
                currentPatrolPoint = 0;

                RotateCalcs();
            }
        }

        isTracking = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        facing = this.gameObject.transform.rotation;
        // Check for ping code goes here.
            //if there was a ping
            //set isTracking to true(unless a sentry?)
            //store location of player and current location of monster
            //Anything else?
        
        if (isTracking)
        {
            // Tracking code goes here.
            // If distance from monster to monster start location is more than the trackingdistance, stop tracking and resume patrolling.
            // Return to previous location or just path to next patrol location?
            // else If not facing the ping location, rotate to face ping location.
            // else move to ping location.

            // What happens when we reach the ping location?  Sit and spin, or return to patrolling?
        }
        else if ( isPatrolling )
        {
            if (isRotating)
            {
                    Rotate(false); // not a sentry
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

                    RotateCalcs();

                }
                else
                {
                    Movement( patrolPath[currentPatrolPoint] );
                }
            }
        }
        else  // Not patrolling or tracking.
        {
            Rotate(true); // is a sentry
        }


        // Also need code for spotting the player.
	}

    // TODO:
    //      Movement code goes here.
    void Movement(Vector3 destination)
    {
        float distance = Vector3.Distance(this.gameObject.transform.position, destination);
        float percentage = (movementSpeed * Time.deltaTime) / distance; // (units/second * seconds) / units
        if (percentage > 1f)
        {
            percentage = 1f;
        }
        this.transform.position = Vector3.Lerp(this.transform.position, destination, percentage);
    }


    // Rotate stuff goes here.
    void Rotate(bool isSentry)
    {
        if (isSentry)
        {
            // TODO: convert this to angles per deltaTime instead of whatever it is now.
            this.gameObject.transform.Rotate( new Vector3(0f, Time.deltaTime * rotationSpeed, 0f) );
        }
        else
        {
            rotationTime += Time.deltaTime;
            float percentage = (rotationTime * rotationSpeed) / rotationAngle; // (seconds * degrees/second) / degrees

            //rotate us over time according to speed until we are in the required rotation
            this.gameObject.transform.rotation = Quaternion.Slerp(startRotation, destinationRotation, percentage);

            if (percentage >= 1)
            {
                isRotating = false;
                rotationTime = 0f;
            }
        }
    }

    // Call when the player sends out a ping.
    // Requires the position vector of the player object.
    // If we can call this from the Player script, then return the monster 
    // position vector to show its position for the player?
    void Ping(Vector3 playerPosition)
    {
        // Sentries shouldn't move?
        if (isPatrolling)
        {
            pingPosition = playerPosition;
            trackStartPosition = this.gameObject.transform.position;
            isTracking = true;
        }
    }

    void RotateCalcs()
    {
        //find the vector pointing from our position to the target
        destinationDirection = (patrolPath[currentPatrolPoint] - this.gameObject.transform.position).normalized;

        //create the rotation we need to be in to look at the target
        destinationRotation = Quaternion.LookRotation(destinationDirection);

        //Save the current rotation value
        startRotation = this.gameObject.transform.rotation;

        rotationAngle = Quaternion.Angle(startRotation, destinationRotation);
        rotationTime = 0f;
    }
}
