using UnityEngine;

// Dirty
// TODO: Make this works with variable vertices number (SuperVolume repository)
public static class BrickBuilder
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

	//private static Vector3 V1 { get { return Vertices[0]; } }
	//private static Vector3 V2 { get { return Vertices[1]; } }
	//private static Vector3 V3 { get { return Vertices[2]; } }
	//private static Vector3 V4 { get { return Vertices[3]; } }
	//private static Vector3 V5 { get { return Vertices[4]; } }
	//private static Vector3 V6 { get { return Vertices[5]; } }
	//private static Vector3 V7 { get { return Vertices[6]; } }
	//private static Vector3 V8 { get { return Vertices[7]; } }

	#endregion

	#region Constructor

	static BrickBuilder()
	{
		Vertices = new Vector3[8];
		CalculateVextices();
		BuildMesh();
		BuildBrickGameObject();
	}

	#endregion

	#region Methods

	private static void CalculateVextices()
	{
		var w = Grid.BrickSize.x / 2f;
		var h = Grid.BrickSize.y / 2f;
		var d = Grid.BrickSize.z / 2f;

		Vertices[0] = new Vector3(-w, +h, -d);
		Vertices[1] = new Vector3(+w, +h, -d);
		Vertices[2] = new Vector3(-w, -h, -d);
		Vertices[3] = new Vector3(+w, -h, -d);
		Vertices[4] = new Vector3(-w, +h, +d);
		Vertices[5] = new Vector3(+w, +h, +d);
		Vertices[6] = new Vector3(-w, -h, +d);
		Vertices[7] = new Vector3(+w, -h, +d);
	}

	// Horrible - I just want to see a result for the moment
	private static void BuildMesh()
	{
		//var vertices = new int[8];

		//for (var i = 0; i < vertices.Length; i++)
		//{
		//	vertices[i] = Ver
		//}

		var indices = new int[3 * 12];

		indices[0] = 0;
		indices[1] = 1;
		indices[2] = 2;

		indices[3] = 2;
		indices[4] = 1;
		indices[5] = 3;

		indices[6] = 3;
		indices[7] = 6;
		indices[8] = 2;

		indices[9] = 3;
		indices[10] = 6;
		indices[11] = 7;

		indices[12] = 6;
		indices[13] = 7;
		indices[14] = 4;

		indices[15] = 4;
		indices[16] = 7;
		indices[17] = 5;

		indices[18] = 4;
		indices[19] = 5;
		indices[20] = 0;

		indices[21] = 0;
		indices[22] = 5;
		indices[23] = 1;

		indices[24] = 3;
		indices[25] = 1;
		indices[26] = 7;

		indices[27] = 7;
		indices[28] = 1;
		indices[29] = 5;

		indices[30] = 4;
		indices[31] = 0;
		indices[32] = 6;

		indices[33] = 0;
		indices[34] = 2;
		indices[35] = 6;

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
