using ClimateVisualizer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimateVisualizer.Interfaces
{
    public interface IClimateRecordRepository
    {
        IEnumerable<RecordModel> GetClimateRecordPage(int pageIndex, int pageSize);
        //IEnumerable<RecordModel> GetFilteredRecords(string searchStation, string month, string province, int pageIndex, int pageSize);
        List<SelectListItem> GetMonths();
        List<SelectListItem> GetProvinces();
        int GetClimateRecordCount();
    }
}
