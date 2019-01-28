using UnityEngine;

public class Destroyer : MonoBehaviour
{

    public GameObject doggo;
    public GameObject hooman;
    private float playerZ;

    private void Start()
    {
        doggo = GameObject.FindGameObjectWithTag("Doggo");
        hooman = GameObject.FindGameObjectWithTag("Hooman");
        playerZ = ((doggo.transform.position.z + hooman.transform.position.z) / 2);
    }

    void Update()
    {
        if (playerZ - gameObject.transform.position.z > 305)
        {
            Destroy(gameObject);
        }
        if (gameObject.GetComponent<Rigidbody>())
        {
            if (gameObject.transform.GetComponentInChildren<Rigidbody>().velocity.z > 1 && gameObject.transform.position.z - playerZ > 450)
            {
                Destroy(gameObject);
            }
        }
    }
}
