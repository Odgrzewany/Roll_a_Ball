using UnityEngine;

public class CameraController : MonoBehaviour {
    

    public GameObject Hah;
    public Vector3 offset;
   

	void Start () {
        offset = transform.position - Hah.transform.position;
	}
	

	void LateUpdate () {
		transform.position = Hah.transform.position + offset;
	}
}
