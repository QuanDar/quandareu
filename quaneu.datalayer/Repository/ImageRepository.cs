using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quaneu.datalayer.Contracts;
using quaneu.datalayer.Models.Image;

namespace quaneu.datalayer.Repository
{
    public class ImageRepository : RepositoryBase<Image>, IImageRepository
    {
        public ImageRepository(RepositoryDbContext _quanDarDbContext, ApplicationDbContext _applicationDbContext)
            : base(_quanDarDbContext, _applicationDbContext)
        {
        }
    }
}