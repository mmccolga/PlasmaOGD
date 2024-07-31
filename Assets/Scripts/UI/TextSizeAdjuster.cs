using UnityEngine;
using TMPro;

public class TextSizeAdjuster : MonoBehaviour
{
    public TMP_Text textComponent; // Reference to the TextMeshPro (TMP) component you want to resize.

    void Update()
    {
        // Assuming the parent object (panel) has a RectTransform component.
        RectTransform parentRectTransform = transform.parent.GetComponent<RectTransform>();

        // Update the TMP text component's Rect Transform to fit the parent's dimensions.
        RectTransform textRectTransform = textComponent.rectTransform;

        // Set the TMP text component's anchor to stretch to the parent's edges.
        textRectTransform.anchorMin = new Vector2(0f, 0f);
        textRectTransform.anchorMax = new Vector2(1f, 1f);

        // Set the TMP text component's pivot to the center, so it stretches from the center to all edges.
        textRectTransform.pivot = new Vector2(0.5f, 0.5f);

        // Set the TMP text component's offset to match the desired padding from the parent's edges.
        int padding = 40; // Change this value to adjust the padding.
        textRectTransform.offsetMin = new Vector2(padding, padding);
        textRectTransform.offsetMax = new Vector2(-padding, -padding);
    }
}
