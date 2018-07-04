using UnityEngine;

// Dirty
// TODO: Make this works with variable vertices number (SuperVolume repository)
public static partial class BrickBuilder
{
	#region Constants

	public const float BrickDepth = 1f;

	#endregion

	#region Fields

	private static readonly Vector3[] Vertices;
	private static Mesh _mesh;
	private static GameObject _brickGo;

	#endregion

	#region Properties

	public static GameObject BrickGo
	{
		get { return _brickGo; }
	}

	#endregion

	#region Constructor

	static BrickBuilder()
	{
		Debug.Log("BrickBuilder.cs constructor called");
		Vertices = new Vector3[24];
		GenerateVertices();
		BuildMesh();
		BuildBrickGameObject();
	}

	#endregion

	#region Methods

	private static void GenerateVertices()
	{
		var w = GridBuilder.CellDimensions.x / 2f;
		var h = GridBuilder.CellDimensions.y / 2f;
		var d = GridBuilder.CellDimensions.z / 2f;

		Vertices[0] = new Vector3(-w, +h, -d); //A
		Vertices[1] = new Vector3(+w, +h, -d); //B
		Vertices[2] = new Vector3(-w, -h, -d); //D
		Vertices[3] = new Vector3(+w, -h, -d); //C
		Vertices[4] = new Vector3(-w, +h, d); //E
		Vertices[5] = new Vector3(+w, +h, d); //F
		Vertices[6] = new Vector3(-w, +h, -d); //A
		Vertices[7] = new Vector3(+w, +h, -d); //B
		Vertices[8] = new Vector3(-w, -h, -d); //D
		Vertices[9] = new Vector3(+w, -h, -d); //C
		Vertices[10] = new Vector3(-w, -h, d); //H
		Vertices[11] = new Vector3(+w, -h, d); //G
		Vertices[12] = new Vector3(-w, -h, d); //H
		Vertices[13] = new Vector3(+w, -h, d); //G
		Vertices[14] = new Vector3(-w, +h, d); //E
		Vertices[15] = new Vector3(+w, +h, d); //F
		Vertices[16] = new Vector3(+w, +h, -d); //B
		Vertices[17] = new Vector3(+w, +h, d); //F
		Vertices[18] = new Vector3(+w, -h, -d); //C
		Vertices[19] = new Vector3(+w, -h, d); //G
		Vertices[20] = new Vector3(-w, +h, d); //E
		Vertices[21] = new Vector3(-w, +h, -d); //A
		Vertices[22] = new Vector3(-w, -h, d); //H
		Vertices[23] = new Vector3(-w, -h, -d); //D

		PrintCornersPositions();
	}

	// Not beautiful, I may want to create some bricks with rounded edges in the future
	private static void BuildMesh()
	{
		var indices = new int[3 * 12];

		// Triangle 1
		indices[0] = 0;
		indices[1] = 1;
		indices[2] = 2;

		// Triangle 2
		indices[3] = 1;
		indices[4] = 3;
		indices[5] = 2;

		// Triangle 3
		indices[6] = 4;
		indices[7] = 5;
		indices[8] = 6;

		// Triangle 4
		indices[9] = 5;
		indices[10] = 7;
		indices[11] = 6;

		// Triangle 5
		indices[12] = 8;
		indices[13] = 9;
		indices[14] = 10;

		// Triangle 6
		indices[15] = 9;
		indices[16] = 11;
		indices[17] = 10;

		// Triangle 7
		indices[18] = 12;
		indices[19] = 13;
		indices[20] = 14;

		// Triangle 8
		indices[21] = 13;
		indices[22] = 15;
		indices[23] = 14;

		// Triangle 9
		indices[24] = 16;
		indices[25] = 17;
		indices[26] = 18;

		// Triangle 10
		indices[27] = 17;
		indices[28] = 19;
		indices[29] = 18;

		// Triangle 11
		indices[30] = 20;
		indices[31] = 21;
		indices[32] = 22;

		// Triangle 12
		indices[33] = 21;
		indices[34] = 23;
		indices[35] = 22;

		_mesh = new Mesh {vertices = Vertices};
		_mesh.SetIndices(indices, MeshTopology.Triangles, 0, true);
		_mesh.RecalculateBounds();
		_mesh.RecalculateNormals();
		_mesh.RecalculateTangents();
	}

	private static void BuildBrickGameObject()
	{
		_brickGo = new GameObject();
		_brickGo.SetActive(false);
		_brickGo.name = "Brick";
		var mf = _brickGo.AddComponent<MeshFilter>();
		mf.mesh = _mesh;
		mf.mesh.name = "Brick Mesh";
		var meshRenderer = _brickGo.AddComponent<MeshRenderer>();
		var materials = meshRenderer.materials;
		materials[0] = Resources.Load("Materials/BrickMat", typeof(Material)) as Material;
		meshRenderer.materials = materials;
	}

	#endregion
}
