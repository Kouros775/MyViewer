﻿using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System.Threading;

using OpenTK;
using MyViewer.Mesh;

namespace MyViewer.Loader
{
    public class STLReader
    {
        public string path; // file path
        private enum FileType { NONE, BINARY, ASCII }; // stl file type enumeration
        private bool processError;

        /**
        * @brief  Class instance constructor
        * @param  none
        * @retval none
        */
        public STLReader(string filePath = "")
        {
            path = filePath;
            processError = false;
        }


        /**
        * @brief  This function returns the process error value if its true there is an error on process
        * @param  none
        * @retval none
        */
        public bool Get_Process_Error()
        {
            return processError;
        }


        /**
        * @brief  *.stl file main read function
        * @param  none
        * @retval meshList
        */
        public CTriangleMesh[] ReadFile()
        {
            CTriangleMesh[] meshList;

            FileType stlFileType = GetFileType(path);

            if (stlFileType == FileType.ASCII)
            {
                meshList = ReadASCIIFile(path);
            }
            else if (stlFileType == FileType.BINARY)
            {
                meshList = ReadBinaryFile(path);
            }
            else
            {
                meshList = null;
            }

            return meshList;
        }

        /**
        * @brief  This function returns the min position of objects bounding box by checking
        *         all triangle meshes
        * @param  meshArray
        * @retval Vector3
        */
        public Vector3 GetMinMeshPosition(CTriangleMesh[] meshArray)
        {
            Vector3 minVec = new Vector3();

            float[] minRefArray = new float[3];
            minRefArray[0] = meshArray.Min(j => j.vert1.X);
            minRefArray[1] = meshArray.Min(j => j.vert2.X);
            minRefArray[2] = meshArray.Min(j => j.vert3.X);
            minVec.X = minRefArray.Min();
            minRefArray[0] = meshArray.Min(j => j.vert1.Y);
            minRefArray[1] = meshArray.Min(j => j.vert2.Y);
            minRefArray[2] = meshArray.Min(j => j.vert3.Y);
            minVec.Y = minRefArray.Min();
            minRefArray[0] = meshArray.Min(j => j.vert1.Z);
            minRefArray[1] = meshArray.Min(j => j.vert2.Z);
            minRefArray[2] = meshArray.Min(j => j.vert3.Z);
            minVec.Z = minRefArray.Min();

            return minVec;
        }

        /**
        * @brief  This function returns the max position of objects bounding box by checking
        *         all triangle meshes
        * @param  meshArray
        * @retval Vector3
        */
        public Vector3 GetMaxMeshPosition(CTriangleMesh[] meshArray)
        {
            Vector3 maxVec = new Vector3();

            float[] maxRefArray = new float[3];
            maxRefArray[0] = meshArray.Max(j => j.vert1.X);
            maxRefArray[1] = meshArray.Max(j => j.vert2.X);
            maxRefArray[2] = meshArray.Max(j => j.vert3.X);
            maxVec.X = maxRefArray.Max();
            maxRefArray[0] = meshArray.Max(j => j.vert1.Y);
            maxRefArray[1] = meshArray.Max(j => j.vert2.Y);
            maxRefArray[2] = meshArray.Max(j => j.vert3.Y);
            maxVec.Y = maxRefArray.Max();
            maxRefArray[0] = meshArray.Max(j => j.vert1.Z);
            maxRefArray[1] = meshArray.Max(j => j.vert2.Z);
            maxRefArray[2] = meshArray.Max(j => j.vert3.Z);
            maxVec.Z = maxRefArray.Max();

            return maxVec;
        }

        /**
        * @brief  This function checks the type of stl file binary or ascii, function is assuming
        *         given file as proper *.stl file 
        * @param  none
        * @retval stlFileType
        */
        private FileType GetFileType(string filePath)
        {
            FileType stlFileType = FileType.NONE;

            /* check path is exist */
            if (File.Exists(filePath))
            {
                int lineCount = 0;
                lineCount = File.ReadLines(filePath).Count(); // number of lines in the file
                
                string firstLine = File.ReadLines(filePath).First();

                string endLines = File.ReadLines(filePath).Skip(lineCount - 1).Take(1).First() +
                                  File.ReadLines(filePath).Skip(lineCount - 2).Take(1).First();

                /* check the file is ascii or not */
                if ((firstLine.IndexOf("solid") != -1) &
                    (endLines.IndexOf("endsolid") != -1))
                {
                    stlFileType = FileType.ASCII;
                }
                else
                {
                    stlFileType = FileType.BINARY;
                }

            }
            else
            {
                stlFileType = FileType.NONE;
            }


            return stlFileType;
        }


