using UnityEngine;
using UnityEngine.EventSystems;

public class MaterialChanger : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Material material;
    public MeshRenderer meshRenderer;
    public Color enterColor;
    public float offsetSpeed = 1f;

    private Color defaultColor;
    private bool isSelected;
    private float currentOffset;

    private void Update()
    {
        currentOffset = currentOffset + offsetSpeed * Time.deltaTime;
        meshRenderer.material.mainTextureOffset = new Vector2(currentOffset, 0f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isSelected = !isSelected;
        if (isSelected == true)
        {
            meshRenderer.material.EnableKeyword("_EMISSION");
        }
        else
        {
            meshRenderer.material.DisableKeyword("_EMISSION");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        meshRenderer.material.color = enterColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        meshRenderer.material.color = defaultColor;
    }

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = material;
        defaultColor = meshRenderer.material.color;
    }
}
