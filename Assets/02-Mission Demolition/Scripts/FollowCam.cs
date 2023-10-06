using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    // Start is called before the first frame update
    public static FollowCam S;
    public float easing = 0.05f;   
    public Vector2 minXY;
    public bool __________________________________;
    public GameObject POI;
    public float camZ;
    void Awake(){
        S = this;
        camZ = this.transform.position.z;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 destination;
        // If there is no poi, return to P:[ 0, 0, 0 ]
        if (POI ==null ) {
            destination =Vector3.zero;
        }else {
            // Get the position of the poi
            destination = POI.transform.position;
            // If poi is a Projectile, check to see if it's at rest
            if (POI.tag == "Projectile" ) {
            // if it is sleeping (that is, not moving)
            if ( POI.GetComponent<Rigidbody>().IsSleeping() ) {
            // return to default view
            POI =null ;
            // in the next update
            return ;
            }
            }
        }

        destination.x = Mathf.Max( minXY.x, destination.x );
        destination.y = Mathf.Max(minXY.y, destination.y);
        destination.z = camZ;
        transform.position = destination;

        this.GetComponent<Camera>().orthographicSize = destination.y + 10;

    }
}
