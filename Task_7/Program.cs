using System.Collections;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using Microsoft.VisualBasic;

namespace Task_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            circularqueue<int> q = new circularqueue<int>(5);
            q.Enqueue(11);
            q.Enqueue(10);
            q.Enqueue(6);
            q.Enqueue(7);
            q.Enqueue(8);

            while (q.Size > 0)
                Console.WriteLine(q.Dequeue());

            q.Enqueue(9);
            q.Enqueue(10);
            q.Enqueue(11);
            while (q.Size > 0)
            {
                Console.WriteLine($"{q.Dequeue()} -> size: {q.Size}");
            }
            q.Enqueue(11);
            Console.WriteLine(q.peak());
            queue<int> queue = new queue<int>(5);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            queue.Enqueue(4);
            queue.Enqueue(6);
            foreach (int i in queue)
            {
                Console.WriteLine(i);
            }
        }

    }
    public class queue<T> : IEnumerable<T>
    {
        private int rear;
        private int front;
        private T[] Queue;
        public queue(int size)
        {
            Queue = new T[size];
            front = 0;
            rear = -1;
        }
        public bool isFull()
        {
            return rear == Queue.Length - 1;
        }

        public bool isEmpty()
        {
            return rear < front;
        }

        public void Enqueue(T item)
        {
            if (isFull())
            {
                Console.WriteLine("Queue is full");
            }
            else
            {
                rear = (rear + 1);
                Queue[rear] = item;
       
            }
        }

        public T Dequeue()
        {
            if (isEmpty())
            {
                Console.Write("Queue is Empty ");
                return default(T);
            }
            return Queue[front++];

        }

        public T peak()
        {
            if (isEmpty())
            {
                Console.Write("Queue is Empty ");
                return default(T);
            }
               return Queue[front];
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = front; i <= rear; i++)
            {
                yield return Queue[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class circularqueue<T> : IEnumerable<T>
    {
        private int capacity;
        private int rear;
        private int front;
        private int size;
        private T[] queue;
        public int Size
        {
            get { return this.size; }
            private set { }
        }
        public circularqueue(int cap)
        {
            capacity = cap;
            queue = new T[capacity];
            size = 0;
            front = 0;
            rear = -1;
        }
        public bool isFull()
        {
            return size == capacity;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public void Enqueue(T item)
        {
            if (isFull())
            {
                Console.WriteLine("Queue is full");
            }
            else
            {
                rear = (rear + 1) % capacity;
                queue[rear] = item;
                size++;
            }
        }

        public T Dequeue()
        {
            if (isEmpty())
            {
                Console.WriteLine("Queue is Empty");
                return default(T);
            }

            size--;
            front = front % capacity;
            return queue[front++];

        }

        public T peak()
        {
            if (isEmpty())
            {
                Console.WriteLine("Queue is Empty");
                return default(T);
            }
            return queue[front];
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < size; i++)
            {
                yield return queue[(front + i) % capacity];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
