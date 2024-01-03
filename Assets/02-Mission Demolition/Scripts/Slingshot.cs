using UnityEngine;
using System.Collections;
public class Slingshot : MonoBehaviour {
    static private Slingshot S;
    public GameObject prefabProjectile;
    public float velocityMult = 4f;
    public bool __________________________________;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
    public GameObject launchPoint;
    private Rigidbody projectileRigidbody;

    static public Vector3 LAUNCH_POS { // b
        get {
        if (S == null ) return Vector3.zero;
            return S.launchPos;
        }
    }


    void Awake() {
        S = this;
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive( false );
        launchPos = launchPointTrans.position;
    }

    void OnMouseEnter() {
        launchPoint.SetActive( true );
    }
    void OnMouseExit() {
        launchPoint.SetActive( false );

    }
    void OnMouseDown(){
        aimingMode = true;
        projectile = Instantiate(prefabProjectile) as GameObject;
        projectile.transform.position = launchPos;
        projectile.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Update() {
        // If Slingshot is not in aimingMode, don't run this code
        if (!aimingMode) return;
        // Get the current mouse position in 2D screen coordinates
        Vector3 mousePos2D = Input.mousePosition;
        // Convert the mouse position to 3D world coordinates
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D );
        // Find the delta from the launchPos to the mousePos3D
        Vector3 mouseDelta = mousePos3D-launchPos;
        // Limit mouseDelta to the radius of the Slingshot SphereCollider
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude) {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }
        // Move the projectile to this new position
        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;
        if ( Input.GetMouseButtonUp(0) ) {
            // The mouse has been released
            aimingMode = false;
            projectile.GetComponent<Rigidbody>().isKinematic = false;
            projectile.GetComponent<Rigidbody>().velocity = -mouseDelta * velocityMult;
            FollowCam.S.POI = projectile;
            projectile = null;
            MissionDemolition.ShotFired();
            ProjectileLine.S.poi = projectile;
        }
        }

}