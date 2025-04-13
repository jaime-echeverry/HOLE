using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    GameObject bat;

    private Vector2 targetpos;
    // Start is called before the first frame update
    void Start()
    {
        bat = GameObject.FindWithTag("Bat");
    }

    // Update is called once per frame
    void Update()
    {
        targetpos = bat.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, targetpos, 3 * Time.deltaTime);
    }
}
