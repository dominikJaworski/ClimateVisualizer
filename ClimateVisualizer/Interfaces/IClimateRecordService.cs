using ClimateVisualizer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimateVisualizer.Interfaces
{
    public interface IClimateRecordService
    {
        PaginatedRecordList GetDefaultRecords();

        PaginatedRecordList GetRecordPage(int index, int pageSize);

    }
}
