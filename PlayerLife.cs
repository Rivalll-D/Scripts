using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] AudioSource deathSound;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] Button restartButton;
    public bool isGameActive;

    private void Update()
    {
        if (transform.position.y < -0.5f && ! gameOverText)
        {
            GameOver();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled =false;
            GameOver();
        }
    }
    void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        // Invoke(nameof(RestartGame), 1.3f);
        isGameActive = false;
        deathSound.Play();

    }
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
