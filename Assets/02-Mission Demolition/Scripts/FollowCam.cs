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
    public GameObject poi;
    public float camZ;
    void Awake(){
        S = this;
        camZ = this.transform.position.z;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(poi == null)
            return;

        Vector3 destination = poi.transform.position;
        // Limit the X & Y to minimum values
        destination.x = Mathf.Max( minXY.x, destination.x );
        destination.y = Mathf.Max( minXY.y, destination.y );

        // Interpolate from the current Camera position toward destination
        destination = Vector3.Lerp(transform.position, destination, easing);
        destination.z = camZ;
        transform.position = destination; 
        // Set the orthographicSize of the Camera to keep Ground in view
        this.GetComponent<Camera>().orthographicSize = destination.y + 10;

    }
}
