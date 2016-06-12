using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;

public class shootGun : MonoBehaviour {
    public static double shieldRadius = 2.0;
   // private MeshRenderer meshRenderer;
	// Use this for initialization
	void Start () {
		// meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
        //this.transform.rotation = Vector3.up;

    }
	
	// Update is called once per frame
	void Update () {
        var headPosition = Camera.main.transform.position;
        var rotation = Camera.main.transform.rotation;
        Vector3 temp = new Vector3();
        temp.x = (float)shieldRadius * Mathf.Sin(rotation.y * 2) + headPosition.x;
        temp.z = (float)shieldRadius * Mathf.Cos(rotation.y * 2) + headPosition.z;
        this.transform.position = temp;
        // float DistanceFromCollision = 0.1f;
        // this.gameObject.transform.position = GazeManager.Instance.Position + GazeManager.Instance.Normal * DistanceFromCollision;
        // this.transform.position = ();
        // this.tra 
        // RaycastHit hitInfo;

        // if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        // {
        //     // If the raycast hit a hologram...
        //     // Display the cursor mesh.
        //     // meshRenderer.enabled = true;

        //     // // Move the cursor to the point where the raycast hit.
        //     //this.transform.forward = gazeDirection;

        //     // // Rotate the cursor to hug the surface of the hologram.
        //     // this.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal)
        // 	GameObject obj = hitInfo.collider.gameObject;
        // 	if (obj is SphereCollider)
        //     	Destroy(obj);
        // }	
    }
    void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
       
       Destroy(obj);

        // Play an impact sound if the sphere impacts strongly enough.
        //if (collision.relativeVelocity.magnitude >= 0.1f)
        //{
        //    audioSource.clip = impactClip;
        //    audioSource.Play();
        //}
    }
  
}
