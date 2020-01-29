using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{

    public GameObject snowBall;

    public GameObject ChoiceHolder;
    private float min_X = -15.59f;
    private float max_X = 19.58f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning(){
        yield return new WaitForSeconds(Random.Range(7f,10f));
        GameObject k = Instantiate(snowBall /* ...*/);
        k.name = snowBall.name;
        k.transform.SetParent(ChoiceHolder.transform);
        float x = Random.Range(min_X, max_X);
        k.transform.position = new Vector2(x, transform.position.y);
        StartCoroutine(StartSpawning());
    }
    // Update is called once per frame
    void Update()
    {
      
    }
}
