using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private CharacterHealth characterHealth;

    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject heathContainer;

    [SerializeField] private TextMeshProUGUI dmgText;
    [SerializeField] private float textDisplayTime = 2f;
    private float healthPercent;
    private void Awake()
    {
        if (characterHealth != null)
        {
            Subscribe(characterHealth);
        }
        heathContainer.SetActive(true);
        dmgText.gameObject.SetActive(false);
    }
    
    public void Subscribe(CharacterHealth characterHealth)
    {
        characterHealth.onHealthChanged += UpdateHealthBar;
    }

    public void Unsubscribe(CharacterHealth characterHealth)
    {
        characterHealth.onHealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        healthPercent = (float)currentHealth / (float)maxHealth;
        healthBar.fillAmount = healthPercent;

        if (healthBar.fillAmount <= 0)
        {
            heathContainer.gameObject.SetActive(false);
        }

        dmgText.gameObject.SetActive(true);
     //   dmgText.rectTransform.anchoredPosition = heathContainer.GetComponent<RectTransform>().anchoredPosition;
        StopAllCoroutines();
        StartCoroutine(DisableText(textDisplayTime));
        dmgText.text = $"{currentHealth} / {maxHealth}";
    }


    private IEnumerator DisableText(float delay)
    {
        yield return new WaitForSeconds(delay);
        dmgText.gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        Unsubscribe(characterHealth);
    }
}
