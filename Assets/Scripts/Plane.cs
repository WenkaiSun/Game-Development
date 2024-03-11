using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane: MonoBehaviour
{
    // Start is called before the first frame update
    static public int destroyedenemy = 0;
    static public int number = 10;
    void Start()
    {
        Debug.Log("Plane: Started");
    }

    // Update is called once per frame
    void Update()
    {
        /*if(null ==gameObject )
        {
            GameObject a = Instantiate(Resources.Load("Prefabs/Plane") as GameObject);
            a.transform.position = new Vector3(Random.Range(0.9f * EggBehavior.leftBorder, 0.9f * EggBehavior.rightBorder), Random.Range(0.9f * EggBehavior.topBorder, 0.9f * EggBehavior.downBorder), 0f);
        }*/
    }

    private void UpdateColor()
    {
        SpriteRenderer s = GetComponent<SpriteRenderer>();
        //Transform tr= GetComponent<Transform>();
        Color c = s.color;
        //const float delta = 0.25f;
        //c.r -= delta;
        c.a *= 0.8f;
        s.color = c;
        Debug.Log("Plane: Color = " + c);

        if (c.a <= 0.45f)
        {
            Destroy(transform.gameObject);
            GameObject a = Instantiate(Resources.Load("Prefabs/Plane") as GameObject);
            a.transform.position = new Vector3(Random.Range(0.9f* GreenArrowBehavior.leftBorder, 0.9f * GreenArrowBehavior.rightBorder), Random.Range(0.9f * GreenArrowBehavior.topBorder, 0.9f * GreenArrowBehavior.downBorder), 0f);
            //Sprite t = Resources.Load<Sprite>("Textures/Plane");   // File name with respect to "Resources/" folder
           // tr
            s.color = Color.white;
            destroyedenemy++;


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        Debug.Log("Plane: OnTriggerEnter2D");
        UpdateColor();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Plane: OnTriggerStay2D");
        UpdateColor();
    }
}
