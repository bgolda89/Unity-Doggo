using UnityEngine;
using System.Collections;

public class Player_Col : MonoBehaviour {

    Data_Management data_Management;
    public GameObject restartUI;
    public GameObject doggo, hooman;
    bool invincible = false;
    public Vector3 boneOffset = new Vector3(-10, 10, 0);
    float elapsedTime = 0;
    Player_Con_New controller;
    static readonly float invincibilityTime = 1f;
    static readonly float flickerTime = 0.1f;
    public SkinnedMeshRenderer doggoMesh, hoomanMesh;


    void Start()
    {
        data_Management = FindObjectOfType<Data_Management>();
        controller = gameObject.GetComponentInParent(typeof(Player_Con_New)) as Player_Con_New;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            FindObjectOfType<Audio_Manager>().Play("CarHit");
            PlayerDies();
            Debug.Log("hitcar");
        }

        if (collision.gameObject.tag == "Ground")
        {
            Player_Con_New.jumped = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bone")
        {
            FindObjectOfType<Audio_Manager>().Play("Bone");
            StartCoroutine(BoneTranslater(other.gameObject, 2));
            //StartCoroutine(Flash(green, bonesUI));
            //audioSource.PlayOneShot(bone[Random.Range(0,bone.Length)], 0.05f);
            //Data_Management.data_Management.boneCollected++;

        }
        if (other.gameObject.tag == "Sign")
        {
            //Debug.Log("hitbad");

            if (hooman.transform.position.x < other.gameObject.transform.position.x && other.gameObject.transform.position.x < doggo.transform.position.x || 
               doggo.transform.position.x < other.gameObject.transform.position.x && other.gameObject.transform.position.x < hooman.transform.position.x)
            {
                other.gameObject.GetComponent<Collider>().enabled = false;
                Debug.Log("hitbad");
                FindObjectOfType<Audio_Manager>().Play("SignHit");
                FindObjectOfType<Player_UI>().currentHealth -= 1;
                StartCoroutine(TakeDamage());
            }
            //PlayerDies();
        }
        //if (other.gameObject.tag == "Clock")
        //{
        //    StartCoroutine(ClockTranslater(other.gameObject, 2));
        //    StartCoroutine(Flash(green, timerUI));
        //    //audioSource.PlayOneShot(clock, 0.3f);
        //    Data_Management.data_Management.secondsLeft += 5;
        //}

        //if (other.gameObject.tag == "Sign")
        //{
        //    //Destroy(other.gameObject);
        //    StartCoroutine(Flash(red, timerUI));
        //    //audioSource.PlayOneShot(sign[Random.Range(0,sign.Length)], 0.1f);
        //    Data_Management.data_Management.secondsLeft -= 2;
        //}

        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            StartCoroutine(controller.Boost(5));
        }
        if (other.gameObject.tag == "Log" && !invincible)
        {
            Destroy(other.gameObject);
            FindObjectOfType<Player_UI>().currentHealth -= 1;
            StartCoroutine(TakeDamage());
            FindObjectOfType<Audio_Manager>().Play("LogHit");

        }
    }

    public void PlayerDies()
    {
        //if (Data_Management.data_Management.boneCollected > Data_Management.data_Management.highScore)
        //{
        //    Data_Management.data_Management.highScore = Data_Management.data_Management.boneCollected;
        //}

        if (controller != null)
                controller.enabled = false;
        
        //GetComponent<Player_Con>().enabled = false;
        restartUI.gameObject.SetActive(true);
        Game_Init.gameOver = true;
    }

    IEnumerator TakeDamage(){
        float time = 0;
        invincible = true;
        while (time < invincibilityTime)
        {
            for (int i = 0; i < 10; i++)
            {
                doggoMesh.enabled = !doggoMesh.enabled;
                hoomanMesh.enabled = !hoomanMesh.enabled;
                yield return new WaitForSeconds(flickerTime);
                time = time += flickerTime;
            }
        }
        invincible = false;
        //data_Management.currentHealth = data_Management.currentHealth - damage;
    }

    IEnumerator BoneTranslater(GameObject other, float time)
    {
        Vector3 bonePosEnd = other.transform.position + boneOffset;
        elapsedTime = 0;
        while (elapsedTime < time)
        {
            other.transform.position = Vector3.Lerp(other.transform.position, bonePosEnd, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            //if (other.transform.position == bonePosEnd)
            //{
            //    Destroy(other.gameObject);
            //}
            yield return null;
        }
    }
}
