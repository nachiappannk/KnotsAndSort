// See https://aka.ms/new-console-template for more information
public class Stack
{
    private List<Operation> operations = new List<Operation>();
    private List<int> resetMarker = new List<int>();

    public void Push(Operation operation)
    {
        operations.Add(operation);
    }

    public void PushWithResetMarker(Operation operation)
    {
        resetMarker.Add(operations.Count);
        operations.Add(operation);

    }

    public void Reset()
    { 
        var topResetMarker = resetMarker.ElementAt(resetMarker.Count - 1);
        resetMarker.RemoveAt(resetMarker.Count - 1);
        while(operations.Count > topResetMarker)
        {
            operations.RemoveAt(operations.Count - 1);
        }
    }

    public List<Operation> GetOperations()
    {
        return operations;
    }
}
