
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class JohnnyMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public int score = 0;
    public GameObject starPrefab;
    private Text scoreText;
    private Rigidbody rb;
    private float horizontalInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject scoreGameObject = GameObject.FindWithTag("Score");
        if (scoreGameObject != null )
        {
            scoreText = scoreGameObject.GetComponent<Text>();
        }
        InvokeRepeating(nameof(SpawnStar), 0.0f, 5.0f);
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonUp("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (transform.position.y <= -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void FixedUpdate()
    {
        Vector3 moveVector = transform.position + horizontalInput * Vector3.right * speed * Time.deltaTime;
        rb.MovePosition(moveVector);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Collectible")
        {
            Destroy(other.gameObject);
            score += 100;
            scoreText.text = "Score: " + score;
            if (score >= 1000)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void SpawnStar()
    {
        Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-25, 25), 5, 0);
        Instantiate(starPrefab, spawnPosition, Quaternion.identity);
    }
}
