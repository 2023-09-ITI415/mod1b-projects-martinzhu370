using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    // Start is called before the first frame update
    public static FollowCam;
    public bool __________________________________;
    public GameObject poi;
    public float camZ;
    void Awake(){
        S = this;
        camZ = this.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        if(poi == null)
            retrun;

        Vector3 destination = poi.transform.position;
        destination.z = camZ;
        transform.position = destination; 
    }
}
