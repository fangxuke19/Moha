using UnityEngine;
using System.Collections;

// public class BallMotion : MonoBehaviour {

// 	// Use this for initialization
// 	void Start () {
	
// 	}
	
// 	// Update is called once per frame
// 	void Update () {
	
// 	}
// }

// using UnityEngine;

public class BallMotion : MonoBehaviour
{
        // public PlayerHealth playerHealth;       // Reference to the player's heatlh.
    public GameObject BulletBall;                // The enemy prefab to be spawned.
    // public static ArrayList BulletBallList = new ArrayList();   
    // public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public static int LENGTH = 1;
    public static float speed =  0.008f;// m/F
    public static float Z = 3f;
    public static float X = 1f;
    public static float ANGLE = 1.57f;
    public static double Radius = 5.0;
    public static double InnerRadius = 0.3;
    public static double NumOfNotes = 8;
    public static double ClipTime = 1;
    static int NumOfObjects = 0;
    AudioClip rollingClip = null;
    ArrayList notes = new ArrayList();
    // int[] MusicNotes = {6,7,1,3,6,7,1,3,6,7,1,3};
    string[] MusicNotes = {"3h","2h","3h","2h","3h","7","2h","1h","6","-1","1","3","6","7","-1","3","5","7"};

  //  public Transform bulletPrefab;

 
    // void Start ()
    // {
    //     // Call the Spawn functio
       
    //     //Transform bullet = Instantiate(bulletPrefab) as Transform;
    //     //Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());



    //     // for (int i = 1; i <= NumOfNotes; ++i)
    //     // 	notes.Add(Resources.Load<AudioClip>(i+""));
    //     // spawnPoints = new Transform[LENGTH];
    //     // for (int i =0; i < LENGTH; ++i)
    //     // 	{
    //     // 	spawnPoints[i].position = Vector3.forward * 10;
    //     // 	}
    // }

    void Update()
    {
    	for (int i =0; i < Parent.BulletBallList.Count; )
    	{
    		BallWrapper wr = (BallWrapper)Parent.BulletBallList[i];
    		GameObject b = wr.BulletBall;
    		if (b.transform.position.z <= InnerRadius)
            {
                Parent.BulletBallList.RemoveAt(i);
                //wr.audioSource.Stop();
                Destroy(b);
            double t0 = AudioSettings.dspTime;
			// double clipTime1 = len1;
			// clipTime1 /= cutClip1.frequency;
			wr.audioSource.PlayScheduled(t0);
			wr.audioSource.SetScheduledEndTime(t0 + ClipTime);
            }
    			
   // 		else 
			//{
			//// Vector3 pos = b.transform.position;
			//float updatedZ =  -1 * speed;
			////Vector3 tmp(pos.x, pos.y, updatedZ);
			//float alpha = wr.angle;
			//b.transform.Translate(updatedZ * Mathf.Sin(alpha), 0, updatedZ * Mathf.Cos(alpha));
			//i++;
			//}
    	}
    }

    void FixedUpdate()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        Vector3 originP = new Vector3(0, 0, 0);
        Vector3 dir = originP - this.transform.position;
        //rb.AddForce(dir * 10);
        rb.AddForce(0,0,10, ForceMode.VelocityChange);

    }


    //void OnCollisionEnter(Collision collision)
    //{
    //    GameObject obj = collision.gameObject;
    //    if (obj is SphereCollider)
    //        Destroy(obj);

    //    Play an impact sound if the sphere impacts strongly enough.
    //    if (collision.relativeVelocity.magnitude >= 0.1f)
    //    {
    //        audioSource.clip = impactClip;
    //        audioSource.Play();
    //    }
    //}
}