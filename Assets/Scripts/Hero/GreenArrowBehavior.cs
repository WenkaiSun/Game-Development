using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenArrowBehavior : MonoBehaviour
{
    public bool mFollowMousePosition = true;
    public float mHeroSpeed = 20f;
    public float mHeroRotateSpeed = 90f / 2f; // 90-degrees in 2 seconds
    private int mTotalEggCount = 0;
    int rangeRadomx = 0,rangeRadomy=0;
    public int maxCount = 10;
    public int count = 0;
    private int touchedEnemy=0;
    static public float leftBorder;
    static public float rightBorder;
    static public float topBorder;
    static public float downBorder;
    // Start is called before the first frame update
    void Start()
    {
        GameObject a = Instantiate(Resources.Load("Prefabs/Plane") as GameObject);//,new Vector3(Random.Range(0, 699), Random.Range(0, 286),0))as  GameObject);
        GameObject b = Instantiate(Resources.Load("Prefabs/Plane") as GameObject);
        GameObject c = Instantiate(Resources.Load("Prefabs/Plane") as GameObject);
        GameObject d = Instantiate(Resources.Load("Prefabs/Plane") as GameObject);
        GameObject q = Instantiate(Resources.Load("Prefabs/Plane") as GameObject);
        GameObject f = Instantiate(Resources.Load("Prefabs/Plane") as GameObject);
        GameObject g = Instantiate(Resources.Load("Prefabs/Plane") as GameObject);
        GameObject h = Instantiate(Resources.Load("Prefabs/Plane") as GameObject);
        GameObject i = Instantiate(Resources.Load("Prefabs/Plane") as GameObject);
        GameObject j = Instantiate(Resources.Load("Prefabs/Plane") as GameObject);
        Vector3 cornerPos = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Mathf.Abs(-Camera.main.transform.position.z)));
        leftBorder = Camera.main.transform.position.x - (cornerPos.x - Camera.main.transform.position.x);
        rightBorder = cornerPos.x;
        topBorder = cornerPos.y;
        downBorder = Camera.main.transform.position.y - (cornerPos.y - Camera.main.transform.position.y);
        a.transform.position = new Vector3(Random.Range(0.9f * leftBorder, 0.9f * rightBorder), Random.Range(0.9f * topBorder, 0.9f * downBorder), 0f);
       b.transform.position = new Vector3(Random.Range(0.9f * leftBorder, 0.9f * rightBorder), Random.Range(0.9f * topBorder, 0.9f * downBorder), 0f);
        c.transform.position = new Vector3(Random.Range(0.9f * leftBorder, 0.9f * rightBorder), Random.Range(0.9f * topBorder, 0.9f * downBorder), 0f);
        d.transform.position = new Vector3(Random.Range(0.9f * leftBorder, 0.9f * rightBorder), Random.Range(0.9f * topBorder, 0.9f * downBorder), 0f);
        q.transform.position = new Vector3(Random.Range(0.9f * leftBorder, 0.9f * rightBorder), Random.Range(0.9f * topBorder, 0.9f * downBorder), 0f);
        f.transform.position = new Vector3(Random.Range(0.9f * leftBorder, 0.9f * rightBorder), Random.Range(0.9f * topBorder, 0.9f * downBorder), 0f);
        g.transform.position = new Vector3(Random.Range(0.9f * leftBorder, 0.9f * rightBorder), Random.Range(0.9f * topBorder, 0.9f * downBorder), 0f);
        h.transform.position = new Vector3(Random.Range(0.9f * leftBorder, 0.9f * rightBorder), Random.Range(0.9f * topBorder, 0.9f * downBorder), 0f);
        i.transform.position = new Vector3(Random.Range(0.9f * leftBorder, 0.9f * rightBorder), Random.Range(0.9f * topBorder, 0.9f * downBorder), 0f);
        j.transform.position = new Vector3(Random.Range(0.9f * leftBorder, 0.9f * rightBorder), Random.Range(0.9f * topBorder, 0.9f * downBorder), 0f);

    }

    // Update is called once per frame
    void Update()
    {
        // Move this object to mouse position
        
        
        if (Input.GetKeyDown(KeyCode.M))
            mFollowMousePosition = !mFollowMousePosition;
        if (mFollowMousePosition)
        {
            Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            p.z = 0f;
            transform.localPosition = p;
        }
        else
        {
            Vector3 p = transform.localPosition;
            if (Input.GetKey(KeyCode.W))
            { 
                mHeroSpeed += 0.01f;
                p += ((mHeroSpeed * Time.smoothDeltaTime) * transform.up); }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                mHeroSpeed += 0.01f;
                p += ((mHeroSpeed * Time.smoothDeltaTime) * transform.up);
            }
            if (Input.GetKey(KeyCode.S))
            {
                mHeroSpeed -= 0.01f;
                p -= ((mHeroSpeed * Time.smoothDeltaTime) * transform.up);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                mHeroSpeed -= 0.01f;
                p += ((mHeroSpeed * Time.smoothDeltaTime) * transform.up);
            }
            CameraSupport s = Camera.main.GetComponent<CameraSupport>();  // Try to access the CameraSupport component on the MainCamera
            if (s != null)   // if main camera does not have the script, this will be null
            {
                Bounds myBound = GetComponent<Renderer>().bounds;  // this is the bound of the collider defined on GreenUp
                CameraSupport.WorldBoundStatus status = s.CollideWorldBound(myBound);

                if (status != CameraSupport.WorldBoundStatus.Inside)
                {
                    Debug.Log("Touching the world edge: " + status);
                    // now let's re-spawn ourself somewhere in the world
                    p.x = s.GetWorldBound().min.x + Random.value * s.GetWorldBound().size.x;
                    p.y = s.GetWorldBound().min.y + Random.value * s.GetWorldBound().size.y;
                }
            }
            transform.localPosition = p;
        }


            if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject e = Instantiate(Resources.Load("Prefabs/Egg") as GameObject); // Prefab MUST BE locaed in Resources/Prefab folder!
            e.transform.localPosition = transform.localPosition;
            //Debug.Log("Spawn Eggs:" + e.transform.localPosition);
            mTotalEggCount++;
        }
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(transform.forward, mHeroRotateSpeed * Time.smoothDeltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(transform.forward, mHeroRotateSpeed * Time.smoothDeltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(transform.forward, -mHeroRotateSpeed * Time.smoothDeltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(transform.forward, -mHeroRotateSpeed * Time.smoothDeltaTime);
        if (Input.GetKeyDown(KeyCode.Q) )
        {
            Application.Quit();
        }

    }
    public void OneLessEgg() { mTotalEggCount--; }

    public string EggStatus() { return "Hero:Drive(Mouse) Touched Enemy(" + touchedEnemy + ")   Egg:OnScreen(" + mTotalEggCount + ")   ENEMY:Count(10) Destroyed("+Plane.destroyedenemy+")"; }


   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Egg")
        {
            Debug.Log("GreenUp: OnTriggerEnter2D");
            Destroy(collision.gameObject);
            float x = Random.Range(0.9f * leftBorder, 0.9f * rightBorder);
            float y = Random.Range(0.9f *topBorder, 0.9f * downBorder);
            float z = 0;
            Vector3 pos = new Vector3(x, y, z);
            Debug.Log(x+y);
            GameObject a = Instantiate(Resources.Load("Prefabs/Plane"),pos, Quaternion.identity) as GameObject;
            //a.transform.position = new Vector3(Random.Range(0.9f * EggBehavior.leftBorder, 0.9f * EggBehavior.rightBorder), Random.Range(0.9f * EggBehavior.topBorder, 0.9f * EggBehavior.downBorder), 0f);
            //SpriteRenderer s=collision.gameObject.GetComponent<SpriteRenderer>();
            //Color c = s.color;
            //c.a -= 1;
            touchedEnemy++;
            Plane.destroyedenemy++;
        }
        
    }

   /* private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Egg")
        {
            Destroy(collision.gameObject);
            GameObject a = Instantiate(Resources.Load("Prefabs/Plane") as GameObject);
            a.transform.position = new Vector3(Random.Range(0.9f * EggBehavior.leftBorder, 0.9f * EggBehavior.rightBorder), Random.Range(0.9f * EggBehavior.topBorder, 0.9f * EggBehavior.downBorder), 0f);
            touchedEnemy++;
            Plane.destroyedenemy++;
        }
    }*/

}
