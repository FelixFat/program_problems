using System;

class Program
{

    class Node
    {
        private string _name;
        private float _mark;
        private Node _prev;
        private Node _next;

        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        public float Mark
        {
            set { _mark = value; }
            get { return _mark; }
        }

        public Node Prev
        {
            set { _prev = value; }
            get { return _prev; }
        }

        public Node Next
        {
            set { _next = value; }
            get { return _next; }
        }
    }

    class DoubleLinkedList
    {
        public Node Root;
        public Node End;

        public void add(String name, float mark)
        {
            Node n = new Node();
            Node i = Root;
            n.Name = name;
            n.Mark = mark;
            if (i == null)
            {
                n.Next = Root;
                End = n;
            }
            else
            {
                i.Prev = n;
                n.Next = i;
            }
            Root = n;
        }

        public void print()
        {
            Node i = Root;
            if (Root == null) Console.WriteLine("В списке студентов нет!");
            while (i != null)
            {
                Console.WriteLine(i.Name + " " + i.Mark);
                i = i.Next;
            }
        }

        public int length()
        {
            Node i = Root;
            int count = 0;
            while (i != null)
            {
                count++;
                i = i.Next;
            }
            return count;
        }

        public bool isEmpty()
        {
            if (Root == null) return true;
            else return false;
        }

        public void append(String name, float mark)
        {
            Node n = new Node();
            Node i = End;
            n.Name = name;
            n.Mark = mark;
            if (i == null)
            {
                n.Next = Root;
                Root = n;
            }
            else
            {
                End.Next = n;
                n.Prev = End;
            }
            End = n;
        }

        public void search(String name)
        {
            Node i = Root;
            int count = 1;
            while (i != null)
            {
                if (i.Name == name) break;
                i = i.Next;
                count++;
            }
            if (i == null || i.Name != name) Console.WriteLine("Такого студента в списке нет!");
            else Console.WriteLine("Студент под номером {0} - {1}, средний балл - {2}", count, i.Name, i.Mark);
        }

        public void remove(String name)
        {
            Node i = Root;
            Node j = End;
            while (i.Name != name)
            {
                i = i.Next;
            }
            while (j.Name != name)
            {
                j = j.Prev;
            }

            if (i.Name != name && j.Name != name) Console.WriteLine("Такого студента в списке нет!");
            else if (i == Root)
            {
                if (i.Next != null)
                {
                    Root = i.Next;
                    Root.Prev = null;
                }
                else Root = null;
            }
            else if (j == End)
            {
                if (j.Prev != null)
                {
                    End = j.Prev;
                    End.Next = null;
                }
                else End = null;
            }
            else
            {
                i = i.Prev;
                j = j.Next;
                i.Next = j;
                j.Prev = i;
            }
        }

        public void sortName()
        {
            Console.WriteLine("Здесь будет Ваш код для sortName.");
        }

        public void sortMark()
        {
            Console.WriteLine("Здесь будет Ваш код для sortMark.");
        }

    }

    static void Main()
    {

        DoubleLinkedList list = new DoubleLinkedList();
        Console.Clear();
        Console.WriteLine("Double Linked List created. Possible commands are:");
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("a <Фамилия> <Средняя оценка> - добавление нового студента");
        Console.WriteLine("p - напечатать список");
        Console.WriteLine("l - вывести длину списка");
        Console.WriteLine("e - проверить - есть ли студенты в списке");
        Console.WriteLine("w <Фамилия> <Средняя оценка> - добавление нового студента в конец списка");
        Console.WriteLine("s <Фамилия> - поиск студента в списке");
        Console.WriteLine("r <Фамилия> - удаление студента из списка");
        Console.WriteLine("sn - отсортировать список по фамилиями");
        Console.WriteLine("sm - отсортировать список по оценкам");
        Console.WriteLine("x - exit");
        Console.WriteLine("----------------------------------------------");

        while (true)
        {
            Console.Write("> ");
            string[] str = Console.ReadLine().Split(' ');
            switch (str[0].ToCharArray()[0])
            {
                case 'a':
                    list.add(str[1], float.Parse(str[2]));
                    break;
                case 'p':
                    list.print();
                    break;
                case 'l':
                    Console.WriteLine(list.length());
                    break;
                case 'e':
                    Console.WriteLine("Пуст? -" + list.isEmpty());
                    break;
                case 'w':
                    list.append(str[1], float.Parse(str[2]));
                    break;
                case 's':
                    if (str[0] == "s") list.search(str[1]);
                    if (str[0] == "sn") list.sortName();
                    if (str[0] == "sm") list.sortMark();
                    break;
                case 'r':
                    list.remove(str[1]);
                    break;
                case 'x':
                    return;

                default:
                    Console.WriteLine("No such command");
                    break;
            }

        }

    }

}
