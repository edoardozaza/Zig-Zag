using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPiattaforma : MonoBehaviour
{
    public GameObject piattaforma;
    public GameObject diamond;
    Vector3 ultimaPos;
    Vector3 pos;
    float size;
    public bool gameOver;
    public static SpawnerPiattaforma current;

    void Awake()
    {

        current = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        ultimaPos = piattaforma.transform.position;
        size = piattaforma.transform.localScale.x;

        for (int i = 0; i < 20; i++)
        {
            SpawnPiattaforma();
        }
          //CominciaSpawn();
    }

    public void CominciaSpawn()
    {
        InvokeRepeating("SpawnPiattaforma", 1f, 0.2f);
    }

        // Update is called once per frame
        void Update()
    {
        if (gameOver)
            CancelInvoke("SpawnPiattaforma");

    }

    void SpawnPiattaforma()
    {
        int rand = Random.Range(0, 6);

        if (rand < 3)
            SpawnX();
        else
            SpawnZ();
    }

    void CreaDiamante()
    {

        int rand = Random.Range(0, 4);
        if (rand < 1)
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1f, pos.z), diamond.transform.rotation);
    }


     void SpawnX()
    {
        pos = ultimaPos;
        pos.x += size;
        ultimaPos = pos;
        Instantiate(piattaforma, pos, Quaternion.identity);

        CreaDiamante();
    }

    void SpawnZ()
    {
        pos = ultimaPos;
        pos.z += size;
        ultimaPos = pos;
        Instantiate(piattaforma, pos, Quaternion.identity);

        CreaDiamante();
    }
}