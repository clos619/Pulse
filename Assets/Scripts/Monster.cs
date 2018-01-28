using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Psuedocode!  Psuedocode everywhere!

public class Monster : MonoBehaviour {
    // What it says on the tin.
    public float movementSpeed = 4f;
    public float rotationSpeed = 45f; //degrees per second
                                      // at 45 does a 360 in 8 seconds.

    // Monsters should probably be faster if they're actually chasing something.
    public float trackMovementMultiplier = 1.5f;
    public float trackRotationMultiplier = 1.5f;
    
    // Movement and rotation speed when tracking a ping.
    // Assuming monsters should move faster when tracking.
    private float trackMovementSpeed;
    private float trackRotationSpeed; // degrees per second
    
    // THIS DOESN'T DO ANYTHING YET, SHOULD PROBABLY MAKE IT DO SOMETHING.
    // How long should the monster be stunned when it gets near an active tower?
    public float stunTime;

    // How far should the monster travel in the direction of a ping before giving up?
    public float trackMaxDistance;

    // Array of points to patrol between.
    // Points are relative to the monster's starting position.
    // Converted to real coordinates during Start().
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

    private Quaternion destinationRotation;
    private Quaternion startRotation;
    private float rotationAngle;
    private float rotationTime;



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
            // It's good enough for government work.
            else
            {
                currentPatrolPoint = 0;

                // Convert patrolPath points from relative coordinates to real coordinates.
                for (int i = 0; i < patrolPath.Length; ++i)
                {
                    patrolPath[i].x += this.gameObject.transform.position.x;
                    patrolPath[i].y += this.gameObject.transform.position.y;
                    patrolPath[i].z += this.gameObject.transform.position.z;
                }

                RotateCalcs();
            }
        }


        trackMovementSpeed = movementSpeed * trackMovementMultiplier;
        trackRotationSpeed = rotationSpeed * trackRotationMultiplier;

        isTracking = false;

        PlayerPing ping = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPing>();
        if (ping != null)
        {
            ping.OnPing.AddListener(Ping);
        }

    }

    // Update is called once per frame
    void Update ()
    {
        if (isTracking)
        {
            // Tracking code goes here.
            if (isRotating)
            {
                Rotate(false); // not a sentry
            }
            else
            {
                Movement(pingPosition);
            }

            // Monster has gone too far, or has reached the spot where the player was.
            // Go back to patrolling.
            if (this.gameObject.transform.position == pingPosition || Vector3.Distance(trackStartPosition, this.gameObject.transform.position) > trackMaxDistance)
            {
                isTracking = false;
                isRotating = true;

                RotateCalcs();
            }
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
        // Or just attach a cone collider to the front of the monster and attach a script to that?
	}

    // Using lerp like this shouldn't provide constant movement speed.  
    // But it looks pretty constant.
    // So it's fine for now I guess?
    // Maybe fix it later.
    void Movement(Vector3 destination)
    {
        float distance = Vector3.Distance(this.gameObject.transform.position, destination);
        float percentage;

        if (isTracking)
        {
            percentage = (trackMovementSpeed * Time.deltaTime) / distance; // (units/second * seconds) / units
        }
        else
        {
            percentage = (movementSpeed * Time.deltaTime) / distance; // (units/second * seconds) / units
        }

        this.transform.position = Vector3.Lerp(this.transform.position, destination, percentage);
    }


    // Rotate stuff goes here.
    // I know using a bool as an argument for this is stupid.
    // Shut up.
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
            float percentage;
            if (isTracking)
            {
                percentage = (rotationTime * trackRotationSpeed) / rotationAngle; // (seconds * degrees/second) / degrees
            }
            else
            {
                percentage = (rotationTime * rotationSpeed) / rotationAngle; // (seconds * degrees/second) / degrees
            }

            //rotate us over time according to speed until we are in the required rotation
            this.gameObject.transform.rotation = Quaternion.Slerp(startRotation, destinationRotation, percentage);

            if (percentage >= 1)
            {
                isRotating = false;
                rotationTime = 0f;
            }
        }
    }

    // Put all the code that does rotation calculations in one place because we need to do it a lot and that's what good programmers do.
    void RotateCalcs()
    {
        // The direction we need to face depends on if we're tracking a ping or just patrolling.
        if (isTracking)
        {
            destinationDirection = (pingPosition - this.gameObject.transform.position).normalized;
        }
        else
        {
            //find the vector pointing from our position to the target
            destinationDirection = (patrolPath[currentPatrolPoint] - this.gameObject.transform.position).normalized;
        }

        //create the rotation we need to be in to look at the target
        destinationRotation = Quaternion.LookRotation(destinationDirection);

        //Save the current rotation value
        startRotation = this.gameObject.transform.rotation;

        rotationAngle = Quaternion.Angle(startRotation, destinationRotation);
        rotationTime = 0f;
    }


    // Call when the player sends out a ping.
    void Ping(Transform playerTransform)
    {
        // Sentries shouldn't move?
        if (isPatrolling)
        {
            isTracking = true;
            isRotating = true;

            pingPosition = playerTransform.position;
            trackStartPosition = this.gameObject.transform.position;

            RotateCalcs();
        }
    }

    public void Stop()
    {
        isPatrolling = false;
        isRotating = false;
        isTracking = false;
    }

}
