using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndigoGem : Fuel
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
            Debug.Log("gemaI");
            SoundManager.instance.PlaySfx(5);
            FuelManager.Instance.GrabbedGem(40f);
            Destroy(this.gameObject);
        }
    }
}
