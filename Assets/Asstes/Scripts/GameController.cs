using UnityEngine;


public class GameController : MonoBehaviour
{

    public float speed;
    public Rigidbody rb;
    public float JumpVector;
    public LevelController lC;
    public GameObject SpawnPoint;
    public bool isGrounded;
    public float speedBoostTimer;
    public SceneLoader sl;





    void FixedUpdate()
    {

        if (isGrounded == true)
        {

            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);


            rb.AddForce(movement * speed);
          
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            Destroy(other.gameObject);
            lC.ActualScore += 1;
            if (Manager.Instance.difficultychosen == 3)
            {
                if (Manager.Instance.whichLevelIsNow != 4)
                {
                    lC.HardTimer += 2;
                }
                else
                {
                    lC.HardTimer += 5;
                }
                
            }
        }
        if (other.CompareTag("SpeedBooster"))
        {
            speedBoostTimer = 5;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("End"))
        {
            transform.position = SpawnPoint.transform.position;
            if (Manager.Instance.difficultychosen == 2)
            {
                Manager.Instance.Lives -= 1;
            }
            
            
        }
        if (lC.win == false)
        {
            if (other.CompareTag("RedWall"))
            {
                sl.Level4();
            }
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
           
            isGrounded = true;
            Debug.Log("ziemia");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                rb.AddForce(0, 1 * JumpVector, 0, ForceMode.Impulse);
                isGrounded = false;
                Debug.Log("skok");

            }
        }
        
    }
    private void Update()
    {
        if(speedBoostTimer > 0)
        {
            speedBoostTimer -= Time.deltaTime;
            speed = 20;
        }
        else
        {
            speed = 10;            
        }
    }

}




