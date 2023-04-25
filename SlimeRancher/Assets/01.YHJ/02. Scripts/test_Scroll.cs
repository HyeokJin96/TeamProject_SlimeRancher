using UnityEngine;
using UnityEngine.UI;

public class test_Scroll : MonoBehaviour
{
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private RectTransform content;
    [SerializeField] private float itemHeight;

    private int itemCount;

    private void Start()
    {
        itemCount = content.childCount;
        UpdateScrollbarSize();
    }

    private void Update()
    {
        OnItemAdded();
        OnItemRemoved();
    }

    private void UpdateScrollbarSize()
    {
        float scrollbarSize = Mathf.Max(0f, 1f - ((itemCount * itemHeight) / content.rect.height));
        scrollbar.size = scrollbarSize;
    }

    public void OnItemAdded()
    {
        itemCount = content.childCount;
        UpdateScrollbarSize();
    }

    public void OnItemRemoved()
    {
        itemCount = content.childCount;
        UpdateScrollbarSize();
    }
}
