using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace route
{
    /// <summary>
    /// 邻接表存储图
    /// </summary>
    /// <typeparam name="T"></typeparam>
    //表节点
    public class ArcNode<T>
    {
        //该弧所指向的顶点
        public HeadNode<T> headNode;
        //指向下一条弧的指针
        public ArcNode<T> Next;
        //弧上的权值
        public ArcNode(HeadNode<T> value)
        {
            headNode = value;
        }
    }

    //头节点
    public class HeadNode<T>
    {
        public T Data;
        //指向第一条依附于该顶点的弧的指针
        public ArcNode<T> FirstEdge;
        //访问标志，遍历时可以用
        public bool isVisited;
        public HeadNode(T value)
        {
            Data = value;
        }
    }
    //adjacent list
    public class AdjacencyList<T>
    {
        //vertex set
        public readonly List<HeadNode<T>> _items;
        public AdjacencyList() { }
        public AdjacencyList(int capacity) { _items = new List<HeadNode<T>>(capacity); }
        //edges set

        public void AddNode(T item)
        {
            if (Contains(item))
            { throw new ArgumentException("插入重复的点！"); }
            _items.Add(new HeadNode<T>(item));
        }
        public bool Contains(T item)
        {
            foreach (HeadNode<T> v in _items)
            {
                if (v.Data.Equals(item))
                { return true; }
            }
            return false;
        }
        public void AddEdge(T from, T to)
        {
            HeadNode<T> fromVer = Find(from);
            if (fromVer == null)
            {
                throw new ArgumentException("头顶点不存在");
            }
            HeadNode<T> toVer = Find(to);
            if (toVer == null)
            {
                throw new ArgumentException("尾顶点不存在");
            }
            AddDirectedEdge(fromVer,toVer);
            AddDirectedEdge(toVer, fromVer);
        }
        public void AddDirectedEdge(HeadNode<T> fromVer, HeadNode<T> toVer)
        {
            if (fromVer.FirstEdge == null)
            {
                fromVer.FirstEdge = new ArcNode<T>(toVer);
            }
            else
            {
                ArcNode<T> tem, node = fromVer.FirstEdge;
                do
                {
                    if (node.headNode.Equals(toVer.Data))
                    {
                        throw new ArgumentException("添加了重复边！");
                    }
                    tem = node;
                    node = node.Next;
                } while (node != null);
                tem.Next = new ArcNode<T>(toVer);
            }
        }
 
    private HeadNode<T> Find(T item)
        {
            //foreach (Vertex<T> v in _items)  
            //{  
            //    if (v.data.Equals(item))  
            //    {  
            //        return v;  
            //    }  
            //}  
            return _items.FirstOrDefault(v => v.Data.Equals(item));
        }


        public string asString()
        {
            string outputstring = string.Empty;
            foreach (var HeadNode in _items)
            {
                if (HeadNode != null)
                {
                    outputstring += string.Format("顶点：{0}",HeadNode.Data);
                    if (HeadNode.FirstEdge != null)
                    {
                        ArcNode < T > tem= HeadNode.FirstEdge;
                        while (tem != null)
                        {
                            outputstring += tem.headNode.Data.ToString();
                            tem = tem.Next;
                        }
                    }
                }
                outputstring += "\r\n";
            }
            return outputstring;

        }

    }
}
