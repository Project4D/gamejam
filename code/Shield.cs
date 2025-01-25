using UnityEngine;

public class Shield : MonoBehaviour
{
    public float shieldDuration = 5f;
    public float cooldownTime = 10f;
    public GameObject shieldVisual;
    public KeyCode activateKey = KeyCode.LeftShift;

    private MeshRenderer meshRenderer;
    private SphereCollider sphereCollider;


    private bool isShieldActive = false;
    private bool isOnCooldown = false;
    private bool isReadyToActivate = true;

    void Start()
    {
        // gameObject.SetActive(false);
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.enabled = false;
            Debug.Log("MeshRenderer отключен");
        }

        SphereCollider sphereCollider = GetComponent<SphereCollider>();
        if (sphereCollider != null)
        {
            sphereCollider.enabled = false;
        }

        Debug.Log("щит деактивирован");

        if (shieldVisual != null)
        {
            shieldVisual.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(activateKey) && isReadyToActivate)
        {
            Debug.Log("щит активируется");
            ActivateShield();
        }
    }

    void ActivateShield()
    {
        isShieldActive = true;
        isReadyToActivate = false;
        Debug.Log("щит активирован");

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.enabled = true;
            Debug.Log("MeshRenderer отключен");
        }

        SphereCollider sphereCollider = GetComponent<SphereCollider>();
        if (sphereCollider != null)
        {
            sphereCollider.enabled = true;
        }

        if (shieldVisual != null)
        {
            shieldVisual.SetActive(true);
        }

        Invoke(nameof(DeactivateShield), shieldDuration);
    }

    void DeactivateShield()
    {
        isShieldActive = false;
        Debug.Log("щит деактивирован");

        if (shieldVisual != null)
        {
            shieldVisual.SetActive(false);
        }

        // gameObject.SetActive(false);
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.enabled = false;
            Debug.Log("MeshRenderer отключен");
        }

        SphereCollider sphereCollider = GetComponent<SphereCollider>();
        if (sphereCollider != null)
        {
            sphereCollider.enabled = false;
        }

        StartCooldown();
    }

    void StartCooldown()
    {
        isOnCooldown = true;
        Invoke(nameof(ResetCooldown), cooldownTime);
        Debug.Log("щит на перезарядке");
    }

    void ResetCooldown()
    {
        isOnCooldown = false;
        isReadyToActivate = true;
        Debug.Log("щит готов к активации");
    }

    public bool IsShieldActive()
    {
        return isShieldActive;
    }
}