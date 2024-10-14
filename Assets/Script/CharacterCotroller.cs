using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharacterCotroller : MonoBehaviour
{
    public float movementSpeed = 5f;         
    public float mouseSensitivity = 2f;     
    public Camera playerCamera;             

    private CharacterController controller;
    private float verticalRotation = 0f;
    private float verticalVelocity = 0f;

    [Header("CharaterHealth")]
    public int currentHealth;
    public int maxHealth = 100;
    public Slider playerHealth;

    [Header("Die")]
    public GameObject deathPanel;
    [Header("Score")]
    public TMP_Text kills;
    int kill;

    void Start()
    {
        controller = GetComponent<CharacterController>();
       // Cursor.lockState = CursorLockMode.Locked;
    }
    public void PlayerDeath(int damage)
    {
        currentHealth -= damage;
        playerHealth.value = currentHealth;
        if (currentHealth <= 0)
        {
            deathPanel.SetActive(true);
            Destroy(gameObject);
           // Cursor.lockState = CursorLockMode.None;


        }
    }

    public void EnemyKills()
    {
        kill++;
        kills.text = kill.ToString();
    }
    void Update()
    {

        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = 0f;
            verticalVelocity += 5f;
        }

        Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

        speed = transform.rotation * speed;

        controller.Move(speed * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(0f, mouseX, 0f);

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

   
    
}
