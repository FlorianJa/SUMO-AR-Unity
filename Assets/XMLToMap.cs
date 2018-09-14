using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Xml.Linq;
using CodingConnected.TraCI.NET.Types;
using System.Globalization;

namespace sumo_unity
{
    public class Edge
    {
        public string Id;
        public List<Lane> Lanes;

        public Edge()
        {
            Lanes = new List<Lane>();
        }
    }

    public class Lane
    {
        public string Id;
        public List<Position2D> Shape;

        public Lane()
        {
            Shape = new List<Position2D>();
        }
    }

    public class XMLToMap : MonoBehaviour {


        public string path;
        public String MapName;
        public float ScalingFactor = 1;
        public float LaneHeight = 0.1f;
        public float LaneWidth = 1f;
        public bool useInternal;
        public Material Material;
        public bool CombineShapes;
        public bool CombineLanes;

        private GameObject map;
        

        public void LoadXMLFile()
        {
            if (!string.IsNullOrEmpty(path))
            {
                //load xml file
                var xml = XDocument.Load(@path);

                

                IEnumerable<IEnumerable<XElement>> query;

                if(useInternal)
                {
                     query = from c in xml.Root.Descendants("edge")
                                //where (string)c.Attribute("function") != "internal"
                                select c.Elements("lane");
                }
                else
                {
                    //query all lanes which are not internal
                    query = from c in xml.Root.Descendants("edge")
                                where (string)c.Attribute("function") != "internal"
                                select c.Elements("lane");
                }
                var Edges = new List<Edge>();

                foreach (var item in query)
                {
                    var edge = new Edge();
                    edge.Id = (string)item.First().Parent.Attribute("id");

                    foreach (var innerItem in item)
                    {
                        var lane = new Lane();
                        lane.Id = (string)innerItem.Attribute("id");
                        
                        lane.Shape = ParseToPosition2d(innerItem.Attribute("shape").Value);
                        edge.Lanes.Add(lane);
                    }

                    Edges.Add(edge);
                }

                GenerateMap(Edges);
            }

           
        }

        private void GenerateMap(List<Edge> edges)
        {
            if(edges.Count > 0)
            {
                //create new GameObject in hierachry
                map = new GameObject(MapName);

                var from = new Vector3();
                var to = new Vector3();

                foreach (var edge in edges)
                {
                    var GOEdge = new GameObject(edge.Id);
                    GOEdge.transform.parent = map.transform;

                    foreach (var lane in edge.Lanes)
                    {
                        var GOLane = new GameObject(lane.Id);
                        GOLane.transform.parent = GOEdge.transform;

                        for (int i = 0; i <= lane.Shape.Count - 2; i++)
                        {
                            from.x = (float)lane.Shape[i].X * ScalingFactor;
                            from.z = (float)lane.Shape[i].Y * ScalingFactor;
                            from.y = 0f;

                            to.x = (float)lane.Shape[i + 1].X * ScalingFactor;
                            to.z = (float)lane.Shape[i + 1].Y * ScalingFactor;
                            to.y = 0f;

                            var d = Vector3.Distance(from, to);

                            Vector3 fromTo;
                            if (from.x < to.x)
                            {
                                fromTo = to - from;
                            }
                            else
                            {
                                fromTo = from - to;
                            }

                            var a = Vector3.Angle(transform.forward, fromTo);

                            //create new cube for lane segment
                            var quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                            quad.transform.localScale = new Vector3(d, LaneHeight, LaneWidth);
                            quad.transform.position = from + ((to - from) / 2f);
                            //correct y axis angle by -90 degree
                            //rotate x axis by 90 because of the quad
                            quad.transform.rotation = Quaternion.Euler(90, a - 90, 0);
                            quad.transform.parent = GOLane.transform;
                        }
                        if (CombineShapes)
                        {
                            CombineMeshes(GOLane);
                        }
                    }
                    if (CombineLanes)
                    {
                        CombineMeshes(GOEdge);
                    }
                }
            }
        }

        private void CombineMeshes(GameObject parent)
        {
            MeshFilter[] meshFilters = parent.GetComponentsInChildren<MeshFilter>();
            CombineInstance[] combine = new CombineInstance[meshFilters.Length];

            int j = 0;
            while (j < meshFilters.Length)
            {
                combine[j].mesh = meshFilters[j].sharedMesh;
                combine[j].transform = meshFilters[j].transform.localToWorldMatrix;
                meshFilters[j].gameObject.SetActive(false);
                j++;
            }

            parent.AddComponent<MeshFilter>();
            parent.AddComponent<MeshCollider>();
            parent.AddComponent<MeshRenderer>();

            parent.GetComponent<MeshFilter>().sharedMesh = new Mesh();
            parent.GetComponent<MeshFilter>().sharedMesh.CombineMeshes(combine);
            parent.GetComponent<MeshRenderer>().material = Material;
            parent.GetComponent<MeshCollider>().sharedMesh = parent.GetComponent<MeshFilter>().sharedMesh;
            parent.gameObject.SetActive(true);

            int childs = parent.transform.childCount;
            for (int i = childs - 1; i >= 0; i--)
            {
                DestroyImmediate(parent.transform.GetChild(i).gameObject);
            }
        }

        private List<Position2D> ParseToPosition2d(string value)
        {
            var ret = new List<Position2D>();
            var splits = value.Split(' ');
            foreach (var item in splits)
            {
                var innerSplits = item.Split(',');
                var tmp = new Position2D();
                tmp.X = Convert.ToDouble(innerSplits[0], CultureInfo.InvariantCulture);
                tmp.Y = Convert.ToDouble(innerSplits[1], CultureInfo.InvariantCulture);
                ret.Add(tmp);
            }

            return ret;
        }
    }
}
