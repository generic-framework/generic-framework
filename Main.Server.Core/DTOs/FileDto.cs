﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Server.Core.DTOs
{
    public class FileDto
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long? FileSize { get; set; }
    }
}
