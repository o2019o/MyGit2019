using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    private float Dx, Dz, xVuler, zVuler;
    public Vector3 Dvec;
    public float Dmag;
    public bool isRun;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
      //  float Dup = (Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0);
       // float Drignt = (Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0);
        Dx = Mathf.SmoothDamp(Dx, x, ref xVuler, 0.1f);
        Dz = Mathf.SmoothDamp(Dz, z, ref zVuler, 0.1f);

        Vector2 ver = SquareToCircle(new Vector2(Dx, Dz));
        float Dup2 = ver.y;
        float Drignt2 = ver.x;
        Dmag = Mathf.Sqrt(Dup2 * Dup2 + Drignt2 * Drignt2);
        Dvec = Drignt2 * transform.right + Dup2 * transform.forward;

        isRun = Input.GetKey(KeyCode.LeftShift);
    }
    private Vector2 SquareToCircle(Vector2 input)
    {
        Vector2 output = Vector2.zero;
        output.x = input.x * Mathf.Sqrt(1 - (input.y * input.y) / 2.0f);
        output.y = input.y * Mathf.Sqrt(1 - (input.x * input.x) / 2.0f);
        return output;
    }
}
