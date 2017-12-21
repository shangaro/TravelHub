using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelHub.services.NewsService.Implementation
{
    public interface INewsApiService
    {
        string GetTopHeadLines(string sourceName);
    }
}
