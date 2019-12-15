using ClimateVisualizer.Interfaces;
using ClimateVisualizer.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ClimateVisualizer.DBServices
{
    public class StationRepository : IStationRepository
    {

        private const string StationListQuery = "Select [StationId], [StationName], [Province], [Latitude], [Longitude] from [Warehouse].[dbo].[Stations] " + 
        "ORDER BY [StationId] OFFSET @Offset ROWS FETCH NEXT @Pagesize ROWS ONLY";

        private const string StationDetailQuery = "";

        private const string WhereClause = "WHERE e.[StationId] = @StationID";
        
        private readonly IConfiguration Configuration;

        public StationRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IEnumerable<StationListModel> GetStationList(int pageIndex, int pageSize)
        {
            using var dal = new DalSession(Configuration);

            return dal.Connection.Query<StationListModel>(StationListQuery, new { Offset = (pageIndex - 1) * pageSize, PageSize = pageSize }).ToList();
        }

        public IEnumerable<StationDetailModel> GetStationDetails(int pageIndex, int pageSize, int id)
        {
            using var dal = new DalSession(Configuration);

            return dal.Connection.Query<StationDetailModel>(StationDetailQuery + WhereClause, new { Offset = (pageIndex - 1) * pageSize, PageSize = pageSize, StationID = id}).ToList();
        }

        public int GetStationListCount()
        {
            throw new NotImplementedException();
        }

        public int GetStationDetailsCount(int id)
        {
            throw new NotImplementedException();
        }
    }
}
