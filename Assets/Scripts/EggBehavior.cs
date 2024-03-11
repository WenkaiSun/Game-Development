using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehavior : MonoBehaviour
{
    static private GreenArrowBehavior sGreenArrow = null;
    static public void SetGreenArrow(GreenArrowBehavior g) { sGreenArrow = g; }

    private const float kEggSpeed = 40f;
    private const int kLifeTime = 3500; // Alife for this number of cycles
    private int mLifeCount = 0;
   


    // Start is called before the first frame update
    void Start()
    {
        mLifeCount = kLifeTime;
        
    }



    // Update is called once per frame
    void Update()
    {
        transform.position += sGreenArrow.transform.up * (kEggSpeed * Time.smoothDeltaTime);
        mLifeCount--;
        if (mLifeCount <= 0)
        {
            Destroy(transform.gameObject);  // kills self
            sGreenArrow.OneLessEgg();
        }
        if (transform.localPosition.y >= GreenArrowBehavior.topBorder || transform.localPosition.y <= GreenArrowBehavior.downBorder || transform.localPosition.x >= GreenArrowBehavior.rightBorder || transform.localPosition.x <= GreenArrowBehavior.leftBorder)
        {
            Destroy(transform.gameObject);  // kills self
            sGreenArrow.OneLessEgg();
        }
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "GreenUp")
        {

            Destroy(transform.gameObject);  // kills self
            sGreenArrow.OneLessEgg();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
   {
        Destroy(transform.gameObject);  // kills self
            sGreenArrow.OneLessEgg();
    }
}
