using GreenThumb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Data
{
    public class GardenRepository
    {
        private GreenThumbDbContext _context;

        public GardenRepository(GreenThumbDbContext context)
        {
            _context = context;
        }

        public GardenModel? GetUserGarden(int userId) 
        {
            return _context.Gardens.FirstOrDefault(g => g.UserId == userId);
        }
    }
}
