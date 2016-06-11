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
    class BallWrapper 
    {
    	public GameObject BulletBall;
    	public float angle;
    } 
    void Start ()
    {
        // Call the Spawn functio
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
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
                Destroy(b);
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

    void Spawn ()
    {
        // If the player has no health left...
        // if(playerHealth.currentHealth <= 0f)
        // {
        //     // ... exit the function.
        //     return;
        // }

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
        BulletBallList.Add(wrapper);
    }
}