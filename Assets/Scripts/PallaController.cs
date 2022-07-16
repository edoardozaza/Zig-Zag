using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PallaController : MonoBehaviour
{
    public GameObject particle;

    [SerializeField]
    private float speed;
    bool partito;
    bool gameOver;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        partito = false;
        gameOver = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!partito)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                partito = true;
                SpawnerPiattaforma.current.CominciaSpawn();

                GameManager.current.StartGame();


            }
        }
        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);
            Camera.main.GetComponent<CameraController>().gameOver = true;

            SpawnerPiattaforma.current.gameOver = true;

            GameManager.current.GameOver();
            


        }


        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            CambiaDirezione();
        }
    }

    void CambiaDirezione()
    {
        if (rb.velocity.z > 0)
        {

            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {

            rb.velocity = new Vector3(0, 0, speed);

        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Diamond")
        {
            GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject; 
            Destroy(col.gameObject);
            Destroy(part, 1f);

            //qui aggiungo il punteggio di diamond
            ScoreManager.current.DiamondScore();
        }
    }
 }