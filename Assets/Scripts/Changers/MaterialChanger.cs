using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum PCMaterialType { Point, Disk, Square, Mesh };

public class MaterialChanger : MonoBehaviour
{
	public static MaterialChanger Instance { get; private set; }

	private void Awake()
	{
		// Singleton code - If there is an instance, and it's not this, then delete this instance

		if (Instance != null && Instance != this)
		{
			Destroy(this);
		}
		else
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	public Material pointMaterial;
	public Material diskMaterial;
	public Material squareMaterial;

	public GameObject pointButton;
	public GameObject diskButton;
	public GameObject squareButton;
	public GameObject meshButton;

	private TextMeshPro pointText;
	private TextMeshPro diskText;
	private TextMeshPro squareText;
	private TextMeshPro meshText;

	// Start is called before the first frame update
	void Start()
    {
		SetupTexts();
    }

	private void SetupTexts()
	{
        pointText = pointButton.GetComponentInChildren<TextMeshPro>();
        diskText = diskButton.GetComponentInChildren<TextMeshPro>();
        squareText = squareButton.GetComponentInChildren<TextMeshPro>();
        meshText = meshButton.GetComponentInChildren<TextMeshPro>();
    }

	public void HighlightSelectedMaterial(PCMaterialType type)
	{
		if((pointText ?? diskText ?? squareText ?? meshText) == null)
            SetupTexts();

        pointText.color = Color.white;
		diskText.color = Color.white;
		squareText.color = Color.white;
        meshText.color = Color.white;

        switch (type)
		{
			default:
			case PCMaterialType.Point:
				pointText.color = Color.green;
				break;

			case PCMaterialType.Disk:
				diskText.color = Color.green;
				break;

			case PCMaterialType.Square:
				squareText.color = Color.green;
				break;

            case PCMaterialType.Mesh:
                meshText.color = Color.green;
                break;
        }
	}

	public void OnPointButtonPressed()
	{
		PointCloudsManager.Instance.ChangeCurrentPCMaterial(pointMaterial, PCMaterialType.Point);
		HighlightSelectedMaterial(PCMaterialType.Point);
	}

	public void OnDiskButtonPressed() 
	{
		PointCloudsManager.Instance.ChangeCurrentPCMaterial(diskMaterial, PCMaterialType.Disk);
		HighlightSelectedMaterial(PCMaterialType.Disk);
	}

	public void OnSquareButtonPressed() 
	{
		PointCloudsManager.Instance.ChangeCurrentPCMaterial(squareMaterial, PCMaterialType.Square);
		HighlightSelectedMaterial(PCMaterialType.Square);
	}

    public void OnMeshButtonPressed()
    {
		PointCloudsManager.Instance.ChangeMeshAndPC(true);

        HighlightSelectedMaterial(PCMaterialType.Mesh);
    }

}
