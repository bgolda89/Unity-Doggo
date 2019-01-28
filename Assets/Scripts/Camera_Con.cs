using UnityEngine;

public class Camera_Con : MonoBehaviour {
    
    private GameObject player; 
    public GameObject doggo, hooman;
    public float cameraSpeed = 5.0f;
    public float cameraSmoothing = 100.0f;
    public Vector3 cameraOffset;

    void Update()

    {
        Vector3 camPos = transform.position;                               

        camPos.x = ((doggo.transform.position.x + hooman.transform.position.x) / 2) + cameraOffset.x;
        //transform.position = Vector3.Lerp(transform.position, camPos, cameraSmoothing * Time.fixedDeltaTime);
        camPos.y = doggo.transform.position.y + cameraOffset.y;
        //transform.position = Vector3.Lerp(transform.position, camPos, cameraSmoothing * Time.fixedDeltaTime);
        camPos.z = ((doggo.transform.position.z + hooman.transform.position.z) / 2) + cameraOffset.z - Mathf.Abs(doggo.transform.position.x - hooman.transform.position.x) * 0.25f - (Mathf.Abs(doggo.transform.position.z - hooman.transform.position.z) / 2);
        //camPos.z = hooman.transform.position.z + cameraOffset.z - Mathf.Abs(doggo.transform.position.x - hooman.transform.position.x) * 0.25f;
        transform.position = Vector3.Lerp(transform.position, camPos, cameraSmoothing * Time.fixedDeltaTime);
    }
}
