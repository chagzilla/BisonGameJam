using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{

    [SerializeField] private LayerMask layerMask;
     private Mesh mesh; 
     private Vector3 origin;
     private float startingAngle;
     private float fov;
     private float viewDistance;
    private void Start(){

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        origin= Vector3.zero;
    }

    private void LateUpdate(){

        int raycount = 50;
        float angle = startingAngle;
        float angleIncrease = fov / raycount;

        Vector3[] vertices = new Vector3[raycount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[raycount * 3];

        vertices[0] = origin;
        
        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0;i <= raycount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectoFromAngle(angle), viewDistance, layerMask);
            if (raycastHit2D.collider == null){
                // no hit
                vertex = origin + GetVectoFromAngle(angle) * viewDistance;
            }
            else{
                vertex = raycastHit2D.point;
            }
            
            vertices[vertexIndex] = vertex;

            if(i > 0) 
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
            
                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }


        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.bounds = new Bounds(origin, Vector3.one * 1000f);
    }

    public static Vector3 GetVectoFromAngle( float angle )
    {
        float angleRad = angle * (Mathf.PI/180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public void SetOrigin (Vector3 origin){
        this.origin = origin;
    }

    public void SetAimDirection(Vector3 aimDirection){
        startingAngle = GetAngleFromVectorFloat(aimDirection)+ fov / 2f;
    }

    public static float GetAngleFromVectorFloat(Vector3 dir){
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if(n < 0) 
        {
            n += 360;
        }
        return n;
    }
    public void SetFoV(float fov) {
        this.fov = fov;
    }

    public void SetViewDistance(float viewDistance) {
        this.viewDistance = viewDistance;
    }

}
