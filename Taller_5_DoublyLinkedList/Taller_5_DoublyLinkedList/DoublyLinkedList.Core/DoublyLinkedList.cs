using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList.Core;

public class DoublyLinkedList<T> where T : IComparable<T>
{

    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;

    public DoublyLinkedList()
    {
        _head = null;
        _tail = null;
    }


    public void InsertSorted(T data)
    {
        var newNode = new DoubleNode<T>(data);

        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }

        var current = _head;

        while (current! != null && current.Data!.CompareTo(data) < 0)
        {
            current = current.Next;
        }

        if (current == _head)
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }

        else if (current == null)
        {
            _tail!.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }
        else
        {
            var predecessor = current.Prev;

            predecessor!.Next = newNode;
            newNode.Prev = predecessor;

            newNode.Next = current;
            current.Prev = newNode;
        }

    }

    public string GetForward()
    {
        var output = string.Empty;
        var current = _head;
        while (current != null)
        {
            output += $"{current.Data} <=> ";
            current = current.Next;
        }
        if (output.Length <= 5)
        {
            return "List empty";
        }
        return output.Substring(0, output.Length - 5);
    }

    public string GetBackward()
    {
        var output = string.Empty;
        var current = _tail;
        while (current != null)
        {
            output += $"{current.Data} <=> ";
            current = current.Prev;
        }
        if (output.Length <= 5)
        {
            return "List empty";
        }
        return output.Substring(0, output.Length - 5);
    }

    public void SortDescending()
    {
        if (_head == null || _head.Next == null)
        {
            return;
        }

        bool validate;

        do
        {
            validate = false;
            var current = _head;

            while (current.Next != null)
            {
                if (current.Data!.CompareTo(current.Next.Data!) < 0)
                {
                    T tempData = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = tempData;

                    validate = true;
                }

                current = current.Next;
            }
        } while (validate);
    }

    public void SortAscending()
    {
        if (_head == null || _head.Next == null)
        {
            return;
        }

        bool validate;

        do
        {
            validate = false;
            var current = _head;

            while (current.Next != null)
            {
                if (current.Data!.CompareTo(current.Next.Data!) > 0)
                {
                    T tempData = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = tempData;

                    validate = true;
                }

                current = current.Next;
            }
        } while (validate);
    }

    private class Occurrence
    {
        public T Data { get; set; }
        public int Count { get; set; }

        public Occurrence(T data, int count)
        {
            Data = data;
            Count = count;
        }
    }

    private List<T> GetModa()
    {
        if (_head == null)
        {
            return new List<T>();
        }

        var frequencies = new List<Occurrence>();
        var current = _head;
        var currentCount = 1;

        while (current.Next != null)
        {
            if (current.Data!.Equals(current.Next.Data))
            {
                currentCount++;
            }
            else
            {
                frequencies.Add(new Occurrence(current.Data, currentCount));
                currentCount = 1;
            }
            current = current.Next;
        }
        frequencies.Add(new Occurrence(current.Data!, currentCount));

        int maxFrequency = 0;
        foreach (var item in frequencies)
        {
            if (item.Count > maxFrequency)
            {
                maxFrequency = item.Count;
            }
        }

        var modas = new List<T>();
        if (maxFrequency > 1)
        {
            foreach (var item in frequencies)
            {
                if (item.Count == maxFrequency)
                {
                    modas.Add(item.Data);
                }
            }
        }

        return modas;
    }

    public string ShowModa()
    {

        var modas = GetModa();
        if (modas.Count == 0)
        {
            return "No moda found.";
        }
        else
        {
            return "Moda(s): " + string.Join(", ", modas);
        }
    }


    public string ShowGraph()
    {
        if (_head == null)
        {
            return "List empty.";
        }

        var frequencies = new List<Occurrence>();
        var current = _head;
        var currentCount = 1;

        while (current.Next != null)
        {
            if (current.Data!.Equals(current.Next.Data))
            {
                currentCount++;
            }
            else
            {
                frequencies.Add(new Occurrence(current.Data, currentCount));
                currentCount = 1;
            }
            current = current.Next;
        }
        frequencies.Add(new Occurrence(current.Data!, currentCount));

        string output = string.Empty;

        foreach (var item in frequencies)
        {
            string asterisks = "";
            for (int i = 0; i < item.Count; i++)
            {
                asterisks += "*";
            }

            output += $"{item.Data} {asterisks}{Environment.NewLine}";
        }

        return output;
    }

    public string Exists(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                return "exists";
            }
            current = current.Next;
        }
        return "does not exist";
    }

    public void DeleteConcurrency(T data)
    {
        var current = _head;

        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    _head = current.Next;
                }
                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    _tail = current.Prev;
                }
                break;
            }
            current = current.Next;
        }
    }

    public void DeleteAllConcurrency()
    {
        _head = null;
        _tail = null;
    }

}
