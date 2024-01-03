using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Transform cameraPosition;
    // Start is called before the first frame update
    private void Update(){
        transform.position = cameraPosition.position;
    }
}
