using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace VersionInfoGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string version = File.ReadAllText("Version.txt");
            string[] versionParts = version.Split('.');

            if (versionParts != null)
            {
                int count = versionParts.Length;
                if (count > 0)
                {
                    int lastPart = Convert.ToInt32(versionParts[count - 1]);
                    lastPart++;
                    versionParts[count - 1] = lastPart.ToString();
                }
            }

            string finalVersion = string.Empty;
            foreach (string str in versionParts)
            {
                if(!string.IsNullOrEmpty(finalVersion))
                    finalVersion += ".";

                finalVersion += str;
            }

            GenerateTextFile(finalVersion);
            GenerateXMLFile(finalVersion);
            GenerateWixFile(finalVersion);
            GenerateCSFile(finalVersion);
        }

        static void GenerateTextFile(string version)
        {
            File.WriteAllText("Version.txt", version);
        }

        static void GenerateXMLFile(string version)
        {
            string text = string.Empty;

            text += "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + System.Environment.NewLine;
            text += "<Version Available=\"" + version + "\" />" + System.Environment.NewLine;

            File.WriteAllText("Version.xml", text);
        }

        static void GenerateWixFile(string version)
        {
            string text = string.Empty;

            text += "<Include>" + System.Environment.NewLine;
            text += "<?define ProductVersion=\"" + version + "\"?>" + System.Environment.NewLine;
            text += "</Include>" + System.Environment.NewLine;

            File.WriteAllText("Version.wxi", text);
        }

        static void GenerateCSFile(string version)
        {
            string text = string.Empty;

            text += "using System;" + System.Environment.NewLine;
            text += "namespace ProductVersion { class VersionInfo { static public string Version { get { return \"" + version + "\"; } } } }" + System.Environment.NewLine;

            File.WriteAllText("Version.cs", text);
        }
    }
}
