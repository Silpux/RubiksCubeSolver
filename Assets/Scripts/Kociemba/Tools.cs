using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace KociembaSolver{

    public class Tools{
        public static void SerializeTable(string filename, short[,] array){
            EnsureFolder(Kociemba.TABLES_FOLDER_PATH);
            using FileStream stream = new(Kociemba.TABLES_FOLDER_PATH + filename, FileMode.Create, FileAccess.Write);
            using BinaryWriter writer = new(stream);
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            writer.Write(rows);
            writer.Write(cols);
            for(int i = 0; i < rows; i++){
                for(int j = 0; j < cols; j++){
                    writer.Write(array[i, j]);
                }
            }
        }

        public static short[,] DeserializeTable(string filename){
            EnsureFolder(Kociemba.TABLES_FOLDER_PATH);
            using FileStream stream = new(Kociemba.TABLES_FOLDER_PATH + filename, FileMode.Open, FileAccess.Read);
            using BinaryReader reader = new(stream);
            int rows = reader.ReadInt32();
            int cols = reader.ReadInt32();
            short[,] array = new short[rows, cols];
            for(int i = 0; i < rows; i++){
                for(int j = 0; j < cols; j++){
                    array[i, j] = reader.ReadInt16();
                }
            }
            return array;
        }

        public static void SerializeSbyteArray(string filename, sbyte[] array){
            EnsureFolder(Kociemba.TABLES_FOLDER_PATH);
            using FileStream stream = new FileStream(Kociemba.TABLES_FOLDER_PATH + filename, FileMode.Create, FileAccess.Write);
            using BinaryWriter writer = new BinaryWriter(stream);
            writer.Write(array.Length);
            foreach(sbyte value in array){
                writer.Write(value);
            }
        }

        public static sbyte[] DeserializeSbyteArray(string filename){
            EnsureFolder(Kociemba.TABLES_FOLDER_PATH);
            using FileStream stream = new FileStream(Kociemba.TABLES_FOLDER_PATH + filename, FileMode.Open, FileAccess.Read);
            using BinaryReader reader = new BinaryReader(stream);
            int length = reader.ReadInt32();
            sbyte[] array = new sbyte[length];
            for(int i = 0; i < length; i++){
                array[i] = reader.ReadSByte();
            }
            return array;
        }

        private static void EnsureFolder(string path){
            if (!Directory.Exists(path)){
                Directory.CreateDirectory(path);
            }
        }
    }

}
