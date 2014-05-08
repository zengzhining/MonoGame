﻿// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Windows.Forms.Design;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Tools.Pipeline
{
    internal class PipelineProject : IProjectItem
    {        
        public IController Controller;        
        public string FilePath { get; set; }
        public List<ContentItem> ContentItems { get; private set; }                

        [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
        public string OutputDir { get; set; }

        [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
        public string IntermediateDir { get; set; }

        [Editor(typeof (AssemblyReferenceListEditor), typeof (UITypeEditor))]
        public List<string> References { get; set; }

        public TargetPlatform Platform { get; set; }

        public GraphicsProfile Profile { get; set; }

        public string Config { get; set; }     

        #region IPipelineItem

        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(FilePath))
                    return "";

                return System.IO.Path.GetFileNameWithoutExtension(FilePath);
            }
        }

        public string Location
        {
            get
            {
                if (string.IsNullOrEmpty(FilePath))
                    return "";

                var idx = FilePath.LastIndexOfAny(new char[] {Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar}, FilePath.Length - 1);
                return FilePath.Remove(idx);
            }
        }

        [Browsable(false)]
        public string Icon { get; set; }

        #endregion

        public PipelineProject()
        {
            ContentItems = new List<ContentItem>();
            References = new List<string>();
        }
    }
}