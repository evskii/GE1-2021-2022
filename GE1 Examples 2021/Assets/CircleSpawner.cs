 using System.Collections;
using System.Collections.Generic;
 using System.Runtime.Serialization;

 using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Material colorMaterial;
    
    public float radius = 20;
    public int points = 1;

    public float ringSpacing = 0.25f;
    public int rings = 5;

    // Start is called before the first frame update
    void Start()
    {
	    for (int ringNum = 1; ringNum < rings; ringNum++) {
	        radius = ringNum * ringSpacing;
	        points += 2 * ringNum;
	        for (int i = 0 ; i < points ; i ++) {
		        float theta  = (Mathf.PI * 2.0f) / (float) points;
		        float angle = theta * i;
		        Vector3 position = new Vector3(
			        Mathf.Sin(angle) * radius,
			        Mathf.Cos(angle) * radius,
			        0
		        );
		        GameObject obj = GameObject.Instantiate(prefab, position, Quaternion.identity);
		        obj.AddComponent<RotateMe>().rotSpeed = 50f;
		        obj.GetComponent<Renderer>().material = colorMaterial;
		        obj.transform.parent = transform;
	        }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
