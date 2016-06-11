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
    public static ArrayList BulletBallList = new ArrayList();   
    public float spawnTime = 1f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public static int LENGTH = 1;
    public static float speed =  0.03f;// m/F
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

    class BallWrapper 
    {
    	public GameObject BulletBall;
    	public float angle;
    	public AudioSource audioSource = null;
    } 
    void Start ()
    {
        // Call the Spawn functio
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
      
        // for (int i = 1; i <= NumOfNotes; ++i)
        // 	notes.Add(Resources.Load<AudioClip>(i+""));
        // spawnPoints = new Transform[LENGTH];
        // for (int i =0; i < LENGTH; ++i)
        // 	{
        // 	spawnPoints[i].position = Vector3.forward * 10;
        // 	}
    }

    void Update()
    {
    	for (int i =0; i < BulletBallList.Count; )
    	{
    		BallWrapper wr = (BallWrapper)BulletBallList[i];
    		GameObject b = wr.BulletBall;
    		if (b.transform.position.z <= InnerRadius)
            {
                BulletBallList.RemoveAt(i);
                //wr.audioSource.Stop();
                Destroy(b);
            double t0 = AudioSettings.dspTime;
			// double clipTime1 = len1;
			// clipTime1 /= cutClip1.frequency;
			wr.audioSource.PlayScheduled(t0);
			wr.audioSource.SetScheduledEndTime(t0 + ClipTime);
            }
    			
    		else 
			{
			// Vector3 pos = b.transform.position;
			float updatedZ =  -1 * speed;
			//Vector3 tmp(pos.x, pos.y, updatedZ);
			float alpha = wr.angle;
			b.transform.Translate(updatedZ * Mathf.Sin(alpha), 0, updatedZ * Mathf.Cos(alpha));
			i++;
			}
    	}
    }

    AudioSource buildAudio()
    {
    	AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialize = true;
        audioSource.spatialBlend = 1.0f;
        audioSource.dopplerLevel = 0.0f;
        audioSource.rolloffMode = AudioRolloffMode.Custom;
        return audioSource;
    }

   
   
    //-5-------222---2xx--2--2-214---h15--1514
    void Spawn ()
    {
        // If the player has no health left...
        // if(playerHealth.currentHealth <= 0f)
        // {
        //     // ... exit the function.
        //     return;
        // }
        //if(NumOfObjects )
        string node = MusicNotes[NumOfObjects];
    	if (node == "-1")
    		return;
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        float alpha = Random.Range(-10, 10+1) * ANGLE / 21.0f;
        Vector3 tmp = new Vector3((float)(Radius * Mathf.Sin(alpha)),0, (float)(Radius * Mathf.Cos(alpha)));
        spawnPoints[spawnPointIndex].position = tmp;//.Translate(0, 0, 0);//Translate(X * Random.Range (-1, 1), 0 , Z * Random.Range (-1, 1));
        // spawnPoints[spawnPointIndex].position.z = ;
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        BallWrapper wrapper = new BallWrapper();
        wrapper.BulletBall = (GameObject)Instantiate (BulletBall, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        wrapper.angle = alpha;
        wrapper.audioSource = buildAudio();
        wrapper.audioSource.clip = (AudioClip)Resources.Load<AudioClip>(node);
        // wrapper.audioSource.Play();
        BulletBallList.Add(wrapper);
        NumOfObjects++;
    }
}