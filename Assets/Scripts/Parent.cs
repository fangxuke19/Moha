using UnityEngine;
using System.Collections;

public class Parent : MonoBehaviour {

    public float spawnTime = 2f;            // How long between each spawn.
        // public PlayerHealth playerHealth;       // Reference to the player's heatlh.
    public GameObject BulletBall;                // The enemy prefab to be spawned.
    public static ArrayList BulletBallList = new ArrayList();   
    // public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public static int LENGTH = 1;
    public static float speed =  0.008f;// m/F
    public static float Z = 3f;
    public static float X = 1f;
    public static float ANGLE = 0.57f;
    public static double Radius = 20.0;
    public static double InnerRadius = 0.3;
    public static double NumOfNotes = 8;
    public static double ClipTime = 1;
    static int NumOfObjects = 0;
    AudioClip rollingClip = null;
    ArrayList notes = new ArrayList();
 	// int[] MusicNotes = {6,7,1,3,6,7,1,3,6,7,1,3};
    string[] MusicNotes = {"3h","2h","3h","2h","3h","7","2h","1h","6","-1","1","3","6","7","-1","3","5","7"};
   
	// Use this for initialization
	void Start () {
	 InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	// // Update is called once per frame
	// void Update () {
	
	// }
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

        if (NumOfObjects >= MusicNotes.Length)
            NumOfObjects = 0;
        string node = MusicNotes[NumOfObjects];
    	if (node == "-1")
        {
            NumOfObjects++;
    		return;
        }
        // Find a random index between zero and one less than the number of spawn points.
        // int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        float alpha = Random.Range(-10, 10+1) * ANGLE / 21.0f;
        Vector3 spawnPosition = new Vector3((float)(Radius * Mathf.Sin(alpha)),0, (float)(Radius * Mathf.Cos(alpha)));
        // spawnPoints[spawnPointIndex].position = tmp;//.Translate(0, 0, 0);//Translate(X * Random.Range (-1, 1), 0 , Z * Random.Range (-1, 1));
        // spawnPoints[spawnPointIndex].position.z = ;
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        BallWrapper wrapper = new BallWrapper();
        wrapper.BulletBall = (GameObject)Instantiate (BulletBall, spawnPosition, Quaternion.identity);
        wrapper.angle = alpha;
        wrapper.audioSource = buildAudio();
        wrapper.audioSource.clip = (AudioClip)Resources.Load<AudioClip>(node);
        // wrapper.audioSource.Play();
        BulletBallList.Add(wrapper);
      
        NumOfObjects++;
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
}
