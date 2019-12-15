using ClimateVisualizer.Interfaces;
using ClimateVisualizer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ClimateVisualizer.DBServices
{
    public class ClimateRecordService : IClimateRecordService
    {
        IClimateRecordRepository Repo;
        PaginatedRecordList ClimateRecordPage;

        public ClimateRecordService(IClimateRecordRepository repo)
        {
            Repo = repo;
            ClimateRecordPage = new PaginatedRecordList(Repo.GetMonths(), Repo.GetProvinces(), Repo.GetClimateRecordCount());
        }

        public PaginatedRecordList GetDefaultRecords()
        {
            ClimateRecordPage.PageIndex = 1;
            ClimateRecordPage.Records = Repo.GetClimateRecordPage(ClimateRecordPage.PageIndex, 200);
            return ClimateRecordPage;
        }

        public PaginatedRecordList GetRecordPage(int index, int pageSize)
        {
            ClimateRecordPage.PageIndex = index;
            ClimateRecordPage.Records = Repo.GetClimateRecordPage(ClimateRecordPage.PageIndex, pageSize);
            return ClimateRecordPage;
        }

        public PaginatedRecordList GetFilteredPage(string searchStation, string month, string province, int index, int pageSize)
        {           
            ClimateRecordPage.Records = Repo.GetFilteredRecords(searchStation, month, province, index, pageSize);
            return ClimateRecordPage;
        }
    }
}
