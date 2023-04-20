using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    float minSpeed = 12;
    float maxSpeed = 16;
    float maxTorque = 10;
    float xRange = 4;
    float ySpawnPos = -6;
    public int pointValue;
    public ParticleSystem explosionParticle;
    Rigidbody targetRb;
    GameManager manage;

    // Start is called before the first frame update
    void Start()
    {
        manage = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(new Vector3 (RandomTorque(), RandomTorque(), RandomTorque()));
        transform.position = RandomSpawnPos();
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
    private void OnMouseDown()
    {
        if (manage.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            manage.UpdateScore(pointValue);
            if (gameObject.CompareTag("Bad"))
            {
                manage.GameOver();
            }
        }    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.Find("Sensor"))
        {
            Destroy(gameObject);
            if (!gameObject.CompareTag("Bad"))
            {
                manage.GameOver();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
