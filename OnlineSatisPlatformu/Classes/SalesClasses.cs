
// ÇİFT YÖNLÜ DAİRESEL BAĞLI LİSTE YAPISI



using OnlineSatisPlatformu.ProductClasses;

namespace OnlineSatisPlatformu.Classes
{
    public class clsSatis
    {
        public clsProduct Urun;
        public DateTime SatisTarihi;
        public int KargoTipi;
        public string KargoAdi;
        public clsSatis(clsProduct Urun, int KargoTipi, string KargoAdi)
        {
            this.Urun = Urun;
            this.KargoAdi = KargoAdi;
            this.KargoTipi = KargoTipi;
            this.SatisTarihi = DateTime.Now;
        }
    }
    public class SepetNode
    {
        public clsSatis data;
        public SepetNode? next;
        public SepetNode? prev;

        public SepetNode(clsSatis value)
        {
            data = value;
            next = null;
            prev = null;
        }
    }
    public class SepetLinkedList
    {
        public SepetNode? head;

        public SepetLinkedList()
        {
            head = null;
        }

        public void Add(clsSatis value)
        {
            SepetNode node = new SepetNode(value);

            if (this.head == null)
            {
                head = node;
                head.next = node;
                head.prev = node;
                return;
            }
           

            SepetNode lastNode = head.prev;
            node.prev = lastNode;
            node.next = head;
            lastNode.next = node;
            head.prev = node;
        }

        public void Remove(clsSatis value)
        {
            if (head == null)
            {
                return;
            }

            SepetNode currentNode = head;

            while (currentNode != null && currentNode.data != value)
            {
                
                currentNode = currentNode.next;

                if (currentNode == head)
                {
                    return;
                }
            }

            if (currentNode == null)
            {
                return;
            }

            if (head == currentNode)
            {
                head = head.next;

               
                if (head == currentNode)
                {
                    head = null;
                    return;
                }
            }

            currentNode.prev.next = currentNode.next;
            currentNode.next.prev = currentNode.prev;
            currentNode = null;

        }

        public void Print()
        {
            if (head == null)
            {
                return;
            }

            SepetNode currentNode = head;

            do
            {
                Console.Write("{0} ", currentNode.data);
                currentNode = currentNode.next;
            } while (currentNode != head);

            Console.WriteLine();
        }

    }
}
