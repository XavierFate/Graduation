using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "ObstacleConfig", menuName = "Configs/ObstacleConfig")]
    public class ObstacleConfig : ScriptableObject
    {
        [SerializeField] private Color[] colors;

        public Color GetRandomColor()
        {
            return colors[Random.Range(0, colors.Length)];
        }
    }
}