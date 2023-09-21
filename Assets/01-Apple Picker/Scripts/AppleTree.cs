using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{

    [Header("Set in Inspector")]
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeToChangeDirection;
    public float secondsBetweenAppleDrops; 




    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
    }

    void DropApple() {

        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
    }    


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //changing direction
        if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed); //Move right
        }

        else if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed);
        }


    }

    void FixedUpdate() {
        if (Random.value < changeToChangeDirection) {
            speed *= -1;
        }

    }
}
