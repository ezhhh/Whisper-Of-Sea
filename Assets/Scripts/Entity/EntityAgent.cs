using System.Runtime.CompilerServices;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.PlayerSettings;

[RequireComponent(typeof(NavMeshAgent))]
public class EntityAgent : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField, Range(1, 100)] private float _walkRadius;
    [SerializeField, Range(1, 30)] private float _delay;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField, Range(0, 100)] private float _chillChance;
    [SerializeField, Range(0, 5)] private float _chillTime;
    [SerializeField] private bool _wasStopped = false;

    public bool Stopped { get => _wasStopped; set => _wasStopped = value; }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        StartCoroutine(UpdateDestination());
    }

    private IEnumerator UpdateDestination()
    {
        yield return new WaitWhile(() => _wasStopped);
        yield return new WaitForSeconds(_delay);

        float randX = transform.position.x + -Mathf.Sin(Time.time * Random.value) * _walkRadius * Random.Range(-1, 1);
        float randZ = transform.position.z + Mathf.Cos(Time.time * Random.value) * _walkRadius * Random.Range(-1, 1);

        if (Physics.Raycast(new Vector3(randX, 150, randZ), Vector3.down, out var hit, 9999, _layerMask)) {
            Point.Create(hit.point)
                ?.StartFollow(_agent);

            if (Random.Range(0, 100) < _chillChance) { 
                yield return new WaitForSeconds(_chillTime);
            }
        }

        yield return StartCoroutine(UpdateDestination());
    }

    private class Point
    {
        public float x;
        public float y;
        public float z;
       
        public Point (float x, float y, float z)
        {
            this.x = x; this.y = y; this.z = z;
        }

        public static Point Create(float x, float y, float z)
        {
            return new Point(x, y, z);
        }

        public static Point Create(Vector3 pos)
        {
            return new Point(pos.x, pos.y, pos.z);
        }

        public static Point Create(Vector3 pos, ref Point currentPoint)
        {
            Point point = Point.Create(pos);
            currentPoint = point;
            return point;
        }

        public static Point Create(float x, float y, float z, ref Point currentPoint)
        {
            Point point = Create(x, y, z);
            currentPoint = point;
            return point;
        }

        public Vector3 Position { get => new(x, y, z); }
        public void StartFollow(NavMeshAgent agent) { 
            agent.SetDestination(Position);
        }
    }
}
