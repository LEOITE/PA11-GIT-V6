using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public int score;

    public Text txt_score; 
    // Start is called before the first frame update
    void Start()
    {
        txt_score.text = "Score : " +score;
    }

    // Update is called once per frame
    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(0 , verticalInput * speed * Time.deltaTime, 0);

      

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "points")
        {
            Destroy(other.gameObject);
            score++;
            txt_score.text = "Score : " + score;
        }
    }
}
