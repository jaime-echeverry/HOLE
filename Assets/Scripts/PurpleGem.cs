using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleGem : Fuel
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("gemaP");
            SoundManager.instance.PlaySfx(1);
            FuelManager.Instance.GrabbedGem(20f);
            Destroy(this.gameObject);
        }
    }
}
