using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    float minSpeed = 12.5f;
    float maxSpeed = 17.5f;
    float maxTorque = 60;
    float xRange = 4;
    float ySpawnPos = -6;
    public int pointValue;
    public int damage;
    public ParticleSystem explosionParticle;
    public AudioClip goodClip;
    public AudioClip badClip;
    public AudioClip fallClip;
    AudioSource audios;
    Rigidbody targetRb;
    GameManager manage;
    ParticleSystem stylePoints;
    ParticleSystem godParticles;

    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponent<AudioSource>();
        manage = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(new Vector3 (RandomTorque(), RandomTorque(), RandomTorque()));
        transform.position = RandomSpawnPos();
        stylePoints = GameObject.Find("Style Particles").GetComponent<ParticleSystem>();
        godParticles = GameObject.Find("Godly Particles").GetComponent<ParticleSystem>();
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
    private void OnMouseOver()
    {
        if (manage.isGameActive && !GameObject.Find("Game Manager").GetComponent<GameManager>().paused && Input.GetButton("Fire1"))
        {
            if (gameObject.CompareTag("Bad"))
            {
                manage.LifeUpdate(damage);
                audios.PlayOneShot(badClip);
            }
            else if (!gameObject.CompareTag("Bad"))
            {
                audios.PlayOneShot(goodClip);
                if (gameObject.CompareTag("Godly"))
                {
                    manage.LifeUpdate(-damage);
                }
            }
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            manage.UpdateScore(pointValue);
        }    
    }

    private void OnMouseDown()
    {
        if (!gameObject.CompareTag("Bad") && !GameObject.Find("Game Manager").GetComponent<GameManager>().paused && manage.isGameActive)
        {
            stylePoints.Play();
            manage.UpdateScore(5);
            if (gameObject.CompareTag("Godly"))
            {
                godParticles.Play();
                manage.UpdateScore(5);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.Find("Sensor"))
        {
            if (!gameObject.CompareTag("Bad") && !GameObject.Find("Game Manager").GetComponent<GameManager>().paused)
            {
                manage.LifeUpdate(damage);
                audios.PlayOneShot(badClip);
            }
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
