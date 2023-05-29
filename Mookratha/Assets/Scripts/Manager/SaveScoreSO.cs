using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Custom/Game Settings")]
public class SaveScoreSO : ScriptableObject
{
    public int round;
    public float player1Score;
    public float player2Score;
    public float player3Score;
    public float player4Score;
}
