using UnityEngine;
using UnityEngine.UI;

public class FlexibleGridLayout : LayoutGroup
{    
    public enum FitType
    {
        UNIFORM,
        WIDTH,
        HEIGHT,
        FIXEDROWS,
        FIXEDCOLUMNS
    }

    [Header("Flexible Grid")]
    public FitType fitType = FitType.UNIFORM;

    public int rows;
    public int columns;
    public Vector2 cellSize;
    public Vector2 spacing;

    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();

        // Calculate the square root of the total child count
        float squareRoot = Mathf.Sqrt(rectChildren.Count);

        // Calculate the number of rows and columns based on fitType
        if (fitType == FitType.WIDTH || fitType == FitType.HEIGHT || fitType == FitType.UNIFORM)
        {
            rows = columns = Mathf.CeilToInt(squareRoot);
            switch (fitType)
            {
                case FitType.WIDTH:
                    break;
                case FitType.HEIGHT:
                    break;
                case FitType.UNIFORM:
                    break;
            }
        }
        else if (fitType == FitType.WIDTH || fitType == FitType.FIXEDCOLUMNS)
        {
            rows = Mathf.CeilToInt(rectChildren.Count / (float)columns);
        }
        else if (fitType == FitType.HEIGHT || fitType == FitType.FIXEDROWS)
        {
            columns = Mathf.CeilToInt(rectChildren.Count / (float)rows);
        }
        
        // Calculate the available width and height of the parent
        float parentWidth = rectTransform.rect.width - (padding.left + padding.right);
        float parentHeight = rectTransform.rect.height - (padding.top + padding.bottom);

        // Calculate the cell size based on the parent's aspect ratio and rows/columns
        float cellWidth = parentWidth / (float)columns - ((spacing.x / (float)columns) * (columns - 1));
        float cellHeight = parentHeight / (float)rows - ((spacing.y / (float)rows) * (rows - 1));

        // Use the minimum of cellWidth and cellHeight to maintain the aspect ratio
        float cellSize = Mathf.Min(cellWidth, cellHeight);

        // Apply the cell size to both X and Y dimensions (maintaining aspect ratio)
        this.cellSize.x = this.cellSize.y = cellSize;

        // Calculate the total width of the grid
        float totalGridWidth = (cellSize * columns) + (spacing.x * (columns - 1));

        // Calculate the horizontal offset to center the grid
        float xOffset = (parentWidth - totalGridWidth) * 0.5f;

        // Position the child elements within the grid and center them horizontally
        int columnCount = 0;
        int rowCount = 0;

        for (int i = 0; i < rectChildren.Count; i++)
        {
            rowCount = i / columns;
            columnCount = i % columns;

            var item = rectChildren[i];

            var xPos = xOffset + (cellSize + spacing.x) * columnCount + padding.left;
            var yPos = (cellSize + spacing.y) * rowCount + padding.top;

            SetChildAlongAxis(item, 0, xPos, cellSize);
            SetChildAlongAxis(item, 1, yPos, cellSize);
        }
    }

    public override void CalculateLayoutInputVertical()
    {
        // Not needed for horizontal layout
    }

    public override void SetLayoutHorizontal()
    {
        // Not needed for horizontal layout
    }

    public override void SetLayoutVertical()
    {
        // Not needed for horizontal layout
    }
}
