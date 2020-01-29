using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    public GameObject snowBall;
    private float min_X = -15.59f;
    private float max_X = 19.58f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning(){
        yield return new WaitForSeconds(Random.Range(7f,10f));
        GameObject k = Instantiate(snowBall);
        float x = Random.Range(min_X, max_X);
        k.transform.position = new Vector2(x, transform.position.y);
        StartCoroutine(StartSpawning());
    }
    // Update is called once per frame
    void Update()
    {
      
    }
}
