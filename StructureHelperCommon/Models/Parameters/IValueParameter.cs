﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace StructureHelperCommon.Models.Parameters
{
    public interface IValueParameter<T>
    {
        bool IsValid { get; set; }
        string Name { get; set; }
        string ShortName { get; set; }
        Color Color { get; set; }
        string MeasurementUnit { get; set; }
        T Value { get; set; }
        string Description { get; set; }
    }
}
