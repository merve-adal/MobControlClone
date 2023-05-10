using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GiantBar : MonoBehaviour
{
    [SerializeField] private Image foregroundImage;
    [SerializeField] private float updateSpeedSeconds = 0.2f;
    [SerializeField] private TextMeshProUGUI release;

    private void Awake()
    {
        GameManager.Instance.OnProgressChange += HandleBarChange;
        release.enabled = false;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnProgressChange -= HandleBarChange;
    }

    private void HandleBarChange(float pct)
    {
        StartCoroutine(ChangeToPct(pct));
    }

    private IEnumerator ChangeToPct(float pct)
    {
        float preChangePct = foregroundImage.fillAmount;
        float elapsed = 0f;
        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
            yield return null;
        }

        foregroundImage.fillAmount = pct;
        if (foregroundImage.fillAmount >= 1f)
        {
            release.enabled = true;
        }
        else
        {
            release.enabled = false;
        }
    }
}