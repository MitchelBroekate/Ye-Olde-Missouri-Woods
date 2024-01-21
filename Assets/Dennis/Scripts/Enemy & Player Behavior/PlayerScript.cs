using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Health")]
    public int maxPlayerHealth;
    public int currentPlayerHealth;
    [SerializeField]
    private GameObject healthIndicator;
    private Material healthMaterial;
    private bool isDead;

    [Header("Rage Mode")]
    [SerializeField]
    private int currentRageMeter;
    [SerializeField]
    private GameObject rageIndicator;
    private bool isRaging;

    private void Start()
    {
        currentPlayerHealth = maxPlayerHealth;
        currentRageMeter = 0;
        healthMaterial = healthIndicator.GetComponent<Image>().material;
        healthMaterial.SetFloat("_Damage", -3f);
    }

    #region Update Health/Rage
    void UpdateHealth()
    {
        if (currentPlayerHealth <= 100)
        {
            healthMaterial.SetFloat("_Damage", -3f);
        }

        if (currentPlayerHealth <= 80)
        {
            healthMaterial.SetFloat("_Damage", -2f);
        }

        if (currentPlayerHealth <= 50)
        {
            healthMaterial.SetFloat("_Damage", -1f);
        }

        if (currentPlayerHealth <= 20)
        {
            healthMaterial.SetFloat("_Damage", 0f);
        }

        if (currentPlayerHealth <= 0)
        {
            isDead = true;
            Debug.Log("Player is Dead");

            SceneManager.LoadScene("DeatScene");
        }
    }

    IEnumerator UpdateRage()
    {
        if (currentRageMeter >= 100)
        {
            isRaging = true;
            healthIndicator.SetActive(false);
            rageIndicator.SetActive(true);

            yield return new WaitForSeconds(6f);

            isRaging = false;
            currentRageMeter = 0;
            rageIndicator.SetActive(false);
            healthIndicator.SetActive(true);
        }
    }
    #endregion

    #region Player Take Damage/Get Rage
    public void PlayerTakeDamage(int enemyDamage)
    {
        if (currentPlayerHealth >= 0 && !isDead && !isRaging)
        {
            currentPlayerHealth = currentPlayerHealth - enemyDamage;
            Debug.Log(currentPlayerHealth);
            UpdateHealth();
        }
    }

    public void PlayerGetRage(int enemyRageValue)
    {
        if (currentRageMeter >= 0 && !isDead)
        {
            currentRageMeter += enemyRageValue;
            Debug.Log(currentRageMeter);
            StartCoroutine(UpdateRage());
        }
    }
    #endregion
}
