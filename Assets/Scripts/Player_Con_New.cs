using System.Collections;
using UnityEngine;

public class Player_Con_New : MonoBehaviour
{
    
    public float jumpForce =1f;
    public float moveSpeed = 10f;
    public float defaultMoveSpeed = 10f;
    public float maxMoveSpeed = 40f;
    public float horizontalMoveSpeed = 8f;  
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2;
    public float boostMultiplier = 2;

    public static float boostTime = 0f;

    float elapsedTime = 0f;
    public GameObject doggo, hooman, bone;
    public static GameObject activePlayer;
    public static bool jumped;
    Rigidbody drb, hrb;

    void Awake()
    {
        drb = doggo.GetComponentInChildren<Rigidbody>();
        hrb = hooman.GetComponentInChildren<Rigidbody>();
    }
    void Start()
    {
        activePlayer = doggo;
        jumped = false;
        boostTime = 0f;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !jumped)
        {
            FindObjectOfType<Audio_Manager>().Play("Jump");
            jumped = true;
            drb.velocity = Vector3.up * jumpForce;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(ShootBone());
        }

        if (drb.velocity.y < 0)
        {
            drb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (drb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            drb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        hooman.transform.Translate(Vector3.forward * moveSpeed * Time.fixedDeltaTime);
        doggo.transform.Translate(Vector3.forward * moveSpeed * Time.fixedDeltaTime);
        gameObject.transform.Translate(Vector3.forward * moveSpeed * Time.fixedDeltaTime);

        hooman.transform.Translate(horizontalMoveSpeed * Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime, 0f, 0f);
        doggo.transform.Translate(horizontalMoveSpeed * Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime, 0f, 0f);
    }

    public IEnumerator Boost(float pickupBoost)
    {
        elapsedTime = 0f;
        boostTime = boostTime + pickupBoost;
        while (elapsedTime < boostTime)
        {
            moveSpeed += Time.deltaTime;
            print(moveSpeed);
            elapsedTime += Time.deltaTime;
            if (moveSpeed > maxMoveSpeed)
                moveSpeed = maxMoveSpeed;
            yield return null;
        }
        moveSpeed = defaultMoveSpeed;
        boostTime = 0;
    }

    public IEnumerator ShootBone()
    {
        GameObject shotBone = Instantiate(bone, new Vector3(hooman.transform.position.x, hooman.transform.position.y + 1, hooman.transform.position.z), Quaternion.identity);
        shotBone.AddComponent<Rigidbody>().AddForce(0, 0, 150 + hooman.GetComponentInChildren<Rigidbody>().velocity.z, ForceMode.VelocityChange);
        shotBone.GetComponentInChildren<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        yield return null;
    }
}