        /**
        * @brief  *.stl file binary read function
        * @param  filePath
        * @retval meshList
        */
        private CTriangleMesh[] ReadBinaryFile(string filePath)
        {
            List<CTriangleMesh> meshList = new List<CTriangleMesh>();
            int numOfMesh = 0;
            int i = 0;
            int byteIndex = 0;
            byte[] fileBytes = File.ReadAllBytes(filePath);

            byte[] temp = new byte[4];

            /* 80 bytes title + 4 byte num of triangles + 50 bytes (1 of triangular mesh)  */
            if (fileBytes.Length > 120)
            {

                temp[0] = fileBytes[80];
                temp[1] = fileBytes[81];
                temp[2] = fileBytes[82];
                temp[3] = fileBytes[83];

                numOfMesh = System.BitConverter.ToInt32(temp, 0);

                byteIndex = 84;

                for (i = 0; i < numOfMesh; i++)
                {
                    CTriangleMesh newMesh = new CTriangleMesh();

                    /* this try-catch block will be reviewed */
                    try
                    {
                        /* face normal */
                        newMesh.normal1.X = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;
                        newMesh.normal1.Y = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;
                        newMesh.normal1.Z = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;

                        /* normals of vertex 2 and 3 equals to vertex 1's normals */
                        newMesh.normal2 = newMesh.normal1;
                        newMesh.normal3 = newMesh.normal1;

                        /* vertex 1 */
                        newMesh.vert1.X = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;
                        newMesh.vert1.Y = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;
                        newMesh.vert1.Z = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;

                        /* vertex 2 */
                        newMesh.vert2.X = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;
                        newMesh.vert2.Y = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;
                        newMesh.vert2.Z = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;

                        /* vertex 3 */
                        newMesh.vert3.X = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;
                        newMesh.vert3.Y = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;
                        newMesh.vert3.Z = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                        byteIndex += 4;

                        byteIndex += 2; // Attribute byte count
                    }
                    catch
                    {
                        processError = true;
                        break;
                    }

                    meshList.Add(newMesh);

                }

            }
            else
            {
                // nitentionally left blank
            }

            return meshList.ToArray();
        }


        /**
        * @brief  *.stl file ascii read function
        * @param  filePath
        * @retval meshList
        */
        private CTriangleMesh[] ReadASCIIFile(string filePath)
        {
            List<CTriangleMesh> meshList = new List<CTriangleMesh>();

            StreamReader txtReader = new StreamReader(filePath);

            string lineString;

            while (!txtReader.EndOfStream)
            {
                lineString = txtReader.ReadLine().Trim(); /* delete whitespace in front and tail of the string */
                string[] lineData = lineString.Split(' ');

                if (lineData[0] == "solid")
                {
                    while (lineData[0] != "endsolid")
                    {
                        lineString = txtReader.ReadLine().Trim(); // facetnormal
                        lineData = lineString.Split(' ');

                        if (lineData[0] == "endsolid") // check if we reach at the end of file
                        {
                            break;
                        }

                        CTriangleMesh newMesh = new CTriangleMesh(); // define new mesh object

                        /* this try-catch block will be reviewed */
                        try
                        {
                            // FaceNormal 
                            newMesh.normal1.X = float.Parse(lineData[2]);
                            newMesh.normal1.Y = float.Parse(lineData[3]);
                            newMesh.normal1.Z = float.Parse(lineData[4]);

                            /* normals of vertex 2 and 3 equals to vertex 1's normals */
                            newMesh.normal2 = newMesh.normal1;
                            newMesh.normal3 = newMesh.normal1;

                            //----------------------------------------------------------------------
                            lineString = txtReader.ReadLine(); // Just skip the OuterLoop line
                            //----------------------------------------------------------------------

                            // Vertex1
                            lineString = txtReader.ReadLine().Trim();
                            /* reduce spaces until string has proper format for split */
                            while (lineString.IndexOf("  ") != -1) lineString = lineString.Replace("  ", " ");
                            lineData = lineString.Split(' ');

                            newMesh.vert1.X = float.Parse(lineData[1]); // x1
                            newMesh.vert1.Y = float.Parse(lineData[2]); // y1
                            newMesh.vert1.Z = float.Parse(lineData[3]); // z1

                            // Vertex2
                            lineString = txtReader.ReadLine().Trim();
                            /* reduce spaces until string has proper format for split */
                            while (lineString.IndexOf("  ") != -1) lineString = lineString.Replace("  ", " ");
                            lineData = lineString.Split(' ');

                            newMesh.vert2.X = float.Parse(lineData[1]); // x2
                            newMesh.vert2.Y = float.Parse(lineData[2]); // y2
                            newMesh.vert2.Z = float.Parse(lineData[3]); // z2

                            // Vertex3
                            lineString = txtReader.ReadLine().Trim();
                            /* reduce spaces until string has proper format for split */
                            while (lineString.IndexOf("  ") != -1) lineString = lineString.Replace("  ", " ");
                            lineData = lineString.Split(' ');

                            newMesh.vert3.X = float.Parse(lineData[1]); // x3
                            newMesh.vert3.Y = float.Parse(lineData[2]); // y3
                            newMesh.vert3.Z = float.Parse(lineData[3]); // z3
                        }
                        catch
                        {
                            processError = true;
                            break;
                        }

                        //----------------------------------------------------------------------
                        lineString = txtReader.ReadLine(); // Just skip the endloop
                        //----------------------------------------------------------------------
                        lineString = txtReader.ReadLine(); // Just skip the endfacet

                        meshList.Add(newMesh); // add mesh to meshList

                    } // while linedata[0]
                } // if solid
            } // while !endofstream

            return meshList.ToArray();
        }

    }
}
