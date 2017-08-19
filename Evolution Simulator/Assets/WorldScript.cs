using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript : MonoBehaviour {

    private Vector3 Origin; // place where mouse is first pressed
    private Vector3 Diference; // change in position of mouse relative to origin
    public GameObject Creature;
    public GameObject Tree;
    float ArenaRadius = 100;
    int minTree=20;
    int minCreature=50;
    void Start()
    {
        transform.localScale = new Vector3(ArenaRadius*2, ArenaRadius*2, 1);
        for (int i = 0; i < minTree; i++)
        {
            float randomAngle = Random.Range(0, 360);
            Instantiate(Tree,Random.insideUnitCircle*(ArenaRadius - 10),Quaternion.Euler(0,0,randomAngle),transform.parent);
        }
        for (int i = 0; i < minCreature; i++)
        {
            float randomAngle = Random.Range(0, 360);
            Instantiate(Creature, Random.insideUnitCircle * (ArenaRadius - 10), Quaternion.Euler(0, 0, randomAngle), transform.parent);
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Origin = MousePos();
        }
        if (Input.GetMouseButton(0))
        {
            Diference = MousePos() - Camera.main.transform.position;
            Camera.main.transform.position = Origin - Diference;
        }
        if(Input.GetAxis("Mouse ScrollWheel")<0)
        {
            Camera.main.orthographicSize *= 1.2f;
        }else
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Camera.main.orthographicSize /= 1.2f;
        }
    }
    // return the position of the mouse in world coordinates (helper method)
    Vector3 MousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
