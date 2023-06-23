using System.Collections.Generic;
using BethanysPieShopBlazor.Shared;

namespace BethanysPieShopBlazor.Api.Models
{
    public interface IJobCategoryRepository
    {
        IEnumerable<JobCategory> GetAllJobCategories();
        JobCategory GetJobCategoryById(int jobCategoryId);
    }
}
