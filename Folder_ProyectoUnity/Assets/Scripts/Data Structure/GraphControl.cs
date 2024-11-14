using UnityEngine;

public class GraphControl : MonoBehaviour
{
    private DoublyLinkedCircularList<NodeControl> listAllNodes = new DoublyLinkedCircularList<NodeControl>();
    public TextAsset textNodesPositions;
    public string[] arrayNodeRowsPositions;
    public string[] arrayNodeColumnsPositions;
    public GameObject objectNodePrefab;
    public TextAsset textNodesConnections;
    public string[] arrayNodeRowsConnections;
    public string[] arrayNodeColumnsConnections;
    public EnemyController currentEnemy;

    private void Start()
    {
        DrawNodes();
        ConnectNodes();
        SetInitialNode();
    }

    public void DrawNodes()
    {
        GameObject currentNode;
        arrayNodeRowsPositions = textNodesPositions.text.Split('\n');

        for (int i = 0; i < arrayNodeRowsPositions.Length; ++i)
        {
            arrayNodeColumnsPositions = arrayNodeRowsPositions[i].Split(';');

            Vector3 positionToCreate = new Vector3(
                float.Parse(arrayNodeColumnsPositions[0]),
                float.Parse(arrayNodeColumnsPositions[1]),
                float.Parse(arrayNodeColumnsPositions[2])
            );

            currentNode = Instantiate(objectNodePrefab, positionToCreate, Quaternion.identity);
            currentNode.name = "NODE" + i.ToString();

            listAllNodes.AddAtEnd(currentNode.GetComponent<NodeControl>());
        }
    }

    private void ConnectNodes()
    {
        arrayNodeRowsConnections = textNodesConnections.text.Split("\n");

        for (int i = 0; i < listAllNodes.count; ++i)
        {
            arrayNodeColumnsConnections = arrayNodeRowsConnections[i].Split(";");

            for (int j = 0; j < arrayNodeColumnsConnections.Length; ++j)
            {
                listAllNodes.GetAtPosition(i).AddAdjacentNode(
                    listAllNodes.GetAtPosition(int.Parse(arrayNodeColumnsConnections[j])));
            }
        }
    }
    private void SetInitialNode()
    {
        currentEnemy.SetNewPosition(listAllNodes.GetAtPosition(0).gameObject.transform.position);
    }

}
