using System;
public class DoublyLinkedCircularList<T>
{
    private class Node
    {
        public Node Next { get; set; }
        public Node Previous { get; set; }
        public T Value { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }

    Node head;
    public int count = 0;

    public void AddAtStart(T value)
    {
        if (head == null)
        {
            Node newNode = new Node(value);
            head = newNode;
            head.Next = head;
            head.Previous = head;
            count = count + 1;

        }
        else
        {
            Node newNode = new Node(value);
            Node lastNode = head.Previous;
            newNode.Next = head;
            newNode.Previous = lastNode;
            lastNode.Next = newNode;
            head.Previous = newNode;
            head = newNode;
            count = count + 1;
        }
    }

    public void AddAtEnd(T value)
    {
        if (head == null)
        {
            AddAtStart(value);
        }
        else
        {
            Node newNode = new Node(value);
            Node lastNode = head.Previous;
            lastNode.Next = newNode;
            newNode.Previous = lastNode;
            newNode.Next = head;
            head.Previous = newNode;
            count = count + 1;
        }
    }

    public void AddAtPosition(T value, int position)
    {
        if (position < 0 || position > count)
        {
            throw new ArgumentOutOfRangeException("Posición fuera de los límites ");
        }

        if (position == 0)
        {
            AddAtStart(value);
        }
        else if (position == count)
        {
            AddAtEnd(value);
        }
        else
        {
            Node newNode = new Node(value);
            Node current = head;

            for (int i = 0; i < position; i++)
            {
                current = current.Next;
            }

            Node previousNode = current.Previous;
            newNode.Next = current;
            newNode.Previous = previousNode;
            previousNode.Next = newNode;
            current.Previous = newNode;
            count = count + 1;
        }
    }

    public void ModifyAtStart(T value)
    {
        if (head == null)
        {
            throw new InvalidOperationException("La lista está vacía ");
        }
        else
        {
            head.Value = value;
        }
    }

    public void ModifyAtEnd(T value)
    {
        if (head == null)
        {
            throw new InvalidOperationException("La lista está vacía ");
        }
        else
        {
            head.Previous.Value = value;
        }
    }

    public void ModifyAtPosition(T value, int position)
    {
        if (position < 0 || position >= count)
        {
            throw new ArgumentOutOfRangeException("Posición fuera de los límites ");
        }
        else
        {
            Node current = head;
            for (int i = 0; i < position; i++)
            {
                current = current.Next;
            }
            current.Value = value;
        }
    }
    public T GetAtStart()
    {
        if (head == null)
        {
            throw new InvalidOperationException("La lista está vacía ");
        }
        else
        {
            return head.Value;
        }
    }

    public T GetAtEnd()
    {
        if (head == null)
        {
            throw new InvalidOperationException("La lista está vacía ");
        }
        else
        {
            return head.Previous.Value;
        }
    }

    public T GetAtPosition(int position)
    {
        if (position < 0 || position >= count)
        {
            throw new ArgumentOutOfRangeException("Posición fuera de los límites ");
        }
        else
        {
            Node current = head;
            for (int i = 0; i < position; i++)
            {
                current = current.Next;
            }

            return current.Value;
        }
    }

    public void DeleteAtStart()
    {
        if (head == null)
        {
            throw new InvalidOperationException("La lista está vacía ");
        }
        else if (count == 1)
        {
            head = null;
        }
        else
        {
            Node lastNode = head.Previous;
            head = head.Next;
            head.Previous = lastNode;
            lastNode.Next = head;
            count = count - 1;
        }
    }

    public void DeleteAtEnd()
    {
        if (head == null)
        {
            throw new InvalidOperationException("La lista está vacía ");
        }
        else if (count == 1)
        {
            head = null;
        }
        else
        {
            Node lastNode = head.Previous.Previous;
            lastNode.Next = head;
            head.Previous = lastNode;
            count = count - 1;
        }
    }
    public void DeleteAtPosition(int position)
    {
        if (position < 0 || position >= count)
        {
            throw new ArgumentOutOfRangeException("Posición fuera de los límites ");
        }

        if (position == 0)
        {
            DeleteAtStart();
        }
        else if (position == count - 1)
        {
            DeleteAtEnd();
        }
        else
        {
            Node current = head;
            for (int i = 0; i < position; i++)
            {
                current = current.Next;
            }
            Node previousNode = current.Previous;
            Node nextNode = current.Next;
            previousNode.Next = nextNode;
            nextNode.Previous = previousNode;
            count = count - 1;
        }
    }

}
