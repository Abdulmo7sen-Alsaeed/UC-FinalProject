using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    Rigidbody rb;
    public GameObject rifle;
    public GameObject camera;
    public float speed;
    public float turn;
    public Transform cameraTransform;
    public TextMeshProUGUI text;
    int counter = 3;
    public float health =100;
    public Image healthBar;
    public AudioSource bang;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 2.5f;
        turn = 5;
        camera = Camera.main.gameObject;
        bang = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp;
        rb.angularVelocity = Vector3.up * Input.GetAxis("Mouse X") * turn;

        temp = (Vector3.right * -Input.GetAxis("Horizontal") + Vector3.forward * -Input.GetAxis("Vertical")) * -speed;
        rb.velocity = temp;
        rb.velocity = transform.rotation * rb.velocity;
        RaycastHit hit;
        if (Input.GetButton("Fire1")) {
            bang.Play();
            if (Physics.Raycast(transform.position, transform.forward, out hit) && hit.collider.gameObject.tag == "enemy")
            {
                Destroy(hit.collider.gameObject);
                counter--;
                if(counter<=0)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //reload scene after finishing on the enemies
            }

        }

        text.text = "Enemies remaining: " + counter;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="enemy") {
            health=health -10;
            healthBar.fillAmount = health / 100f;
            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                // reload win losing
            }
        }
    }

}
/*        

*/