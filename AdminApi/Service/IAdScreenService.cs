using AdminApi.Models.App;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AdminApi.Service
{
    public interface IAdScreenService
    {
        IEnumerable<object> GetScreenListbyTheaterName(string TheaterName, int Stateid, int AgentId);
    }
}
