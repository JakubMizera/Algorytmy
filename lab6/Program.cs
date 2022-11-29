﻿namespace lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            string expression = "2 5 + 7 * 4 2 - /";
            foreach (string token in expression.Split(" "))
            {
                switch (token)
                {
                    case "*":
                        if (stack.Count >= 2)
                        {
                            stack.Push(stack.Pop() * stack.Pop());
                        }
                        else
                        {
                            throw new InvalidOperationException();
                        }
                        break;
                    case "+":
                        stack.Push(stack.Pop() + stack.Pop());
                        break;
                    case "-":
                        {
                            int a = stack.Pop();
                            int b = stack.Pop();
                            stack.Push(b - a);
                        }
                        break;
                    case "/":
                        {
                            int a = stack.Pop();
                            int b = stack.Pop();
                            stack.Push(b / a);
                        }
                        break;
                    default:
                        if (int.TryParse(token, out int value))
                        {
                            stack.Push(value);
                        }
                        else
                        {
                            throw new InvalidOperationException();
                        }
                        break;
                }
            }
            if (stack.Count == 1)
            {
                System.Console.WriteLine(stack.Pop());
            }
            else
            {
                System.Console.WriteLine("Błąd w składni");
            }
        }

        public static void test()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(4);
            stack.Push(2);
            stack.Push(1);
            System.Console.WriteLine(stack.Count == 3);
            System.Console.WriteLine(stack.Pop() == 1);

            Queue<string> queue = new Queue<string>();
            System.Console.WriteLine(queue.Count == 0);
            queue.Enqueue("Adam");
            queue.Enqueue("Ewa");
            queue.Enqueue("Karol");
            System.Console.WriteLine(queue.Count == 3);
            System.Console.WriteLine(queue.Dequeue() == "Adam");
            System.Console.WriteLine(queue.Count == 2);
        }

    }
    public class LinkedQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;
        public int Count { get { return count; } }
        public void Enqueue(T item)
        {
            if (IsEmpty())
            {
                head = new Node<T>() { Value = item };
                tail = head;
            }
            else
            {
                var node = new Node<T> { Value = item };
                tail.Next = node;
                tail = node;
            }
            count++;
        }
        public T Dequeue()
        {
            if (!IsEmpty())
            {
                T result = head.Value;
                head = head.Next;
                count--;
                if (IsEmpty())
                {
                    tail = null;
                }
                return result;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public bool IsEmpty()
        {
            return head == null;
        }
    }

    internal class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }

    public class LinkedStack<T>
    {
        private int count;
        public int Count { get { return count; } }
        private Node<T> head;
        public void Push(T item)
        {
            if (IsEmpty())
            {
                head = new Node<T> { Value = item, Next = null };
            }
            else
            {
                var node = new Node<T> { Value = item, Next = null };
                node.Next = head;
                head = node;
            }
            count++;
        }
        public T Pop()
        {

            if (!IsEmpty())
            {
                T result = head.Value;
                head = head.Next;
                count--;
                return result;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public bool IsEmpty()
        {
            return head == null;
        }
    }
}