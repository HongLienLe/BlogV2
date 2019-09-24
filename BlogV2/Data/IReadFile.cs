using System;
using System.Collections.Generic;

namespace BlogV2.Models
{
    public interface IReadFile
    {
        List<Recipe> LoadEntries(string path);
    }
}
