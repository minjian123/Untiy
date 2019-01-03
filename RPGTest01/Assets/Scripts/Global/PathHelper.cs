using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Global
{
    class PathHelper
    {
        private static string separator;
        private static string assetPath;
        private static string resourcesPath;
        private static string atlasPath;
        private static string prefabsPath;

        public static string Separator
        {
            get
            {
                if (separator == null)
                {
                    if (OSHelper.IsUnix || OSHelper.IsMacOSX)
                    {
                        separator = "/";
                    }
                    else
                    {
                        separator = "/";
                    }
                }
                return separator;
            }

            set
            {
                separator = value;
            }
        }

        public static string AssetPath
        {
            get
            {
                return Application.dataPath;
            }
        }

        public static string ResourcesPath
        {
            get
            {
                if (resourcesPath == null)
                {
                    resourcesPath = AssetPath + Separator + "Resources";
                }
                return resourcesPath;
            }

            set
            {
                resourcesPath = value;
            }
        }

        public static string AtlasPath
        {
            get
            {
                if (atlasPath == null)
                {
                    atlasPath = ResourcesPath + Separator + "Atlas";
                }
                return atlasPath;
            }

            set
            {
                atlasPath = value;
            }
        }

        public static DirectoryInfo getDirectoryInfo(String path)
        {
            DirectoryInfo direction = new DirectoryInfo(path);
            return direction;
        }

        public static DirectoryInfo AtlasDirectoryInfo
        {
            get
            {
                return getDirectoryInfo(AtlasPath);
            }
        }

        public static string PrefabsPath
        {
            get
            {
                if (prefabsPath == null)
                {
                    prefabsPath = ResourcesPath + Separator + "Prefabs";
                }
                return prefabsPath;
            }

            set
            {
                prefabsPath = value;
            }
        }

        public static DirectoryInfo ResourcesDirectoryInfo
        {
            get
            {
                return getDirectoryInfo(ResourcesPath);
            }
        }
    }
}
