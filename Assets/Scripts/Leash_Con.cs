using UnityEngine;

public class Leash_Con : MonoBehaviour {


    public GameObject handle;
    public GameObject collar;
    public Vector3[] positions = { new Vector3(), new Vector3() };
    public LineRenderer leashLine;

    void Start()
    {
        leashLine = gameObject.GetComponent<LineRenderer>();
        leashLine.SetPositions(positions);
    }

    void Update()
    {
        positions[0] = handle.transform.position;
        positions[1] = collar.transform.position;
        leashLine.SetPositions(positions);
    }
}
