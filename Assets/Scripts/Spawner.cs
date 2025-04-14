using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject bat;
    GameObject bt;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnobject());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator spawnobject()
    {
        float xpos = 0;
        float ypos = 0;
        while (true)
        {
            int rand = UnityEngine.Random.Range(1, 4);

            xpos = 8.5f;
            ypos = Random.Range(-4.5f, 4.5f);

            Vector2 pos = new Vector2(xpos, ypos);
            bt = Instantiate(bat, pos, Quaternion.identity);

            yield return new WaitForSeconds(6.25f);
            Destroy(bt);
        }
    }
}
