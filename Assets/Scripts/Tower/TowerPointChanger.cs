using TMPro;

public class TowerPointChanger : MonoSingleton<TowerPointChanger>
{
    private TextMeshPro _textMesh;
    private TextMeshPro textMesh => _textMesh ?? (_textMesh = GetComponent<TextMeshPro>());

    public void ChangeTowerPoint(int towerPoint)
    {
        textMesh.text = towerPoint.ToString();
    }
}