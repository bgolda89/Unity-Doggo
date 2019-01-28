using UnityEngine;

public class Player_Con : MonoBehaviour {

    public float jumpForce = 250.0f;
    public float moveSpeed = 10f;
    public float swapDelay = 0.2f;
    public GameObject doggo, hooman;
    public static GameObject activePlayer;
    public static bool isDog = true;

    void Start()
    {
        activePlayer = doggo;
    }

    void Update()
    {
        if (swapDelay > 0)
        {
            swapDelay -= Time.deltaTime;
        }
        if (Input.GetButton("Jump") && swapDelay < 0.01f && activePlayer == doggo)
        {
            activePlayer = hooman;

            swapDelay = 0.2f;
        }
        if (Input.GetButton("Jump") && swapDelay < 0.01f && activePlayer != doggo)
        {
            activePlayer = doggo;
            swapDelay = 0.2f;
        }
    }

    void FixedUpdate()
    {
        gameObject.transform.Translate(Vector3.forward * moveSpeed * Time.fixedDeltaTime);

        activePlayer.transform.Translate(moveSpeed * Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime, 0f, 0f);
    }
}
